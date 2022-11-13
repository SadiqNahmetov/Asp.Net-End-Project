using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Helpers;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.isDeleted)
                .Include(m => m.ProductImage)
                .Include(m => m.Category)
                .ToListAsync();

            return View(products);
        }




        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    ViewBag.categories = await GetCategoriesAsync();
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ProductCreateVM product)
        //{
        //    ViewBag.categories = await GetCategoriesAsync();

        //    if (!ModelState.IsValid)
        //    {
        //        return View(product);
        //    }

        //    foreach (var photo in product.Photos)
        //    {
        //        if (!photo.CheckFileType("image/"))
        //        {
        //            ModelState.AddModelError("Photo", "Please choose correct image type");
        //            return View(product);
        //        }


        //        if (!photo.CheckFileSize(500))
        //        {
        //            ModelState.AddModelError("Photo", "Please choose correct image size");
        //            return View(product);
        //        }

        //    }

        //    List<ProductImage> images = new List<ProductImage>();

        //    foreach (var photo in product.Photos)
        //    {
        //        string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

        //        string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", fileName);

        //        await Helper.SaveFile(path, photo);


        //        ProductImage image = new ProductImage
        //        {
        //            Image = fileName,
        //        };

        //        images.Add(image);
        //    }

        //    images.FirstOrDefault().IsMain = true;

        //    decimal convertedPrice = decimal.Parse(product.Price.Replace(".", ","));

        //    Products newProduct = new Products
        //    {
        //        Title = product.Title,
        //        Description = product.Description,
        //        Price = (int)convertedPrice,
        //        CreateDate = DateTime.Now,
        //        CategoryId = product.CategoryId,
        //        Discount = product.Discound,
        //        ProductImages = images
        //    };

        //    await _context.ProductImages.AddRangeAsync(images);
        //    await _context.Products.AddAsync(newProduct);

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products
                .Where(m => !m.isDeleted && m.Id == id)
                .Include(m => m.ProductImage)
                .FirstOrDefaultAsync();

            if (product == null) return NotFound();

            foreach (var item in product.ProductImage)
            {
                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", item.Image);
                Helper.DeleteFile(path);
                item.isDeleted = true;
            }

            product.isDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        //private decimal StringToDecimal(string str)
        //{
        //    return decimal.Parse(str.Replace(".", ","));
        //}


        //private async Task<SelectList> GetCategoriesAsync()
        //{
        //    IEnumerable<Category> categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();
        //    return new SelectList(categories, "Id", "Name");
        //}

        //private async Task<Product> GetByIdAsync(int id)
        //{
        //    return await _context.Products
        //                         .Where(m => !m.isDeleted && m.Id == id)
        //                         .Include(m => m.Category)
        //                         .Include(m => m.ProductImage)
        //                         .FirstOrDefaultAsync();
        //}


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products
                .Where(m => !m.isDeleted && m.Id == id)
                .Include(m => m.ProductImage)
                .Include(m => m.Category)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

      
            return View(product);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id is null) return BadRequest();

        //    ViewBag.categories = await GetCategoriesAsync();

        //    Products dbProduct = await GetByIdAsync((int)id);

        //    return View(new ProductEditVM
        //    {
        //        Id = dbProduct.Id,
        //        Title = dbProduct.Title,
        //        Description = dbProduct.Description,
        //        Price = dbProduct.Price.ToString("0.#####").Replace(",", "."),
        //        CategoryId = dbProduct.CategoryId,
        //        Images = dbProduct.ProductImages
        //    });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ProductEditVM updatedProduct)
        //{
        //    ViewBag.categories = await GetCategoriesAsync();

        //    if (!ModelState.IsValid) return View(updatedProduct);

        //    Products dbProduct = await GetByIdAsync(id);

        //    if (updatedProduct.Photos != null)
        //    {

        //        foreach (var photo in updatedProduct.Photos)
        //        {
        //            if (!photo.CheckFileType("image/"))
        //            {
        //                ModelState.AddModelError("Photo", "Please choose correct image type");
        //                return View(updatedProduct);
        //            }


        //            if (!photo.CheckFileSize(500))
        //            {
        //                ModelState.AddModelError("Photo", "Please choose correct image size");
        //                return View(updatedProduct);
        //            }

        //        }

        //        foreach (var item in dbProduct.ProductImages)
        //        {
        //            string path = Helper.GetFilePath(_env.WebRootPath, "img", item.Image);
        //            Helper.DeleteFile(path);
        //        }


        //        List<ProductImage> images = new List<ProductImage>();

        //        foreach (var photo in updatedProduct.Photos)
        //        {

        //            string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

        //            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", fileName);

        //            await Helper.SaveFile(path, photo);


        //            ProductImage image = new ProductImage
        //            {
        //                Image = fileName,
        //            };

        //            images.Add(image);

        //        }

        //        images.FirstOrDefault().IsMain = true;

        //        dbProduct.ProductImages = images;

        //    }

        //    decimal convertedPrice = StringToDecimal(updatedProduct.Price);

        //    dbProduct.Title = updatedProduct.Title;
        //    dbProduct.Description = updatedProduct.Description;
        //    dbProduct.Price = (int)convertedPrice;
        //    dbProduct.CategoryId = updatedProduct.CategoryId;
        //    dbProduct.Discount = updatedProduct.Discound;

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
