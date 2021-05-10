using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;

namespace TopTests.DAL.Repositories
{
    public class RefreshRepository : RepositoryBase<RefreshTokens>, IRefreshRepository
    {
        public RefreshRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }

        public async Task<RefreshTokens> FindByRefreshTokenAsync(string refresh)
        {
            return await context.Set<RefreshTokens>()
                .Where(e => e.IsValid == true)
                .FirstOrDefaultAsync(e => e.Refresh == refresh);
        }
    }
}
