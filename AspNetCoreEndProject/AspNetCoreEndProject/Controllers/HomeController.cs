using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.isDeleted).ToListAsync();
            IEnumerable<Link> links = await _context.Links.Where(m => !m.isDeleted).ToListAsync();
            OurProduct ourProduct = await _context.OurProducts.Where(m => !m.isDeleted).FirstOrDefaultAsync();
            IEnumerable<Product> products = await _context.Products.Where(m => !m.isDeleted).ToListAsync();

            HomeVM mopdel = new HomeVM 
            { 
                Sliders = sliders,
                Links = links,
                OurProducts = ourProduct,
                Products = products

            };

            return View(mopdel);
        }
 
    }
}
