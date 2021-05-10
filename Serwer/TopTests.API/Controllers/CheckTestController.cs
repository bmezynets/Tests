using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.CheckTest;
#nullable enable
namespace TopTests.API.Controllers
{
    [Route("api/checkTest")]
    [ApiController]
    public class CheckTestController : Controller
    {
        private readonly ICheckTestService checkTestService;
        public CheckTestController(ICheckTestService checkTestService)
        {
            this.checkTestService = checkTestService;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> CheckTest(string id,List<ListOfTestQuestions> listOfTestQuestions)
        {
            var resultTest = await checkTestService.CheckTest(id, listOfTestQuestions);
            return Ok(resultTest);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetResultOfTest(string userId)
        {
                var result = await checkTestService.GetResultOfTest(Int32.Parse(userId));
            
           
            return Ok(result);
        }
        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetResults(string userId)
        {
            var result = await checkTestService.GetResultsOfTest(Int32.Parse(userId));


            return Ok(result);
        }
    }
}