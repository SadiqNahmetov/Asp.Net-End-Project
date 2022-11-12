using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.Services;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly LayoutService  _layoutService;

        public HomeController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        public async Task<IActionResult> Index()
        {
            //HttpContext.Session.SetString("name", "Sadiq");

            //Response.Cookies.Append("surname", "Nahmetov", new CookieOptions { MaxAge = TimeSpan.FromSeconds(50)});

            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            int productTake = int.Parse(settingDatas["HomeProductTake"]);

            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.isDeleted).ToListAsync();

            IEnumerable<Link> links = await _context.Links.Where(m => !m.isDeleted).ToListAsync();

            OurProduct ourProduct = await _context.OurProducts.Where(m => !m.isDeleted).FirstOrDefaultAsync();

            IEnumerable<Product> products = await _context.Products 
                .Where(m => !m.isDeleted)
                .Where(m=> m.SellerCount > 0)
                .Include(m=>m.ProductImage)
                .Take(productTake).ToListAsync();
            
            IEnumerable<Banner> banners = await _context.Banners.Where(m => !m.isDeleted).ToListAsync();

            TopSeller topSeller = await _context.TopSellers.Where(m => !m.isDeleted).FirstOrDefaultAsync();

            ProductBanner productBanner = await _context.ProductBanners.Where(m => !m.isDeleted).FirstOrDefaultAsync();

            IEnumerable<Brand> brands = await _context.Brands.Where(m => !m.isDeleted).ToListAsync();

            OurBlog ourBlog = await _context.OurBlogs.Where(m => !m.isDeleted).FirstOrDefaultAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.isDeleted).Take(4).ToListAsync();




            HomeVM mopdel = new HomeVM 
            { 
                Sliders = sliders,
                Links = links,
                OurProducts = ourProduct,
                Products = products,
                Banners = banners,
                TopSeller = topSeller,
                ProductBanner = productBanner,
                Brands = brands,
                OurBlog = ourBlog,
                Blogs = blogs
                

            };

            return View(mopdel);
        }



        [HttpPost]
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return BadRequest();

            var dbProduct = await GetProductById(id);

            if (dbProduct == null) return NotFound();

            List<BasketVM> basket = GetBasket();

            UpdateBasket(basket, dbProduct.Id);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            //return RedirectToAction(nameof(Index));

            return Ok();

        }

      

        private void UpdateBasket(List<BasketVM> basket, int id)
        {
            BasketVM existProduct = basket.FirstOrDefault(m => m.Id == id);

            if (existProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = id,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }

        }


        private async Task<Product> GetProductById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }


        private List<BasketVM> GetBasket()
        {

            List<BasketVM> basket;

            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }
            return basket;
        }







    }
}
