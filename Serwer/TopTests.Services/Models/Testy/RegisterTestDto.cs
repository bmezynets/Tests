using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Testy
{
   public class RegisterTestDto
    {
        public string Name { get; set; }
        public string SubjectId { get; set; }
        public string TimeOfTest { get; set; }
        public string AdditionalInfo { get; set; }
        public string TypeOfTest { get; set; }
        public int TeacherId { get; set; }
        public bool AutomaticCountTime { get; set; }
    }
}
