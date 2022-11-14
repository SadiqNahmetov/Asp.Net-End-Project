using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Tag : BaseEntity
    {
        [Required(ErrorMessage = "Can't be empty")]

        public string TagName { get; set; }
      

    }
}
