using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;

namespace TopTests.DAL.Interfaces
{
    public interface ISubjectRepository : IRepositoryBase<Subjects>
    {
        Task<IEnumerable<Subjects>> GetSubjects();
        Task<IEnumerable<Subjects>> GetDeleteSubjects();
        Task<List<Subjects>> GetSubjectsTests();
        Task<Subjects> GetSubjectById(int id);
        Task<Subjects> GetDeleteSubjectById(int id);
        Task<IEnumerable<Subjects>> GetTeachersSubjects(int id);

    }
}
