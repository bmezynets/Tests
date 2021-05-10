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
using TopTests.Services.Models.TestQuestions;
using TopTests.Services.Models.Testy;

namespace TopTests.Services.Services
{
    public class TestQuestionsService : ITestQuestionsService
    {
        private readonly IAnswersRepository answersRepository;
        private readonly ITestRepository testRepository;
        private readonly ITestQuestionRepository testQuestionRepository;
        public TestQuestionsService(IAnswersRepository answersRepository,
                           ITestQuestionRepository testQuestionRepository, ITestRepository testRepository)
        {
            this.answersRepository = answersRepository;
            this.testQuestionRepository = testQuestionRepository;
            this.testRepository = testRepository;
        }

        public async Task<bool> DeleteTestQuestion(int id)
        {
            var test_question = await testQuestionRepository.GetQuestion(id);
            var test = await testRepository.GetTest(test_question.TestId);
            var question = await testQuestionRepository.GetQuestion(id);
            if (question == null)
            {
                return false;
            }
            if ((int)test_question.Complexity == 3)
            {
                test.TimeOfTest -= 5;
            }else if((int)test_question.Complexity == 2)
            {
                test.TimeOfTest -= 3;
            }
            else if((int)test_question.Complexity == 1)
            {
                test.TimeOfTest -= 1;
            }
            question.isDelete = true;
            testRepository.Update(test);
            await testRepository.SaveChangesAsync();
            answersRepository.SetValueIsDeleteOnQuestion(question.NumberOfIdentification);
            testQuestionRepository.Update(question);
            await testQuestionRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditTestQuestion(int id, EditQuestionDto editQuestionDto)
        {
            var question = await testQuestionRepository.GetQuestion(id);
            question.Question = editQuestionDto.Question;
            var answers = await answersRepository.GetAnswersForQuestion(question.NumberOfIdentification);
            List<string> editAnswers = new List<string>();
            editAnswers.Add(editQuestionDto.OptionA);
            editAnswers.Add(editQuestionDto.OptionB);
            editAnswers.Add(editQuestionDto.OptionC);
            List<bool> correctAnswer = new List<bool>();
            correctAnswer.Add(editQuestionDto.isCorrectA);
            correctAnswer.Add(editQuestionDto.isCorrectB);
            correctAnswer.Add(editQuestionDto.isCorrectC);
            for (int i = 0; i < editAnswers.Count; i++)
            {
                answers[i].Option = editAnswers[i];
                answers[i].isCorrect = correctAnswer[i];
            }
            if (question == null || editQuestionDto.Question == "")
            {
                return false;
            }
            testQuestionRepository.Update(question);
            await testQuestionRepository.SaveChangesAsync();
            return true;
        }
        public async Task<ErrorTestDto> ReadTestQuestions(int id, UploadFile uploadFile)
        {
            var type_test = await testRepository.GetTest(id);
            var error = new ErrorTestDto();
            if ((int)type_test.TypeOfTest == 0)
            {
                error = await ReadMultipleTestQuestions(id, uploadFile);
            }
            if ((int)type_test.TypeOfTest == 1)
            {
                error = await ReadSingleTestQuestions(id, uploadFile);
            }
            return error;
        }

        public async Task<ErrorTestDto> ReadSingleTestQuestions(int id, UploadFile uploadFile)
        {
            ErrorTestDto errorTestDto = new ErrorTestDto();
            var files = uploadFile.formFile;
            var list_testQuestion = new List<TestQuestions>();
            var list_answer = new List<Answers>();
            var options = new List<string>();
            var test = await testRepository.GetTest(id);
            CultureInfo culture1 = CultureInfo.CurrentCulture;
            using (TextReader reader = new StreamReader(files.OpenReadStream(), Encoding.UTF8))
            using (var csv = new CsvReader(reader, culture1))
            {
                foreach (var i in csv.GetRecords<ReadSingleTestDto>())
                {
                    if (i.Question == "" || i.OptionA == "" ||
                        i.OptionB == "" || i.OptionC == "" ||
                        i.Answer == "" || i.Complexity == "")
                    {
                        errorTestDto.FieldEmpty = 400;
                        return errorTestDto;
                    }
                    if(Int32.Parse(i.Complexity)<1&& Int32.Parse(i.Complexity) > 3)
                    {
                        errorTestDto.FieldEmpty = 400;
                        return errorTestDto;
                    }
                    if (test.AutomaticTime == true)
                    {
                        var testTime = 0;
                        if (i.Complexity == "1")
                        {
                            testTime += 1;
                        }else if (i.Complexity == "2")
                        {
                            testTime += 3;
                        }else if(i.Complexity == "3")
                        {
                            testTime += 5;
                        }
                        test.TimeOfTest += testTime;
                        testRepository.Update(test);
                        await testRepository.SaveChangesAsync();
                    }
                    var testQuestion = new TestQuestions(test.Id, test.SubjectId, i.Question,Int32.Parse(i.Complexity));
                    ///
                    list_testQuestion.Add(testQuestion);
                    options.Add(i.OptionA);
                    options.Add(i.OptionB);
                    options.Add(i.OptionC);
                    foreach (var answers in options)
                    {
                        if (answers == i.Answer)
                        {
                            var answer = new Answers(test.SubjectId, test.Id, testQuestion.NumberOfIdentification, answers, true);
                            list_answer.Add(answer);
                        }
                        else
                        {
                            var answer = new Answers(test.SubjectId, test.Id, testQuestion.NumberOfIdentification, answers, false);
                            list_answer.Add(answer);
                        }
                    }
                    options = new List<string>();

                }
                if (list_testQuestion.Count == 0)
                {
                    errorTestDto.FieldEmpty = 400;
                    return errorTestDto;
                }
                testQuestionRepository.AddTestsQuestions(list_testQuestion);
                answersRepository.SaveAnswers(list_answer);
                
                return errorTestDto;
            }

        }
        public async Task<ErrorTestDto> ReadMultipleTestQuestions(int id, UploadFile uploadFile)
        {
            ErrorTestDto errorTestDto = new ErrorTestDto();
            var files = uploadFile.formFile;
            var list_testQuestion = new List<TestQuestions>();
            var list_answer = new List<Answers>();
            var options = new List<string>();
            var test = await testRepository.GetTest(id);
            CultureInfo culture1 = CultureInfo.CurrentCulture;
            using (TextReader reader = new StreamReader(files.OpenReadStream(), Encoding.UTF8))
            using (var csv = new CsvReader(reader, culture1))
            {
                foreach (var i in csv.GetRecords<ReadMultipleTestDto>())
                {
                    if (i.Question == "" || i.OptionA == "" ||
                        i.OptionB == "" || i.OptionC == "" || i.Complexity == "" ||
                        i.FirstAnswer == "" || i.SecondAnswer == "" ||
                        i.ThirdAnswer == ""  )
                    {
                        errorTestDto.FieldEmpty = 400;
                        return errorTestDto;
                    }
                    if (test.AutomaticTime == true)
                    {
                        var testTime = 0;
                        if (i.Complexity == "1")
                        {
                            testTime += 1;
                        }
                        else if (i.Complexity == "2")
                        {
                            testTime += 3;
                        }
                        else if (i.Complexity == "3")
                        {
                            testTime += 5;
                        }
                        test.TimeOfTest += testTime;
                        testRepository.Update(test);
                        await testRepository.SaveChangesAsync();
                    }
                    var testQuestion = new TestQuestions(test.Id, test.SubjectId, i.Question,Int32.Parse(i.Complexity));
                    ///
                    list_testQuestion.Add(testQuestion);
                  
                    var answer_one = new Answers(test.SubjectId, test.Id, testQuestion.NumberOfIdentification, i.OptionA, bool.Parse(i.FirstAnswer));
                    list_answer.Add(answer_one);

                    var answer_two = new Answers(test.SubjectId, test.Id, testQuestion.NumberOfIdentification, i.OptionB, bool.Parse(i.SecondAnswer));
                    list_answer.Add(answer_two);

                    var answer_third = new Answers(test.SubjectId, test.Id, testQuestion.NumberOfIdentification, i.OptionC, bool.Parse(i.ThirdAnswer));
                    list_answer.Add(answer_third);

                    list_answer.Add(answer_one);
                    list_answer.Add(answer_two);
                    list_answer.Add(answer_third);
                }
                if (list_testQuestion.Count == 0)
                {
                    errorTestDto.FieldEmpty = 400;
                    return errorTestDto;
                }
                testQuestionRepository.AddTestsQuestions(list_testQuestion);
                answersRepository.SaveAnswers(list_answer);
                return errorTestDto;
            }

        }
        public async Task<RegisterTestQuestionDto> RegisterTestQuestion(RegisterTestQuestionDto registerTestQuestionDto)
        {
            if (registerTestQuestionDto == null)
            {
                return null;
            }
            var test = await testRepository.GetTest(Int32.Parse(registerTestQuestionDto.TestId));
            if (test != null && test.AutomaticTime == true)
            {
                if (Int32.Parse(registerTestQuestionDto.TypeOfQuestion) == 3)
                {
                    test.TimeOfTest += 5;
                }else if(Int32.Parse(registerTestQuestionDto.TypeOfQuestion) == 2)
                {
                    test.TimeOfTest += 3;
                }else if(Int32.Parse(registerTestQuestionDto.TypeOfQuestion) == 1)
                {
                    test.TimeOfTest += 1;
                }
            }
            var testQuestion = new TestQuestions(Int32.Parse(registerTestQuestionDto.TestId),
                                                 Int32.Parse(registerTestQuestionDto.SubjectId), registerTestQuestionDto.Question
                                                 ,Int32.Parse(registerTestQuestionDto.TypeOfQuestion));
            List<bool> isCorrect = new List<bool>();
            isCorrect.Add(registerTestQuestionDto.isCorrectOptionA);
            isCorrect.Add(registerTestQuestionDto.isCorrectOptionB);
            isCorrect.Add(registerTestQuestionDto.isCorrectOptionC);
            List<string> option = new List<string>();
            option.Add(registerTestQuestionDto.OptionA);
            option.Add(registerTestQuestionDto.OptionB);
            option.Add(registerTestQuestionDto.OptionC);
            List<Answers> answers = new List<Answers>();
            for (int i = 0; i < 3; i++)
            {
                answers.Add(new Answers(Int32.Parse(registerTestQuestionDto.SubjectId),
                                            Int32.Parse(registerTestQuestionDto.TestId), testQuestion.NumberOfIdentification,
                                             option[i], isCorrect[i]));
            }
            testQuestionRepository.Create(testQuestion);
            answersRepository.SaveAnswers(answers);
            testRepository.Update(test);
            await testRepository.SaveChangesAsync();
            await testQuestionRepository.SaveChangesAsync();
            return registerTestQuestionDto;
        }

        public async Task<bool> RestoreTestQuestion(int id)
        {
            var question = await testQuestionRepository.RestoreQuestion(id);
            if (question == null)
            {
                return false;
            }
            var test = await testRepository.GetTest(question.TestId);
            if (test.AutomaticTime == true)
            {
                test.TimeOfTest += (int)question.Complexity;
            }
            question.isDelete = false;
            answersRepository.SetValueIsNotDeleteOnQuestion(question.NumberOfIdentification);
            testQuestionRepository.Update(question);
            await testQuestionRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ShowTestQuestionAnswers>> ShowAllDeletedTestQuestions(int TestId)
        {
            var test = await testRepository.GetTest(TestId);
            if (test == null)
            {
                return null;
            }
            var list = new List<ShowTestQuestionAnswers>();
            if (test == null)
            {
                return null;
            }
            var questions = await testQuestionRepository.GetAllDeletedTestQuestions(TestId);
            if (questions == null)
            {
                return null;
            }
            foreach (var testQuestion in questions)
            {
                ShowTestQuestionAnswers show = new ShowTestQuestionAnswers();
                show.QuestionId = testQuestion.Id.ToString();
                show.Question = testQuestion.Question;
                var answers = await answersRepository.GetDeletedAnswersForQuestion(testQuestion.NumberOfIdentification);
                if (answers == null)
                {
                    return null;
                }
                foreach (var listAnswers in answers)
                {
                    show.Option.Add(listAnswers);
                }
                list.Add(show);
            }
            return list;
        }

        public async Task<IEnumerable<ShowTestQuestionAnswers>> ShowTestQuestion(int TestId)
        {
            var test = await testRepository.GetTest(TestId);
            if (test == null)
            {
                return null;
            }
            var list = new List<ShowTestQuestionAnswers>();
            if (test == null)
            {
                return null;
            }
            var questions = await testQuestionRepository.GetAllTestQuestions(TestId);
            if (questions == null)
            {
                return null;
            }
            foreach (var testQuestion in questions)
            {
                ShowTestQuestionAnswers show = new ShowTestQuestionAnswers();
                show.QuestionId = testQuestion.Id.ToString();
                show.Question = testQuestion.Question;
                var answers = await answersRepository.GetAnswersForQuestion(testQuestion.NumberOfIdentification);
                if (answers == null)
                {
                    return null;
                }
                foreach (var listAnswers in answers)
                {
                    show.Option.Add(listAnswers);
                }
                list.Add(show);
            }
            return list;
        }

        public async Task<EditQuestionDto> GetTestQuestion(int questionId)
        {
            var testQuestion = await testQuestionRepository.GetQuestion(questionId);
            var answers = await answersRepository.GetAnswersForQuestion(testQuestion.NumberOfIdentification);
            if (testQuestion == null || answers == null)
            {
                return null;
            }
            var editModel = new EditQuestionDto()
            {
                Question = testQuestion.Question,
                OptionA = answers[0].Option,
                OptionB = answers[1].Option,
                OptionC = answers[2].Option,
                isCorrectA = answers[0].isCorrect,
                isCorrectB = answers[1].isCorrect,
                isCorrectC = answers[2].isCorrect
            };
            return editModel;
        }
    }
}
