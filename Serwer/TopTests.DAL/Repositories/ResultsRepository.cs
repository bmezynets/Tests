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
    public class ResultsRepository : RepositoryBase<Results>, IResultsRepository
    {
        public ResultsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Results> GetResultOfTest(int userId)
        {
            return await context.Set<Results>().OrderByDescending(e=>e.Id)
                .FirstOrDefaultAsync(e => e.UserId == userId);
                
        }

        public async Task<List<Results>> GetResultsOfTest(int userId)
        {
            return await context.Set<Results>()
                .OrderByDescending(e => e.DateCreated)
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }
    }
}
