using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisteredDoctors.Data.Models
{
    public class RegisteredDoctor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Specailty { get; set; }
        public string ResgitrationNumber { get; set; }
        public bool SanctionStatus { get; set; }
        public string DateCreated { get; set; } = DateTime.Now.ToString();
        public string DateUpdated { get; set; } = DateTime.Now.ToString();
    }
}
