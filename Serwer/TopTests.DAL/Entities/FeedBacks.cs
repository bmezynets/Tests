using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
    public class FeedBacks:BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int TeacherId { get; set; }
        public string PostTime { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string TestName { get; set; }
        public Users Users { get; set; }
        public FeedBacks() { }
        public FeedBacks(string testName,int userId,int testId,string text,string name,int teacherId)
        {
            PostTime = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
            TestName = testName;
            UserId = userId;
            TestId = testId;
            Comment = text;
            Name = name;
            TeacherId = teacherId;
        }
    }
}
