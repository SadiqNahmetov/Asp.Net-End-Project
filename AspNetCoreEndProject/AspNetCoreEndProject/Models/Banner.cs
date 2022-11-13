using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Banner : BaseEntity
    {     
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        public string Title { get; set; }
     
        public string Image { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image can't be empty")]
        public IFormFile Photo { get; set; }
    }
}
