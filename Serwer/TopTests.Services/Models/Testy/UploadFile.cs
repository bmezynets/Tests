using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Testy
{
   public class UploadFile
    {
        public int SubjectId { get; set; }
        public IFormFile formFile { get; set; }
    }
}
