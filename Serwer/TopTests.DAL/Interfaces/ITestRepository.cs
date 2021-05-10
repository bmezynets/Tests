using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;

namespace TopTests.DAL.Interfaces
{
    public interface ITestRepository : IRepositoryBase<Test>
    {
        Task<Test> GetTest(int id);
        Task<IEnumerable<Test>> GetTests(int id);
        Task<IEnumerable<Test>> GetTeachersTests(int id,int teacherId);
        Task<Test> RestoreTest(int id);
        Task<IEnumerable<Test>> GetAllDeletedTests();
    }
}
