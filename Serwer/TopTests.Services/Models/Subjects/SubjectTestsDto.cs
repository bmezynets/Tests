using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;

namespace TopTests.Services.Models.Subjects
{
   public class SubjectTestsDto
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Test> Tests { get; set; }
    }
}
