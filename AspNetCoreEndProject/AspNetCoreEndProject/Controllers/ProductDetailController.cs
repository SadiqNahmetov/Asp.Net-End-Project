using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.Services;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        public ProductDetailController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Product product = await _context.Products
                .Where(m => !m.isDeleted && m.Id == id)
                .Include(m => m.ProductImage)
                .FirstOrDefaultAsync();

            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();


            ProductDetailVM productDetailVM = new ProductDetailVM
            { 
                Product = product,
                Settings =setting,
            };



            return View(productDetailVM);
        }
    }
}
