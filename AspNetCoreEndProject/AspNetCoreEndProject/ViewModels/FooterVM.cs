using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class FooterVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}
