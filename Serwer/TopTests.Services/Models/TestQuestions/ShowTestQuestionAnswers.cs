using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;

namespace TopTests.Services.Models.TestQuestions
{
   public class ShowTestQuestionAnswers
    {
        public string QuestionId { get; set; }
        public string Question { get; set; }
        public List<Answers> Option { get; set; } = new List<Answers>();
    }
}
