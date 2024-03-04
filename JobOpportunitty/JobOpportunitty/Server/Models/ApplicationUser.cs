using JobOpportunitty.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunitty.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<JobApplication> JobApplications { get; private set; }
    }
}
