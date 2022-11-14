using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Blog : BaseEntity
    {
        public string Image { get; set; }
        [Required(ErrorMessage = "Can't be empty")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Can't be empty")]

        public string Admin { get; set; }

        public DateTime CreateDate { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Can't be empty")]

        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public string DescriptionSecond { get; set; }
        public string DescriptionThird { get; set; }


    }
}
