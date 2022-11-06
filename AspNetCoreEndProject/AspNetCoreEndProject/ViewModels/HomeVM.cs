using AspNetCoreEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
     
        public IEnumerable<Link> Links { get; set; }
        public OurProduct OurProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Banner> Banners { get; set; }

        public TopSeller TopSeller { get; set; }

        public ProductBanner ProductBanner { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public OurBlog OurBlog { get; set; }



    }
}
