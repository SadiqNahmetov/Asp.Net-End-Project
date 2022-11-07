using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class BlogVM 
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Customer> Customer { get; set; }



    }
}
