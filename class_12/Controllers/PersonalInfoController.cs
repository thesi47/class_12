using class_12.Data;
using class_12.Entities;
using class_12.Models;
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
            return View(data ?? new List<PersonalInfo>());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonalInfoVM personalInfoVM)
        {
            if (ModelState.IsValid)
            {
                var entity = new PersonalInfo();


                entity.FullName = personalInfoVM.FullName;
                entity.Title = personalInfoVM.Title;
                entity.Email = personalInfoVM.Email;
                entity.Phone = personalInfoVM.Phone;
                entity.Address = personalInfoVM.Address;
                entity.Website = personalInfoVM.Website;
                entity.LinkedIn = personalInfoVM.LinkedIn;
                entity.Github = personalInfoVM.Github;
                entity.Bio = personalInfoVM.Bio;
               

                if (personalInfoVM.ProfileImage != null)
                {
                    string folder = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "uploads");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Guid.NewGuid() +
                                      Path.GetExtension(personalInfoVM.ProfileImage.FileName);

                    string filePath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await personalInfoVM.ProfileImage.CopyToAsync(stream);
                    }

                    entity.ProfileImageUrl = fileName;
                }

                _context.PersonalInfos.Add(entity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(personalInfoVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            return View(personalInfo);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonalInfo updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.PersonalInfos.Update(updatedInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(updatedInfo);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            return View(personalInfo);
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
