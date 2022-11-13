using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Slider : BaseEntity
    {
        public string Image { get; set; }
      
        public string Sale { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
