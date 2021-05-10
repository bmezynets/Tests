using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Testy
{
    public class EditTestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TypeOfTest { get; set; }
        public string TimeOfTest { get; set; }
        public string AdditionalInfo { get; set; }
        public bool AutomaticCountTime { get; set; }
    }
}
