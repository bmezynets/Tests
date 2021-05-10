using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;

namespace TopTests.DAL.Interfaces
{
    public interface IRefreshRepository : IRepositoryBase<RefreshTokens>
    {
        public Task<RefreshTokens> FindByRefreshTokenAsync(string refresh);
    }
}
