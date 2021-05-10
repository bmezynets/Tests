using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.Services.Models.FeedBack;

namespace TopTests.Services.Interfaces
{
    public interface IFeedBackService
    {
        Task<bool> AddFeedBack(AddFeedBack addFeedBack);
        Task<List<Test>> GetFeedBacks(int subjectId);
    }
}
