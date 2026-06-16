using class_12.Data;
using class_12.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using class_12.Models;

namespace class_12.Controllers
{
    public class SkillController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SkillController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Skills.ToListAsync();
            return View(data ?? new List<Skill>());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(SkillVM skillVM)
        {
            if (ModelState.IsValid)
            {
                var entity = new Skill();

                entity.Name = skillVM.Name;
                entity.ProficiencyLevel = skillVM.ProficiencyLevel;
                entity.Category = skillVM.Category;

                _context.Skills.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            return View(skill);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Skill skill)
        {
            if(ModelState.IsValid)
            {
                _context.Skills.Update(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            return View(skill);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
