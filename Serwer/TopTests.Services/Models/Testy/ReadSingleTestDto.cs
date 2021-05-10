using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;

namespace TopTests.Services.Models.Testy
{
    public class ReadSingleTestDto
    {
        public string NumberOfQuestion { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string Answer { get; set; }
        public string Complexity { get; set; }
    }
}
