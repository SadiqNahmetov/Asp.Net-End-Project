using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Link : BaseEntity
    {
        [Required(ErrorMessage = "Name can't be empty")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string Color { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }






    }
}
