using CBBMS.Data;
using CBBMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CBBMS.Controllers
{
    [Authorize(Roles = "Hospital")]
    public class HospitalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HospitalController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //private async Task<Hospital> GetCurrentUserHospitalAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    return await _context.Hospitals.FirstOrDefaultAsync(h => h.Id == user.HospitalId);
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var hospital = await _context.Hospitals
        //        .Include(h => h.BloodRequests)
        //        .FirstOrDefaultAsync(h => h.ManagerId == user.Id);

        //    if (hospital == null)
        //        return NotFound();

        //    return View(hospital);
        //}

        //public async Task<IActionResult> Edit()
        //{
        //    var hospital = await GetCurrentUserHospitalAsync();
        //    if (hospital == null)
        //        return NotFound();
        //    return View(hospital);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Hospital hospital)
        {
            var user = await _userManager.GetUserAsync(User);
            string existingHospital = null;// await _context.Hospitals.FirstOrDefaultAsync(h => h.Id == user.Id);

            if (existingHospital == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                //existingHospital.City = hospital.City;
                _context.Update(existingHospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        //public async Task<IActionResult> Details()
        //{
        //    var hospital = await GetCurrentUserHospitalAsync();
        //    if (hospital == null)
        //        return NotFound();
        //    return View(hospital);
        //}
    }
}
