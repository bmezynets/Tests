using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.Services.Models.CheckTest;

namespace TopTests.Services.Interfaces
{
    public interface ICheckTestService
    {
        Task<int> CheckTest(string id,List<ListOfTestQuestions> listOfTestQuestions);
        Task<int> GetResultOfTest(int userId);
        Task<List<ResultsTests>> GetResultsOfTest(int userId);

    }
}
