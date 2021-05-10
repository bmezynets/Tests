using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.TestQuestions;
using TopTests.Services.Models.Testy;

namespace TopTests.API.Controllers
{
    [Route("api/testQuestion")]
    [ApiController]
    public class TestQuestionController : Controller
    {
        private readonly ITestQuestionsService testQuestionService;
        private readonly ResourceManager resourceManager;
        public TestQuestionController(ITestQuestionsService testService)
        {
            this.testQuestionService = testService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost("{id}")]
        public async Task<IActionResult> ReadTestQuestions(string id,[FromForm]UploadFile uploadFile)
        {
            var testQuestions = await testQuestionService.ReadTestQuestions(Int32.Parse(id) , uploadFile);
            if (testQuestions.FieldEmpty == 400)
            {
                return BadRequest(resourceManager.GetString("FieldEmpty"));
            }
            if (testQuestions.QuestionExist == 400)
            {
                return BadRequest(resourceManager.GetString("QuestionExist"));
            }
            return Ok();
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost("addTestQuestion")]
        public async Task<IActionResult> AddTestQuestion(RegisterTestQuestionDto registerTestQuestionDto)
        {
                var testQuestions = await testQuestionService.RegisterTestQuestion(registerTestQuestionDto);
            if (testQuestions == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [Authorize(Roles = "Teacher")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        { 
            var question = await testQuestionService.DeleteTestQuestion(id);
            if (question == false)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [Authorize(Roles = "Teacher")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> EditQuestion(string id,EditQuestionDto editQuestionDto)
        {
            var question = await testQuestionService.EditTestQuestion(Int32.Parse(id),editQuestionDto);
            if (question == false)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ShowTest(int id)
        {
            var test = await testQuestionService.ShowTestQuestion(id);
            if (test == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(test);
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet("deletedQuestions/{id}")]
        public async Task<IActionResult> GetAllDeletedQuestions(int id)
        {
            var questions = await testQuestionService.ShowAllDeletedTestQuestions(id);
            if (questions == null)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok(questions);
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet("restore/{id}")]
        public async Task<IActionResult> RestoreQuestion(int id)
        {
            if(!await testQuestionService.RestoreTestQuestion(id))
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [HttpGet("getQuestion/{id}")]
        public  async Task<IActionResult> GetTestQuestion(string id)
        {
            var testQuestion = await testQuestionService.GetTestQuestion(Int32.Parse(id));
            if (testQuestion == null)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok(testQuestion);
        }
    }
}