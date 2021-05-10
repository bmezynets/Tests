using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;

namespace TopTests.DAL.Repositories
{
    public class TestQuestionsRepository : RepositoryBase<TestQuestions>, ITestQuestionRepository
    {
        public TestQuestionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void AddTestsQuestions(List<TestQuestions> testQuestions)
        {
            context.Set<TestQuestions>().AddRange(testQuestions);
            context.SaveChanges();
        }
        public void SetValueIsDeleteOnSubject(int id)
        {
            context.Set<TestQuestions>()
                .Where(e => e.SubjectId == id)
                .ToList()
                .ForEach(c => c.isDelete = true);
        }
        public void SetValueIsDeleteOnTest(int id)
        {
            context.Set<TestQuestions>()
                .Where(e => e.TestId == id)
                .ToList()
                .ForEach(c => c.isDelete = true);
        }
        public void SetValueIsNotDeleteOnTest(int id)
        {
            context.Set<TestQuestions>()
                .Where(e => e.TestId == id)
                .ToList()
                .ForEach(c => c.isDelete = false);
        }
        public async Task<TestQuestions> CheckIfQuestionExist(TestQuestions testQuestions)
        {
            return await context.Set<TestQuestions>()
                .FirstOrDefaultAsync(e => e.Question == testQuestions.Question&&e.isDelete==false);
        }

        public async Task<TestQuestions> GetQuestion(int id)
        {
            return await context.Set<TestQuestions>()
                .Where(e => e.isDelete == false)
                .FirstOrDefaultAsync(e => e.Id == id);
                
        }
        public async Task<IEnumerable<TestQuestions>>GetAllTestQuestions(int TestId)
        {
            return await context.Set<TestQuestions>()
                   .Where(e => e.isDelete == false&&e.TestId==TestId)
                   .ToListAsync();
                   
        }

        public async Task<TestQuestions> RestoreQuestion(int id)
        {
            return await context.Set<TestQuestions>()
                .Where(e => e.isDelete == true)
                .FirstOrDefaultAsync(e => e.Id == id);
                
        }

        public async Task<IEnumerable<TestQuestions>> GetAllDeletedTestQuestions(int id)
        {
            return await context.Set<TestQuestions>()
               .Where(e => e.isDelete == true&&e.TestId==id)
               .ToListAsync();           
        }
    }
}
