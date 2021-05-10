using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using TopTests.Services.Models;

namespace TopTests.API.Controllers
{
    [Route("api/time")]
    [ApiController]
    public class TimerController : Controller
    {
        private readonly ITimeRemainingService timeRemainingService;
        private readonly ResourceManager resourceManager;

        public TimerController(ITimeRemainingService timeRemainingService)
        {
            this.timeRemainingService = timeRemainingService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);

        }
        [HttpPost]
        public async Task<IActionResult> RegisterTimeOfEndTest(SetTimeDto setTimeDto)
        {
            if (setTimeDto == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            var time = await timeRemainingService.RegisterTimeOfEndTest(setTimeDto);
            return Ok(time);
        }
        [HttpGet("timers")]
        public async Task<IActionResult> GetTime()
        {
            return Ok("Heyka");
        }
    }
}