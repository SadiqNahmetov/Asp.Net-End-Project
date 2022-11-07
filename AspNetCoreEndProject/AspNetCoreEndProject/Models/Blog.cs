using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Blog : BaseEntity
    {
        public string Image { get; set; }

        public string Title { get; set; }
        public string Admin { get; set; }

        public DateTime CreateDate { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
