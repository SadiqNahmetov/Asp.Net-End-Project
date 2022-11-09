using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.isDeleted)
                .Include(m => m.ProductImage)
                .ToListAsync();


            ShopVM shopVM = new ShopVM
            { 
                Product = products,
            
            };

            return View(shopVM);
        }
    }
}
