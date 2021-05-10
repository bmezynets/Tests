using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.DAL.Repositories;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.FeedBack;

namespace TopTests.Services.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly ITestRepository testRepository;
        private readonly IFeedBackRepository feedBackRepository;
        public FeedBackService(ITestRepository testRepository,IFeedBackRepository feedBackRepository)
        {
            this.testRepository = testRepository;
            this.feedBackRepository = feedBackRepository;
        }
        public async Task<bool> AddFeedBack(AddFeedBack addFeedBack)
        {
            var test = await testRepository.GetTest(Int32.Parse(addFeedBack.TestId));
            var feedBack = new FeedBacks(test.Name,addFeedBack.UserId, Int32.Parse(addFeedBack.TestId), addFeedBack.Text, addFeedBack.Name, test.TeacherId) ;
            try
            {
                feedBackRepository.Create(feedBack);
                await feedBackRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Test>> GetFeedBacks(int Id)
        {
            var feedBacks = await feedBackRepository.GetFeedBacks(Id);
            if (feedBacks == null)
            {
                return null;
            }
            
            return feedBacks;
        }
    }
}
