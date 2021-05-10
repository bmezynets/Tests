using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Testy;

namespace TopTests.Services.Services
{
    public class TestService : ITestService
    {
        private readonly IAnswersRepository answersRepository;
        private readonly ITestRepository testRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITestQuestionRepository testQuestionRepository;
        private readonly ITestQuestionsService testQuestionsService;

        public TestService(IAnswersRepository answersRepository, ITestQuestionRepository testQuestionRepository,
                          ITestRepository testRepository,ISubjectRepository subjectRepository, ITestQuestionsService testQuestionsService)
        {
            this.answersRepository = answersRepository;
            this.testQuestionRepository = testQuestionRepository;
            this.testRepository = testRepository;
            this.subjectRepository = subjectRepository;
            this.testQuestionsService = testQuestionsService;
        }
        public async Task<bool> DeleteTest(int id)
        {
            var test = await testRepository.GetTest(id);
            if (test == null)
            {
                return false;
            }
            test.isDelete = true;
            testQuestionRepository.SetValueIsDeleteOnTest(id);
            answersRepository.SetValueIsDeleteOnTest(id);
            testRepository.Update(test);
            await testRepository.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EditTest(int id, EditTestDto editTestDto)
        {
            var test = await testRepository.GetTest(id);
            if (test == null)
            {
                return false;
            }
            if (editTestDto.AutomaticCountTime == true)
            {
                var questions = await testQuestionRepository.GetAllTestQuestions(test.Id);
                test.TimeOfTest = 0;
                foreach(var question in questions)
                {
                    if ((int)question.Complexity == 3)
                    {
                        test.TimeOfTest += 5;
                    }else if((int)question.Complexity == 2)
                    {
                        test.TimeOfTest += 3;
                    }else if((int)question.Complexity == 1)
                    {
                        test.TimeOfTest += 1;
                    }
                }
                test.Name = editTestDto.Name;
                test.AdditionalInfo = editTestDto.AdditionalInfo;
                test.TypeOfTest = (TypeOfTest)Int32.Parse(editTestDto.TypeOfTest);
                test.AutomaticTime = editTestDto.AutomaticCountTime;
            }
            else
            {
                test.Name = editTestDto.Name;
                test.AdditionalInfo = editTestDto.AdditionalInfo;
                test.TimeOfTest = Int32.Parse(editTestDto.TimeOfTest);
                test.TypeOfTest = (TypeOfTest)Int32.Parse(editTestDto.TypeOfTest);
            }
            testRepository.Update(test);
            await testRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Test>> GetTeachersTests(string id)
        {
            var subject = await subjectRepository.GetSubjectById(Int32.Parse(id));
            var tests = await testRepository.GetTeachersTests(Int32.Parse(id),subject.TeacherId);
            if (tests == null)
            {
                return null;
            }
            return tests;
        }

        public async Task<IEnumerable<Test>> GetTests(string id)
        {
            var tests = await testRepository.GetTests(Int32.Parse(id));
            var completed_questions = new List<Test>();
            foreach (var test in tests)
            {
                var questions = await testQuestionsService.ShowTestQuestion(test.Id);
                if (questions.Count() != 0)
                {
                    completed_questions.Add(test);
                    //tests.
                }
            }
            if (tests == null)
            {
                return null;
            }
            return completed_questions;
        }

        public async Task<Test> RegisterTest(RegisterTestDto registerTestDto)
        {
            if (registerTestDto.Name == "")
            {
                return null;
            }
            var test = new Test();
            if (registerTestDto.AutomaticCountTime == false)
            {
                 test = new Test(Int32.Parse(registerTestDto.SubjectId), registerTestDto.AdditionalInfo, registerTestDto.Name
                                    , Int32.Parse(registerTestDto.TypeOfTest), registerTestDto.TimeOfTest, registerTestDto.TeacherId,registerTestDto.AutomaticCountTime);
            }
            else
            {
                test = new Test(Int32.Parse(registerTestDto.SubjectId), registerTestDto.AdditionalInfo, registerTestDto.Name
                                    , Int32.Parse(registerTestDto.TypeOfTest), "0", registerTestDto.TeacherId,registerTestDto.AutomaticCountTime);
            }
            testRepository.Create(test);
            await testRepository.SaveChangesAsync();
            return test;
        }

        public async Task<bool> RestoreTest(int id)
        {
            var test = await testRepository.RestoreTest(id);
            if (test == null)
            {
                return false;
            }
            testQuestionRepository.SetValueIsNotDeleteOnTest(id);
            answersRepository.SetValueIsNotDeleteOnTest(id);
            test.isDelete = false;
            testRepository.Update(test);
            await testRepository.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Test>> ShowAllDeletedTests()
        {
            var tests = testRepository.GetAllDeletedTests();
            if (tests == null)
            {
                return null;
            }
            return tests;
        }
    }
}

