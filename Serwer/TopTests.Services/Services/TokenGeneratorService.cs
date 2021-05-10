using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TopTests.DAL.Entities;
using TopTests.Services.Interfaces;

namespace TopTests.Services.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        /// <summary>
        /// It's function to generate Access token and return string
        /// </summary>
        public TokenGeneratorService() { }
        public string GenerateToken(Users _user)
        {
            var claims = new List<Claim> {
                     new Claim(ClaimTypes.Email,_user.Email),
                     new Claim(ClaimTypes.Hash , _user.HashPassword),
                     new Claim(ClaimTypes.Role,_user.RoleOfUser.ToString()),
                     new Claim(JwtRegisteredClaimNames.Sub,_user.Id.ToString()),
                     new Claim(ClaimTypes.Name,_user.FirstName)
            };
            var jwt = new JwtSecurityToken(
                  issuer: TokenOptions.ISSUER,
                  audience: TokenOptions.AUDIENCE,
                  claims: claims,
                  expires: DateTime.UtcNow.AddMinutes(TokenOptions.LIFETIME),
                  signingCredentials: new SigningCredentials(TokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
        /// <summary>
        /// It's function to generate refresh token
        /// </summary>
        /// <returns></returns>
        public string RefreshGenerateToken()
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[128];
                rng.GetBytes(tokenData);
                var refresh = Convert.ToBase64String(tokenData);
                return refresh;
            }

        }
    }
}
