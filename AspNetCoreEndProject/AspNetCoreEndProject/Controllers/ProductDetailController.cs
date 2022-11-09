using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        public ProductDetailController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Product product = await _context.Products
                .Where(m => !m.isDeleted && m.Id == id)
                .Include(m => m.ProductImage)
                .FirstOrDefaultAsync();



            ProductDetailVM productDetailVM = new ProductDetailVM
            { 
                Product = product,
            };



            return View(productDetailVM);
        }
    }
}
