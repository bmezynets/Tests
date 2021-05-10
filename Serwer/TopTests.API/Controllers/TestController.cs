using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TopTests.API.Resources;
using TopTests.DAL.Entities;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Testy;

namespace TopTests.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly ITestService testService;
        private readonly ResourceManager resourceManager;
        public TestController(ITestService testService,ITestQuestionsService testQuestionsService)
        {
            this.testService = testService;
           // this.testQuestionsService = testQuestionsService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost("register/{id}")]
        public async Task<IActionResult> Register(int id,RegisterTestDto registerTestDto)
        {
            registerTestDto.TeacherId = id;
            var test = await testService.RegisterTest(registerTestDto);
            if (test == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(test);
        }
        [Authorize(Roles = "Teacher")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            if (!await testService.DeleteTest(id))
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [Authorize(Roles = "Teacher")]
        [HttpPatch("editTest")]
        public async Task<IActionResult> EditTest(EditTestDto editTestDto)
        {
            if(!await testService.EditTest(Int32.Parse(editTestDto.Id), editTestDto))
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTests(string id)
        {
            var tests = await testService.GetTests(id);
            if (tests == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(tests);
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet("teachersTests/{id}")]
        public async Task<IActionResult> GetTeachersTests(string id)
        {
            var tests = await testService.GetTeachersTests(id);
            if (tests == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(tests);
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedQuestions()
        {
            var questions = await testService.ShowAllDeletedTests();
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
            if (!await testService.RestoreTest(id))
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok();
        }
    }
}