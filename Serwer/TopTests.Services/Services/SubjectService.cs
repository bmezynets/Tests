using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Subjects;

namespace TopTests.Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly ITestQuestionRepository testQuestionRepository;
        private readonly IAnswersRepository answersRepository;
        private readonly ITestQuestionsService testQuestionsService;
        private readonly IMapper mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper,
                              ITestQuestionRepository testQuestionRepository,
                              IAnswersRepository answersRepository,ITestQuestionsService testQuestionsService)
        {
            this.subjectRepository = subjectRepository;
            this.mapper = mapper;
            this.testQuestionRepository = testQuestionRepository;
            this.answersRepository = answersRepository;
            this.testQuestionsService = testQuestionsService;
        }

        public async Task<EditSubjectDto> EditSubject(int id, EditSubjectDto editSubjectDto)
        {
            if (editSubjectDto == null)
            {
                return null;
            }
            var subject = await subjectRepository.GetSubjectById(id);
            if (subject == null)
            {
                return null;
            }
            subject.Name = editSubjectDto.Name;
            subjectRepository.Update(subject);
            await subjectRepository.SaveChangesAsync();
            return mapper.Map<EditSubjectDto>(subject);
        }

        public async Task<RegisterSubjectDto> RegisterSubject(RegisterSubjectDto registerSubject,int id)
        {
            if (registerSubject == null)
            {
                return null;
            }
            var subject = new Subjects(id,registerSubject.Name);
            subjectRepository.Create(subject);
            await subjectRepository.SaveChangesAsync();
            return mapper.Map<RegisterSubjectDto>(subject);
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var subject = await subjectRepository.GetSubjectById(id);
            subject.isDelete = true;
            if (subject == null)
            {
                return false;
            }
            testQuestionRepository.SetValueIsDeleteOnSubject(subject.Id);
            answersRepository.SetValueIsDeleteOnSubject(subject.Id);
            subjectRepository.Update(subject);
            await subjectRepository.SaveChangesAsync();
            await testQuestionRepository.SaveChangesAsync();
            await answersRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjects()
        {
            var subjects = await subjectRepository.GetSubjects();
            if (subjects == null)
            {
                return null;
            }
            return mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<IEnumerable<SubjectDto>> GetAllDeletedSubjects()
        {
            var subjects = await subjectRepository.GetDeleteSubjects();
            if (subjects == null)
            {
                return null;
            }
            return mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> RestoreSubject(int id)
        {
            var subject = await subjectRepository.GetDeleteSubjectById(id);
            if (subject == null)
            {
                return null;
            };
            subject.isDelete = false;
            subjectRepository.Update(subject);
            await subjectRepository.SaveChangesAsync();
            return mapper.Map<SubjectDto>(subject);
        }

        public async Task<List<Subjects>> GetAllSubjectsTests()
        {
            var subjectsTest = await subjectRepository.GetSubjectsTests();
            var completedTests = new List<Subjects>();
            foreach (var test in subjectsTest)
            {
                if (test.Tests.Count() != 0)
                {
                    List<Test> completed_questions = new List<Test>();
                    foreach (var tests in test.Tests)
                    {
                        var questions = await testQuestionsService.ShowTestQuestion(tests.Id);
                        if (questions.Count() != 0)
                        {
                            completed_questions.Add(tests);
                            //tests.
                        }
                    }
                    test.Tests = completed_questions;
                    //completed_questions.Clear();
                    completedTests.Add(test);
                }
            }
            //var completed_tests = new List<Test>();
            //foreach (var test in completedTests)
            //{
            //    test.Tests.Clear();
            //    foreach (var tests in test.Tests)
            //    {
            //        var questions = await testQuestionsService.ShowTestQuestion(tests.Id);
            //        if (questions.Count() != 0)
            //        {
            //            completedTests.Add(test);
            //        }
            //    }
            //}
            if (subjectsTest == null)
            {
                return null;
            }
            return completedTests;
        }

        public async Task<IEnumerable<SubjectDto>> GetTeacherSubjects(int id)
        {
            var subjects = await subjectRepository.GetTeachersSubjects(id);
            if (subjects == null)
            {
                return null;
            }
            return mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }
    }
}
