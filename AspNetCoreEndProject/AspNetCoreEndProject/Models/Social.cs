using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Social : BaseEntity
    {
        public string Icon { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
