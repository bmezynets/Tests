using System;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Subjects;

namespace TopTests.API.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly ResourceManager resourceManager;
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
            resourceManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost("registerSubject/{id}")]
        public async Task<IActionResult> RegisterSubject(int id,RegisterSubjectDto registerSubjectDto)
        {
            if (registerSubjectDto == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            var subject = await subjectService.RegisterSubject(registerSubjectDto,id);
            return Ok(subject);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPatch,Route("editSubject/{Code}")]
        public async Task<IActionResult> EditSubject(string Code,EditSubjectDto editSubjectDto)
        {
            if (editSubjectDto == null)
            {
                return BadRequest(resourceManager.GetString("Null"));
            }
            var edit_subject = await subjectService.EditSubject(Int32.Parse(Code), editSubjectDto);
            if (edit_subject == null)
            {
                return NotFound(resourceManager.GetString("Id"));
            }
            return Ok();
        }
        [Authorize(Roles = "Teacher")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            if (!await subjectService.DeleteSubject(id))
            {
                return NotFound(resourceManager.GetString("Id"));
            }
            return Ok();
        }
        /// <summary>
        /// For users
        /// </summary>
        /// <returns>All avaliable subjects</returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await subjectService.GetAllSubjects();
            if (subjects == null)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok(subjects);
            
        }
        /// <summary>
        /// For Teacher
        /// </summary>
        /// <returns>All subjects created by teacher</returns>
        
        [Authorize(Roles = "Teacher")]
        [HttpGet("getTeacherSubjects/{id}")]
        public async Task<IActionResult> GetAllTeachersSubjects(int id)
        {
            var subjects = await subjectService.GetTeacherSubjects(id);
            if (subjects == null)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok(subjects);

        }
        [HttpGet("getAllTests")]
        public async Task<IActionResult> GetAllSubjectsTest()
        {
            var subjects = await subjectService.GetAllSubjectsTests();
            if (subjects == null)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok(subjects);
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet("getAllDeleted")]
        public async Task<IActionResult> GetAllDeletedSubjects()
        {
            var subjects = await subjectService.GetAllDeletedSubjects();
            if (subjects == null)
            {
                return NotFound(resourceManager.GetString("Null"));
            }
            return Ok(subjects);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPatch("restore/{id}")]
        public async Task<IActionResult> RestoreSubject(int id)
        {
            var subject = await subjectService.RestoreSubject(id);
            if (subject == null)
            {
                return NotFound(resourceManager.GetString("Id"));
            }
            return Ok(subject);
        }
    }
}