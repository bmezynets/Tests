using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;
using TopTests.Services.Models.Files;

namespace TopTests.Services.Mapper
{
   public class FileProfile:Profile
    {
        public FileProfile()
        {
            CreateMap<Files, FilesDto>();
        }
    }
}
