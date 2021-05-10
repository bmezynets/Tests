using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.CheckTest;

namespace TopTests.Services.Services
{
    public class CheckTestService : ICheckTestService
    {
        private readonly ITestQuestionRepository testQuestionRepository;
        private readonly IAnswersRepository answersRepository;
        private readonly IResultsRepository resultsRepository;
        private readonly ITestRepository testRepository;
        public CheckTestService(ITestQuestionRepository testQuestionRepository, IAnswersRepository answersRepository,
            IResultsRepository resultsRepository, ITestRepository testRepository)
        {
            this.testQuestionRepository = testQuestionRepository;
            this.testRepository = testRepository;
            this.answersRepository = answersRepository;
            this.resultsRepository = resultsRepository;
        }
        public async Task<int> CountMaxScoreOfTest(List<ListOfTestQuestions> listOfTestQuestions)
        {
            var score = 0;
            for (var i = 0; i < listOfTestQuestions.Count; i++)
            {
                var question = await testQuestionRepository.GetQuestion(Int32.Parse(listOfTestQuestions[i].QuestionId));
                if ((int)question.Complexity == 1)
                {
                    score += 5;
                }
                else if ((int)question.Complexity == 2)
                {
                    score += 10;
                }
                else if ((int)question.Complexity == 3)
                {
                    score += 15;
                }
            }
            return score;
        }
        public async Task<int> CheckTest(string id, List<ListOfTestQuestions> listOfTestQuestions)
        {
            var score = 0;
            if (listOfTestQuestions == null)
            {
                return score;
            }
            var type_test = await testRepository.GetTest(Int32.Parse(id));
            var infoForResult = await testQuestionRepository.GetQuestion(Int32.Parse(listOfTestQuestions[0].QuestionId));
            var testName = await testRepository.GetTest(infoForResult.TestId);

            var maxScore = await CountMaxScoreOfTest(listOfTestQuestions);

            for (var i = 0; i < listOfTestQuestions.Count; i++)
            {
                var question = await testQuestionRepository.GetQuestion(Int32.Parse(listOfTestQuestions[i].QuestionId));
                if (question.Id == Int32.Parse(listOfTestQuestions[i].QuestionId))
                {
                    var answers = await answersRepository.GetAnswersForQuestion(question.NumberOfIdentification);
                    if ((int)type_test.TypeOfTest == 0)
                    {
                        if (listOfTestQuestions[i].isCorrectA == answers[0].isCorrect &&
                           listOfTestQuestions[i].isCorrectB == answers[1].isCorrect &&
                           listOfTestQuestions[i].isCorrectC == answers[2].isCorrect)
                        {
                            if ((int)question.Complexity == 1)
                            {
                                score += 5;
                            }
                            else if ((int)question.Complexity == 2)
                            {
                                score += 10;
                            }
                            else if ((int)question.Complexity == 3)
                            {
                                score += 15;
                            }

                        }
                       else if (listOfTestQuestions[i].isCorrectA == answers[0].isCorrect == true ||
                           listOfTestQuestions[i].isCorrectB == answers[1].isCorrect == true ||
                           listOfTestQuestions[i].isCorrectC == answers[2].isCorrect == true)
                        {
                            if ((int)question.Complexity == 1)
                            {
                                score += 2;
                            }
                            else if ((int)question.Complexity == 2)
                            {
                                score += 5;
                            }
                            else if ((int)question.Complexity == 3)
                            {
                                score += 7;
                            }
                        }
                    }
                    else if ((int)type_test.TypeOfTest == 1)
                    {
                        if (listOfTestQuestions[i].isCorrectA == answers[0].isCorrect &&
                           listOfTestQuestions[i].isCorrectB == answers[1].isCorrect &&
                           listOfTestQuestions[i].isCorrectC == answers[2].isCorrect)
                        {
                            if ((int)question.Complexity == 1)
                            {
                                score += 5;
                            }
                            else if ((int)question.Complexity == 2)
                            {
                                score += 10;
                            }
                            else if ((int)question.Complexity == 3)
                            {
                                score += 15;
                            }

                        }
                    }
                }
            }
            var result = new Results(Int32.Parse(listOfTestQuestions[0].UserId), infoForResult.TestId,
                                     infoForResult.SubjectId, (score * 100) / maxScore, testName.Name);
            resultsRepository.Create(result);
            await resultsRepository.SaveChangesAsync();
            return score;
        }

        public async Task<int> GetResultOfTest(int userId)
        {
            var result = await resultsRepository.GetResultOfTest(userId);

            return result.Rating;
        }

        public async Task<List<ResultsTests>> GetResultsOfTest(int userId)
        {
            var results = await resultsRepository.GetResultsOfTest(userId);
            var resultsOfTests = new List<ResultsTests>();
            foreach (var res in results)
            {
                ResultsTests resultsTests = new ResultsTests();
                resultsTests.dateTime = res.DateCreated.Day;
                resultsTests.month = res.DateCreated.Month;
                resultsTests.NameOfTest = res.TestName;
                resultsTests.Score = res.Rating.ToString();
                resultsOfTests.Add(resultsTests);
            }
            return resultsOfTests;
        }
    }
}
