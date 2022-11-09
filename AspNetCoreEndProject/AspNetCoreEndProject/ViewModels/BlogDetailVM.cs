using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class BlogDetailVM
    {
        public Blog Blog { get; set; }

        public IEnumerable<Blog> RecentPosts { get; set; }

        public IEnumerable<Customer> Customer { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

    }
}
