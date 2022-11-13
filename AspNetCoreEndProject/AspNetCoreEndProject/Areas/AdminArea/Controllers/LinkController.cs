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
    public class LinkController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LinkController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async  Task<IActionResult> Index()
        {
            List<Link> links = await _context.Links.Where(m => !m.isDeleted).ToListAsync();
          
            return View(links);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Link link)
        {
            if (!ModelState.IsValid) return View();

            if (!link.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!link.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + link.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await link.Photo.CopyToAsync(stream);
            }

            link.Icon = fileName;

            await _context.Links.AddAsync(link);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Link link = await _context.Links.FindAsync(id);

            if (link == null) return NotFound();

            return View(link);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Link link = await _context.Links.FirstOrDefaultAsync(m => m.Id == id);

                if (link is null) return NotFound();

                return View(link);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Link link)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(link);
                }

                if (!link.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + "_" + link.Photo.FileName;

                Link dblink = await _context.Links.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dblink is null) return NotFound();

                if (dblink.Photo == link.Photo)
                {
                    return RedirectToAction(nameof(Index));
                }

                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await link.Photo.CopyToAsync(stream);
                }

                link.Icon = fileName;
           
                _context.Links.Update(link);

                await _context.SaveChangesAsync();

                string dbPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", dblink.Icon);

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
            Link link = await GetByIdAsync(id);

            if (link == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "asets/img/icon", link.Icon);

          

            Helper.DeleteFile(path);

            _context.Links.Remove(link);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private async Task<Link> GetByIdAsync(int id)
        {
            return await _context.Links.FindAsync(id);
        }

    }
}
