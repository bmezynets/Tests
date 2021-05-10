using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.CheckTest
{
    public class ListOfTestQuestions
    {
        public string QuestionId { get; set; }
        public string UserId { get; set; }
        public bool isCorrectA { get; set; }
        public bool isCorrectB { get; set; }
        public bool isCorrectC { get; set; } 
        
    }
}
