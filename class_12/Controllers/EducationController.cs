using class_12.Data;
using class_12.Entities;
using class_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace class_12.Controllers
{
    public class EducationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EducationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Educations.ToListAsync();
            return View(data ?? new List<Education>());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(EducationVM education)
        {
            if (ModelState.IsValid)
            {
                var entity = new Education();

                entity.Instituition = education.Instituition;
                entity.Degree = education.Degree;
                entity.FieldOfStudy = education.FieldOfStudy;
                entity.StartDate = education.StartDate;
                entity.EndDate = education.EndDate;

                _context.Educations.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Education education)
        {
            var existingEducation = await _context.Educations.FindAsync(education.Id);
            if (existingEducation == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Educations.Update(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            return View(education);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
