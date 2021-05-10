using AutoMapper;
using TopTests.DAL.Entities;
using TopTests.Services.Models.Subjects;

namespace TopTests.Services.Mapper
{
   public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subjects, RegisterSubjectDto>();
            CreateMap<Subjects, EditSubjectDto>();
            CreateMap<Subjects, SubjectDto>();
        }
    }
}
