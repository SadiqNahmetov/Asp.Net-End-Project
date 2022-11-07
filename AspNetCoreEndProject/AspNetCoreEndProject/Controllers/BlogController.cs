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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.isDeleted).ToListAsync();

            IEnumerable<Customer> customers = await _context.Customers
                .Where(m => !m.isDeleted)
                .Include(m=>m.Socials)
                .ToListAsync();



            BlogVM blogVM = new BlogVM
            {
                Blogs = blogs,
                Customer = customers
            };

            return View(blogVM);
        }

      
    }
}
