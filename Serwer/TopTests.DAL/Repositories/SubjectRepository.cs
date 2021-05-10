using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;

namespace TopTests.DAL.Repositories
{
    public class SubjectRepository : RepositoryBase<Subjects>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Subjects> GetSubjectById(int id)
        {
            return await context.Set<Subjects>()
                .Where(e => e.isDelete == false)
                .FirstOrDefaultAsync(e => e.Id == id);
                
        }

        public async Task<IEnumerable<Subjects>> GetSubjects()
        {
            return await context.Set<Subjects>()
                 .Where(e => e.isDelete == false)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Subjects>> GetTeachersSubjects(int id)
        {
            return await context.Set<Subjects>()
                 .Where(e => e.isDelete == false&&e.TeacherId==id)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Subjects>> GetDeleteSubjects()
        {
            return await context.Set<Subjects>()
                 .Where(e => e.isDelete == true)
                 .ToListAsync();
        }

        public async Task<Subjects> GetDeleteSubjectById(int id)
        {
            return await context.Set<Subjects>()
            .Where(e => e.isDelete == true)
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Subjects>> GetSubjectsTests()
        {
            var subjectsTest = await (from pd in context.Subjects.Where(e => e.isDelete == false)
                                join od in context.Tests on pd.Id equals od.SubjectId
                                orderby pd.Id
                                select new Subjects
                                (
                                    pd.Id,
                                    pd.Name,
                                    context.Tests.Where(e => e.isDelete == false && e.SubjectId == pd.Id) as List<Test>
                                )
                               ).Distinct().ToListAsync();
            return subjectsTest;
        }
    }
}
