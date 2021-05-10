using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;

namespace TopTests.DAL.Repositories
{
    public class FileRepository:RepositoryBase<Files>, IFileRepository
    {
        public FileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
