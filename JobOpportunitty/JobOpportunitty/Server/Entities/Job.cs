using System.Data;

namespace JobOpportunitty.Server.Entities
{
    public class Job
    {
        public Job(Guid id, string title, string description, string company, string location, decimal salary, Guid createdByUser, List<JobApplication> jobApplications, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Company = company;
            Location = location;
            Salary = salary;
            CreatedByUser = createdByUser;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }

        public string Location { get; private set; }

        public decimal Salary { get; private set; }

        public Guid CreatedByUser { get; private set; }

        public List<JobApplication> JobApplications { get; set; }

        public DateTime  CreatedAt { get; private set; }

    }
}
