using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Slider : BaseEntity
    {
        public string Image { get; set; }
        public string Sale { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
