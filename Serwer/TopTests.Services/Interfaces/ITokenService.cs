using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.Services.Models.Tokens;

namespace TopTests.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenClaimsDto> CheckAccessRefreshTokenAsync(string refresh);
        Task<TokenDto> GenerateRefreshTokenAsync(TokenClaimsDto token);
        Task<TokenDto> SaveRefreshTokenAsync(int id, string refreshtoken, bool isvalid);
    }
}
