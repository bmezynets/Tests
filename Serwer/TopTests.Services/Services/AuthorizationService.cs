using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.Services.Cryptography;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Tokens;
using TopTests.Services.Models.Users;

namespace TopTests.Services.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;
        private readonly ITokenGeneratorService token;
        private readonly IRefreshRepository refreshRepository;
        public AuthorizationService(IUserRepository userRepository, IEmailService emailService, IMapper mapper,
                                     ITokenGeneratorService token,IRefreshRepository refreshRepository)
        {
            this.userRepository = userRepository;
            this.emailService = emailService;
            this.mapper = mapper;
            this.token = token;
            this.refreshRepository = refreshRepository;
        }

        public async Task<bool> ConfirmRegistration(string code)
        {
            var user = await userRepository.FindByCodeOfVerificationAsync(code);
            if (user == null)
            {
                return false;
            }
            user.StatusOfVerification = "Active";
            user.CodeOfVerification = user.GetRandomString(128);
            userRepository.Update(user);
            await userRepository.SaveChangesAsync();
            return true;
        }
        public async Task<RegisterUserDto> RegisterUser(RegisterUserDto registerUserDto)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            var password = passwordHasher.GenerateSaltedHash(16, registerUserDto.Password);
            var new_user = new Users(registerUserDto.Name, registerUserDto.Surname,
              registerUserDto.Email, password.Hash, password.Salt,(RoleOfUser)Int32.Parse(registerUserDto.RoleOfUser));
            var check_user = await userRepository.FindByLoginAsync(registerUserDto.Email);
            if (check_user == null)
            {
                userRepository.Create(new_user);
                await userRepository.SaveChangesAsync();
                registerUserDto.CodeOfVerification = new_user.CodeOfVerification;
                emailService.EmailAfterRegistration(registerUserDto);
            }
            else
                return null;
            return mapper.Map<RegisterUserDto>(new_user);
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
        public async Task<TokenDto> SignIn(SignInDto signInDto)
        {
            var user = await userRepository.FindByLoginAsync(signInDto.Email);
            TokenDto tokenDto = new TokenDto();
            if (user == null||user.StatusOfVerification== "Processing"|| user.StatusOfVerification == "Blocked")
            {
                tokenDto.Code = 401;
                return tokenDto;
            }
            if (signInDto.Email != user.Email || !VerifyPassword(signInDto.Password, user.HashPassword, user.Salt))
            {
                tokenDto.Code = 401;
                return tokenDto;
            }
            //Return two tokens Access, Refresh
            tokenDto.Name = user.FirstName;
            tokenDto.Code = 200;
            tokenDto.AccessToken = token.GenerateToken(user);
            tokenDto.RefreshToken = token.RefreshGenerateToken();
            //Save To database Refresh token 
            RefreshTokens refreshToken = new RefreshTokens(tokenDto.RefreshToken, user.Id, true);
            refreshRepository.Create(refreshToken);
            await refreshRepository.SaveChangesAsync();
            return tokenDto;
        }
        public async Task<bool> SendLinkToResetPassword(SendEmailToReset email)
        {
            var user = await userRepository.FindByLoginAsync(email.Email);
            if (user == null)
            {
                return false;
            }
            emailService.ResetPassword(user.CodeOfVerification,email.Email);
            return true;
        }

        public async Task<bool> ResetPassword(string code , ResetPasswordDto resetPassword)
        {
            if (resetPassword.Password != resetPassword.ConfirmPassword)
            {
                return false;
            }
            var user = await userRepository.FindByCodeOfVerificationAsync(code);
            if (user == null)
            {
                return false;
            }
            PasswordHasher passwordHasher = new PasswordHasher();
            var hash_password = passwordHasher.GenerateSaltedHash(16, resetPassword.Password);
            user.HashPassword = hash_password.Hash;
            user.Salt = hash_password.Salt;
            user.CodeOfVerification = user.GetRandomString(128);
            userRepository.Update(user);
            await userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                userRepository.DeleteAccount(id);
                await userRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public  async Task<bool> ActiveAccount(int id)
        {
            try
            {
                userRepository.ActiveAccount(id);
                await userRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await userRepository.FindAllUsersAsync();
            if (users == null)
            {
                return null;
            }
            return users;
        }
    }
}
