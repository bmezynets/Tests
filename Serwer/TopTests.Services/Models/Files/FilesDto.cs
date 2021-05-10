using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TopTests.Services.Models.Files
{
    public class FilesDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public MemoryStream Memory { get; set; }
        public int TypeOfTest { get; set; }
    }
}
