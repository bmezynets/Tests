using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.Services.Models.Files;

namespace TopTests.Services.Interfaces
{
    public interface IFileService
    {
        Task<DownloadFileDto> DownloadFile(int id);
        Task<IEnumerable<FilesDto>> GetAllFiles();
    }
}
