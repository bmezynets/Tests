using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.TestQuestions
{
   public  class RegisterTestQuestionDto
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public bool isCorrectOptionA { get; set; }
        public bool isCorrectOptionB { get; set; }
        public bool isCorrectOptionC { get; set; }
        public string TypeOfQuestion { get; set; }
        public string SubjectId { get; set; }
        public string TopicId { get; set; }
        public string TestId { get; set; }
    }
}
