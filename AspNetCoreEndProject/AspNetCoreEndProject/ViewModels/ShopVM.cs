using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Product> Product { get; set; }

    }
}
