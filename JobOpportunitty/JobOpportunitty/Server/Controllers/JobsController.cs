using JobOpportunitty.Server.Data;
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
    }
}
