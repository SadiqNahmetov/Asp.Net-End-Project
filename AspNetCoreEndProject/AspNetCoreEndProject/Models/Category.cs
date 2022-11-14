using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Can't be empty")]

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
