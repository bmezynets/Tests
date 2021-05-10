using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.Services.Interfaces;
using TopTests.Services.Models;

namespace TopTests.Services.Services
{
    public class TimeRemainingService : ITimeRemainingService
    {
        private readonly ITimeRemainingRepository timeRemainingRepository;
        private readonly ITestRepository testRepository;

        public TimeRemainingService(ITimeRemainingRepository timeRemainingRepository, ITestRepository testRepository)
        {
            this.timeRemainingRepository = timeRemainingRepository;
            this.testRepository = testRepository;
        }
        public async Task<bool> RegisterTimeOfEndTest(SetTimeDto setTimeDto)
        {
            var test = await testRepository.GetTest(Int32.Parse(setTimeDto.TestId));

            var timeRemaining = new TimeRemainingOfTest(setTimeDto.UserId, Int32.Parse(setTimeDto.TestId), test.TimeOfTest);
            timeRemainingRepository.Create(timeRemaining);
            await timeRemainingRepository.SaveChangesAsync();

            return true;
        }
    }
}
