using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.TestQuestions
{
    public class EditQuestionDto
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public bool isCorrectA { get; set; }
        public bool isCorrectB { get; set; }
        public bool isCorrectC { get; set; }
    }
}
