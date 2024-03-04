using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunitty.Shared.Models
{
    public class JobApplicationViewModel
    {
        public JobApplicationViewModel(Guid id, Guid jobId, string title, string company, string location, decimal salary, DateTime apliedAt)
        {
            Id = id;
            JobId = jobId;
            Title = title;
            Company = company;
            Location = location;
            Salary = salary;
            ApliedAt = apliedAt;
        }

        //precisamos dos dados do jpb aplication e da aplicação para preencher esta tabela

        public Guid Id { get; private set; }
        public Guid JobId { get; private set; }
        public string Title { get; private set; }
        public string Company { get; private set; }
        public string Location { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime ApliedAt { get; private set; }
    }
}
