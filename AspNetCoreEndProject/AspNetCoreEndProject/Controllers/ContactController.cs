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
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Contact contact = await _context.Contacts.Where(m => !m.isDeleted).FirstOrDefaultAsync();
            SendMessage sendMessage = await _context.SendMessages.Where(m => !m.isDeleted).FirstOrDefaultAsync();


            ContactVM contactVM = new ContactVM
            { 
                Contact = contact,
                SendMessage = new SendMessage()
            };

            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SendMessage sendMessage)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }

                bool isExist = await _context.SendMessages.AnyAsync(m => m.Name.Trim() == sendMessage.Name.Trim()
                && m.Email.Trim() == sendMessage.Email.Trim()
                && m.Phone == sendMessage.Phone
                && m.Subject.Trim() == sendMessage.Subject.Trim()
                && m.Message.Trim() == sendMessage.Message.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Name", "Subject already exist");
                    return View();
                }

                await _context.SendMessages.AddAsync(sendMessage);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }

           
        }
    }
}
