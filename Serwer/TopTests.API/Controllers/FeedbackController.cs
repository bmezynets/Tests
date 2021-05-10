using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.FeedBack;

namespace TopTests.API.Controllers
{
    [Route("api/feedBack")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedBackService feedBackService;
        private readonly ResourceManager resourceManager;

        public FeedbackController(IFeedBackService feedBackService)
        {
            this.feedBackService = feedBackService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        [HttpPost]
        public async Task<IActionResult> AddFeedBack(AddFeedBack addFeedBack)
        {
            if (! await feedBackService.AddFeedBack(addFeedBack))
            {
                return BadRequest(resourceManager.GetString("Bad"));
            }
            return Ok();
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedBacks(int id)
        {
            var feedBacks = await feedBackService.GetFeedBacks(id);
            if (feedBacks == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(feedBacks);
        }
    }
}