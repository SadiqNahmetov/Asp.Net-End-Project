using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class ShopVM
    {
        public List<Product> Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
