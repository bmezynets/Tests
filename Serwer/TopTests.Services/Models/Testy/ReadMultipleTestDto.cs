using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Testy
{
    public class ReadMultipleTestDto
    {
        public string NumberOfQuestion { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }

        public string Complexity { get; set; }
    }
}
