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
   public class FeedBacksRepository: RepositoryBase<FeedBacks>, IFeedBackRepository
    {
        public FeedBacksRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Test>> GetFeedBacks(int id)
        {
            // return await context.Set<FeedBacks>()
             //   .OrderByDescending(e=>e.Id)
              //  .Where(e => e.TeacherId == id)
               // .ToListAsync();
            var tests = await (from pd in context.Tests.Where(e => e.isDelete == false&&e.TeacherId==id)
                                      join od in context.FeedBacks on pd.TeacherId equals od.TeacherId
                                      orderby pd.Id
                                      select new Test
                                      (
                                          pd.Id,
                                          pd.Name,
                                          context.FeedBacks.Where(e=>e.TestId==pd.Id) as List<FeedBacks>
                                      )
                              ).Distinct().ToListAsync();
            return tests;
        }
    }
}
