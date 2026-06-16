using class_12.Data;
using class_12.Entities;
using class_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace class_12.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Experiences.ToListAsync();
            return View(data ?? new List<Experience>());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ExperienceVM experience)
        {
            if (ModelState.IsValid)
            {
                var entity = new Experience();
                entity.Company = experience.Company;
                entity.Description = experience.Description;
                entity.Role = experience.Role;
                entity.Startdate = experience.Startdate;
                entity.EndDate = experience.EndDate;

                _context.Experiences.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            return View(experience);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Experience experience)
        {
            if(ModelState.IsValid)
            {
                _context.Experiences.Update(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            return View(experience);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
