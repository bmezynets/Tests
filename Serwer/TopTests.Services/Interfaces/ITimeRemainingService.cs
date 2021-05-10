using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.Services.Models;

namespace TopTests.Services.Interfaces
{
    public interface ITimeRemainingService
    {
        Task<bool> RegisterTimeOfEndTest(SetTimeDto setTimeDto);
      //  Task<int> RemainingTime();
    }
}
