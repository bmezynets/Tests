using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.Services.Models.Testy;

namespace TopTests.Services.Interfaces
{
    public interface ITestService
    {
        Task<Test> RegisterTest(RegisterTestDto registerTestDto);
        Task<bool> DeleteTest(int id);
        Task<bool> EditTest(int id, EditTestDto editTestDto);
        Task<IEnumerable<Test>> GetTests(string id);
        Task<IEnumerable<Test>> GetTeachersTests(string id);
        Task<bool> RestoreTest(int id);
        Task<IEnumerable<Test>> ShowAllDeletedTests();
    }
}
