using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
   public class Results:BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int SubjectId { get; set; }
        public int Rating { get; set; }
        public Users Users { get; set; }
        public Subjects Subjects { get; set; }

        public Results() { }
        public Results(int userId,int testId,int subjectId,int score,string testName)
        {
            DateCreated = DateTime.Now;
            UserId = userId;
            TestId = testId;
            SubjectId = subjectId;
            Rating = score;
            TestName = testName;
        }
    }
}
