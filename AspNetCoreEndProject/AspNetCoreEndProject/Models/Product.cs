using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreEndProject.Models
{
    public class Product : BaseEntity
    {

        public string Title { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountPrice { get; set; }

        public int SellerCount { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImage { get; set; }



    }
}
