using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;

namespace TopTests.DAL.Interfaces
{
    public interface IResultsRepository : IRepositoryBase<Results>
    {
        public Task<Results> GetResultOfTest(int userId);
        public Task<List<Results>> GetResultsOfTest(int userId);

    }
}
