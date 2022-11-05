using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class Product : BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountPrice { get; set; }




    }
}
