using CBBMS.Data;
using CBBMS.Models;
using CBBMS.Services;
using CBBMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CBBMS.Controllers
{
    [Authorize(Roles = "Hospital")]
    public class HospitalController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHospitalService _hospitalService;

        public HospitalController(UserManager<ApplicationUser> userManager, IHospitalService hospitalService)
        {
            _userManager = userManager;
            _hospitalService = hospitalService;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var hospital = await _hospitalService.GetHospitalByUserAsync(user.Id);

            if (hospital == null) return NotFound();

            return View(hospital);
        }
      

        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(HospitalRequestViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var user = await _userManager.GetUserAsync(User);

            if (user == null) return NotFound();

            var request = new HospitalRequest()
            {
                BloodType = model.BloodType,
                PatientStatus = model.PatientStatus,
                Quantity = model.Quantity,
                RequestDate = DateTime.Now,
                HospitalId = user.Id
            };

            await _hospitalService.CreateHospitalRequestAsync(request);

            return RedirectToAction("Index", "Hospital");
        }
    }
}
