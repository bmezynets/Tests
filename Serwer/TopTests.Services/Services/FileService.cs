using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Interfaces;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Files;
using System.Web;
using TopTests.DAL.Entities;
using System.IO;

namespace TopTests.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepository;
        private readonly IMapper mapper;
        public FileService(IFileRepository fileRepository,IMapper mapper)
        {
            this.fileRepository = fileRepository;
            this.mapper = mapper;
        }
        public async Task<DownloadFileDto> DownloadFile(int id)
        {
            var file = await fileRepository.FindByIdAsync(id);
            if (file == null)
            {
                return null;
            }
            var memory = new MemoryStream(file.FileContent);
            memory.Position = 0;
            return new DownloadFileDto { memory=memory,FileName= file.FileName };
        }

        public async Task<IEnumerable<FilesDto>> GetAllFiles()
        {   
            var files = await fileRepository.FindAllAsync();
            foreach(var f in files)
            if (files == null)
            {
                return null;
            }
            var map_files = mapper.Map<IEnumerable<FilesDto>>(files);
            return map_files;
        }
    }
}
