namespace JobOpportunitty.Server.Entities
{
    public class JobApplication
    {
        public JobApplication(string userId, Guid jobId, Job job)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            JobId = jobId;
            Job = job;

            AppliedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public Guid JobId { get; private set; }
        public Job  Job { get; private set; }
        public DateTime AppliedAt { get; private set; }
    }
}
