using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Users;

namespace TopTests.API.Controllers
{
    [Route("api/authorize")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly Services.Interfaces.IAuthorizationService authorizationService;
        private readonly ResourceManager resourceManager;
        public AuthorizationController(Services.Interfaces.IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            var user = await authorizationService.RegisterUser(registerUserDto);
            if (user == null)
            {
                return BadRequest(resourceManager.GetString("EmailExiciting"));
            }
            return Ok(user);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> ConfirmRegistration(string id)
        {
            if (!await authorizationService.ConfirmRegistration(id))
            {
                return NotFound(resourceManager.GetString("CodeBad"));
            }
            return Ok();
        }
        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var signInResult = await authorizationService.SignIn(signInDto);
            if (signInResult.Code == (int)HttpStatusCode.Unauthorized)
            {
                return Unauthorized(resourceManager.GetString("EmailPassword"));
            }
            return Ok(signInResult);
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailToReset(SendEmailToReset email)
        {
            if (!await authorizationService.SendLinkToResetPassword(email))
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [HttpPatch,Route("forgotPassword/{code}")]
        public async Task<IActionResult> ForgotPassword(string code,ResetPasswordDto resetPassword)
        {
            if (resetPassword == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            if (!await authorizationService.ResetPassword(code,resetPassword))
            {
                return BadRequest(resourceManager.GetString("Bad"));
            }
            return Ok();
        }
        [HttpPatch("delete/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (!await authorizationService.DeleteAccount(id))
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [HttpPatch("active/{id}")]
        public async Task<IActionResult> ActiveAccount(int id)
        {
            if (!await authorizationService.ActiveAccount(id))
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok();
        }
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await authorizationService.GetUsers();
            if (users == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            return Ok(users);
        }
    }
}