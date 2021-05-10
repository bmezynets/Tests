using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
   public class TestQuestions
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        public string Question { get; set; }
        public string NumberOfIdentification { get; set; } = Guid.NewGuid().ToString();
        public TypeOfComplexity Complexity { get; set;}
        public bool isDelete { get; set; }
        public Test Tests { get; set; }
        public Subjects Subjects { get; set; }
        public TestQuestions() { }
        public TestQuestions(int testId,int subjectId,string question,int complexity)
        {
            TestId = testId;
            SubjectId = subjectId;
            Question = question;
            isDelete = false;
            Complexity = (TypeOfComplexity)complexity;
        }

    }
}
