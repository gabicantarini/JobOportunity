using JobOpportunitty.Server.Data;
using JobOpportunitty.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace JobOpportunitty.Server.Controllers
{

    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {

        //Dependency Injection
        private readonly ApplicationDbContext _context;
        public JobsController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetByIdl()
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(JobInputModel model)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(Guid Id, JobInputModel model)
        {
            return NoContent();
        }

        [HttpPost("{id}/applications")]
        [Authorize]
        public async Task<IActionResult> PostApplication(Guid id)
        {
            return NoContent();
        }
    }
}
