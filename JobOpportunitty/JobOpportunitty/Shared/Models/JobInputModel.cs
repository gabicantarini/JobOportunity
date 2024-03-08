using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunitty.Shared.Models
{
    public class JobInputModel
    {
        //modelo de entrada das vagas de emprego que serão adicionadas

        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
    }
}
