using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;

namespace TopTests.Services.Interfaces
{
   public interface ITokenGeneratorService
    {
        string GenerateToken(Users user);
        string RefreshGenerateToken();
    }
}
