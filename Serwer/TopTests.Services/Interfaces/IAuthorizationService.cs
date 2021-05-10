using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.Services.Models.Tokens;
using TopTests.Services.Models.Users;

namespace TopTests.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<RegisterUserDto> RegisterUser(RegisterUserDto registerUserDto);
        Task<TokenDto> SignIn(SignInDto signInDto);
        Task<bool> ConfirmRegistration(string code);
        Task<bool> SendLinkToResetPassword(SendEmailToReset email);
        Task<bool> ResetPassword(string code, ResetPasswordDto resetPassword);
        Task<bool> DeleteAccount(int id);
        Task<bool> ActiveAccount(int id);
        Task<IEnumerable<Users>> GetUsers();
    }
}
