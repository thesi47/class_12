using class_12.Data;
using class_12.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace class_12.Controllers
{
    public class ContactMessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactMessageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.ContactMessages.ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);
            return View(contactMessage);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactMessage contactMessage)
        {
            if(ModelState.IsValid)
            {
                _context.ContactMessages.Update(contactMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);
            return View(contactMessage);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);
            if (contactMessage != null)
            {
                _context.ContactMessages.Remove(contactMessage);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
