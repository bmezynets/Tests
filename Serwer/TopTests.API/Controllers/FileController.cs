
  
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using System.Text;
using TopTests.Services.Models.Files;

namespace TopTests.API.Controllers
{
    [Route("api/testsFile")]
    [ApiController]
    public class FileController : Controller
    {
        public HttpStatusCode statusCode;

        private readonly IFileService fileService;
        private readonly ResourceManager resourceManager;
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var downloadFile = await fileService.DownloadFile(id);
            if (downloadFile == null)
                return Content("filename not present");
           //  return File(downloadFile.memory, "application/vnd.ms-excel", "MultipleOfChoiseTest");
           var file = File(downloadFile.memory, "application/vnd.ms-excel", downloadFile.FileName);
            //file.FileDownloadName = downloadFile.FileName;
            return file;
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await fileService.GetAllFiles();
            if (files == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(files);
        }
    }
}
