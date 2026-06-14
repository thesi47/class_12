using class_12.Data;
using class_12.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace class_12.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonalInfoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.PersonalInfos.ToListAsync();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _context.PersonalInfos.Add(personalInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            return View(personalInfo);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonalInfo personalinfo)
        {
            if(ModelState.IsValid)
            {
                _context.PersonalInfos.Update(personalinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            if (personalInfo != null)
            {
                _context.PersonalInfos.Remove(personalInfo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
