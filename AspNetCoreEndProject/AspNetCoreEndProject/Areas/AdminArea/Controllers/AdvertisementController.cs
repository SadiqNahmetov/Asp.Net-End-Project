using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Helpers;
using AspNetCoreEndProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdvertisementController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AdvertisementController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            ProductBanner productBanners = await _context.ProductBanners.Where(m => !m.isDeleted).FirstOrDefaultAsync();
            ViewBag.count = await _context.ProductBanners.Where(m => !m.isDeleted).CountAsync();
            return View(productBanners);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductBanner productBanner)
        {
            if (!ModelState.IsValid) return View();

            if (!productBanner.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!productBanner.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + productBanner.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await productBanner.Photo.CopyToAsync(stream);
            }

            productBanner.Image = fileName;

            await _context.ProductBanners.AddAsync(productBanner);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            ProductBanner productBanner = await _context.ProductBanners.FindAsync(id);

            if (productBanner == null) return NotFound();

            return View(productBanner);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                ProductBanner productBanner = await _context.ProductBanners.FirstOrDefaultAsync(m => m.Id == id);

                if (productBanner is null) return NotFound();

                return View(productBanner);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductBanner productBanner)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(productBanner);
                }

                if (!productBanner.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + "_" + productBanner.Photo.FileName;

                ProductBanner dbProductBanner = await _context.ProductBanners.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbProductBanner is null) return NotFound();

                if (dbProductBanner.Photo == productBanner.Photo)
                {
                    return RedirectToAction(nameof(Index));
                }

                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await productBanner.Photo.CopyToAsync(stream);
                }

                productBanner.Image = fileName;

                _context.ProductBanners.Update(productBanner);

                await _context.SaveChangesAsync();

                string dbPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", dbProductBanner.Image);

                Helper.DeleteFile(dbPath);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            ProductBanner productBanner = await GetByIdAsync(id);

            if (productBanner == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", productBanner.Image);


            Helper.DeleteFile(path);

            _context.ProductBanners.Remove(productBanner);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private async Task<ProductBanner> GetByIdAsync(int id)
        {
            return await _context.ProductBanners.FindAsync(id);
        }
    }
}
