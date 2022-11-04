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

            IEnumerable<Currency> currencies = await _context.Currencies.Where(m => !m.isDeleted).ToListAsync();
            IEnumerable<Languge> languges = await _context.Languges.Where(m => !m.isDeleted).ToListAsync();

            HomeVM mopdel = new HomeVM 
            { 
                Sliders = sliders,
                Currencies = currencies,
                Languges = languges
            };

            return View(mopdel);
        }
 
    }
}
