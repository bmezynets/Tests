using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;

namespace TopTests.DAL.Interfaces
{
   public interface ITimeRemainingRepository:IRepositoryBase<TimeRemainingOfTest>
    {
        public TimeRemainingOfTest GetTimetOfTest(int userId);

    }
}
