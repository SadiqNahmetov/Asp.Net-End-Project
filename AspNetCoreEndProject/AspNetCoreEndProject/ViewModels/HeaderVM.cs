using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class HeaderVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<Languge> Languges { get; set; }

    }
}
