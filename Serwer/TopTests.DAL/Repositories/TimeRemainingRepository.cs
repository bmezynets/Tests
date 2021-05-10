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
    public class TimeRemainingRepository:RepositoryBase<TimeRemainingOfTest>, ITimeRemainingRepository
    {
        public TimeRemainingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public TimeRemainingOfTest GetTimetOfTest(int userId)
        {
            return  context.Set<TimeRemainingOfTest>().OrderByDescending(e => e.Id)
                .FirstOrDefault(e => e.UserId == userId);

        }
    }
}
