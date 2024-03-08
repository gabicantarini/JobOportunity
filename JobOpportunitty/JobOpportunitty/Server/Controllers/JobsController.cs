using JobOpportunitty.Server.Data;
using JobOpportunitty.Server.Entities;
using JobOpportunitty.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

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
        public async Task<IActionResult> GetAll() //return all jobs
        {
            var jobs = await _context.Jobs.ToListAsync(); //consut at EF-Core

            var model = jobs.Select(j => //return new model out
                new JobViewModel(
                    j.Id, 
                    j.Title, 
                    j.Description, 
                    j.Company, 
                    j.Location, 
                    j.Salary)).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetByIdl(Guid id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);

            if(job is null)
            {
                return NotFound();
            }
            var model = new JobViewModel(
                    job.Id,
                    job.Title,
                    job.Description,
                    job.Company,
                    job.Location,
                    job.Salary);
            return Ok(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(JobInputModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //Get user id

            var job = new Job(
                model.Title, 
                model.Description, 
                model.Company, 
                model.Location, 
                model.Salary, 
                new Guid(userId));

            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(Guid id, JobInputModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //Get user id

            var job = await _context.Jobs.SingleOrDefaultAsync(j => j.Id == id);
            
            if(job is null) 
            { 
                return NotFound(); 
            }

            job.Update(model.Title, model.Description, model.Company, model.Location, model.Salary);
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/applications")]
        [Authorize]
        public async Task<IActionResult> PostApplication(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //Get user id
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest();
            }

            var jobApplication = new JobApplication(userId, id);
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("application")]
        [Authorize]
        public async Task<IActionResult> GetApplication() //return all jobs
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //Get user id
            if (string.IsNullOrWhiteSpace(userId))
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest();
            }

            var applications = await _context.JobApplications
                .Include(ja => ja.Job)
                .Where(j => j.UserId == userId).ToListAsync();

            var model = applications.Select(a => //return new model out
                new JobApplicationViewModel(
                    a.Id,
                    a.JobId,
                    a.Job.Title,
                    a.Job.Company,
                    a.Job.Location,
                    a.Job.Salary,
                    a.AppliedAt)).ToList();

            return Ok(model);
        }
    }
}
