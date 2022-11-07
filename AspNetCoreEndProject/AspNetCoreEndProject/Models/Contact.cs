using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Contact : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public string WorkingHours { get; set; }

    }
}
