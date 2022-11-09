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
    public class BlogDetailController : Controller
    {
        private readonly AppDbContext _context;
        public BlogDetailController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            Blog blog = await _context.Blogs
                .Where(m => !m.isDeleted)
                .FirstOrDefaultAsync(m=>m.Id == id);

            IEnumerable<Blog> recentPosts = await _context.Blogs.Where(m => !m.isDeleted).OrderByDescending(m => m.Id).ToListAsync();

            IEnumerable<Customer> customers = await _context.Customers
                .Where(m => !m.isDeleted)
                .Include(m => m.Socials)
                .ToListAsync();
            IEnumerable<Tag> tags = await _context.Tags.Where(m => !m.isDeleted).ToListAsync();

            BlogDetailVM blogDetailVM = new BlogDetailVM
            { 
                Blog = blog,
                Customer = customers,
                RecentPosts = recentPosts,
                Tags = tags
            };


            return View(blogDetailVM);
        }
    }
}
