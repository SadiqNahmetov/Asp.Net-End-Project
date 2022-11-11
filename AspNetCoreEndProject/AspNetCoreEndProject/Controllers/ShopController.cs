using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Helpers;
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

        public async Task<IActionResult> Index(int page = 1,int take = 6)
        {
            List<Product> products = await _context.Products
                .Where(m => !m.isDeleted)
                .Include(m => m.ProductImage)
                .Include(m=>m.Category)
                .Skip((page*take)-take)
                .Take(take)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();

            IEnumerable<Category> categories = await _context.Categories
                .Where(m => !m.isDeleted)
                .Skip(6)
                .ToListAsync();

            //List<ShopVM> shopVMs = 
            //int count = await GetPageCount(take);

            //Paginate<>

            ShopVM shopVM = new ShopVM
            { 
                Product = products,
                Categories = categories,
            
            };

            return View(shopVM);
        }

        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Products
                .Where(m=>!m.isDeleted)
                .CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
    }
}
