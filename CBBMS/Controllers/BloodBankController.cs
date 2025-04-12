using Azure.Core;
using CBBMS.Data;
using CBBMS.Models;
using CBBMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CBBMS.Controllers
{
    [Authorize(Roles = "BloodBank")]
    public class BloodBankController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBloodBankService _bloodBankService;

        public BloodBankController(UserManager<ApplicationUser> userManager, IBloodBankService bloodBankService)
        {
            _userManager = userManager;
            _bloodBankService = bloodBankService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ----------------- Donations Management -----------------
        public async Task<IActionResult> Donations() 
        {
            var user = await _userManager.GetUserAsync(User);
            var donations = await _bloodBankService.GetPendingDonationsAsync(user.Id);

            return View(donations);
        }

        public async Task<IActionResult> AcceptDonation(int Id)
        {
            var result = await _bloodBankService.AcceptDonationAsync(Id);

            if (!result)
                return BadRequest();

            TempData["Message"] = "Donation is accepted!";

            return RedirectToAction(nameof(Donations));
        }
        
        public async Task<IActionResult> RejectDonation(int Id)
        {
            var result = await _bloodBankService.RejectDonationAsync(Id);

            if (!result)
                return BadRequest();

            return RedirectToAction(nameof(Donations));
        }

        // ----------------- Blood Stock Management -----------------
        public async Task<IActionResult> BloodStock()
        {
            var user = await _userManager.GetUserAsync(User);
            var stockUnits = await _bloodBankService.GetBloodStockAsync(user.Id);
            return View(stockUnits);
        }

        // ----------------- Hospital Requests Management -----------------
        public async Task<IActionResult> HospitalRequests()
        {
            var requests = await _bloodBankService.GetHospitalRequestsAsync();

            return View(requests);
        }

        public async Task<IActionResult> AcceptRequest(int id)
        {
            var result = await _bloodBankService.AcceptBloodRequestAsync(id);
            TempData["Message"] = result;


            return RedirectToAction("HospitalRequests");
        }

        public async Task<IActionResult> RejectRequest(int id)
        {
            var success = await _bloodBankService.RejectBloodRequestAsync(id);
            if (!success)
                return NotFound();

            return RedirectToAction("HospitalRequests");
        }
    }
}
