using CBBMS.Data;
using CBBMS.Models;
using CBBMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBBMS.Controllers
{
    [Authorize]
    public class DonationRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DonationRequestController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Donate()
        {
            ViewBag.BloodBanks = new SelectList(_context.BloodBanks.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Donate(DonationRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BloodBanks = new SelectList(_context.BloodBanks.ToList(), "Id", "Name");
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            var selectedBank = _context.BloodBanks.FirstOrDefault(b => b.Id == model.BloodBankId);

            if (user == null || selectedBank == null)
            {
                return NotFound();
            }

            var donation = new DonationRequest
            {
                DonorId = user.Id,
                BloodType = user.BloodType,
                BloodBankId = selectedBank.Id,
                DonationDate = DateTime.Now,
            };
            
            _context.DonationRequests.Add(donation);
            await _context.SaveChangesAsync();

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
