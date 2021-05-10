using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TopTests.Services.Models.Files
{
   public class DownloadFileDto
    {
        public MemoryStream memory { get; set; }
        public string FileName { get; set; }
    }
}
