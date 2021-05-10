using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
   public class TimeRemainingOfTest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public DateTime StartTest { get; set; }
        public DateTime EndTest { get; set; }
        public Users Users { get; set; }
        public Test Test { get; set; }
        public TimeRemainingOfTest() { }
        public TimeRemainingOfTest(int userId,int testId , int timeOfTest)
        {
            UserId = userId;
            TestId = testId;
            StartTest = DateTime.Now;
            EndTest = StartTest.AddMinutes(timeOfTest);
        }
    }
}





