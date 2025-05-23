﻿using CBBMS.Data;
using CBBMS.Models;
using CBBMS.Services;
using CBBMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CBBMS.Controllers
{
    [Authorize(Roles = "Donor")]
    public class DonorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDonorService _donorService;

        public DonorController(UserManager<ApplicationUser> userManager, IDonorService donorService)
        {
            _userManager = userManager;
            _donorService = donorService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            var donations = await _donorService.GetUserDonations(user.Id);


            return View(donations); 
        }
        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            var vm = new DonationRequestViewModel
            {
                BloodBanks = await _donorService.GetBloodBanksAsync()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Donate(DonationRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BloodBanks = await _donorService.GetBloodBanksAsync();
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            var donor = await _donorService.GetDonorByUserIdAsync(user.Id);

            if (user == null || model.BloodBankId== null || donor == null)
            {
                return NotFound();
            }

            if(donor.CanDonate ==  false)
            {
                ModelState.AddModelError("", "You cannot Donate because of your virus test results");
                model.BloodBanks = await _donorService.GetBloodBanksAsync();
                return View(model);
            }
            var lastAcceptedDonation = await _donorService.GetLastAcceptedDonation(user.Id);

            if (lastAcceptedDonation != null)
            {
                var timeSinceLastDonation = DateTime.UtcNow - lastAcceptedDonation.DonationDate;
                if (timeSinceLastDonation.TotalDays < 90)
                {
                    ModelState.AddModelError("", "You must wait at least 3 months between donations.");
                    model.BloodBanks = await _donorService.GetBloodBanksAsync();
                    return View(model);
                }
            }

            var donation = new DonationRequest
            {
                DonorId = user.Id,
                BloodBankId = model.BloodBankId,
                BloodType = donor.BloodType,
                DonationDate = DateTime.UtcNow
            };

            await _donorService.CreateDonationRequestAsync(donation);

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
