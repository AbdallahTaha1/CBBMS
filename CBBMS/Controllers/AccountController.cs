using CBBMS.Data;
using CBBMS.Models;
using CBBMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CBBMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                RoleType = model.RoleType  
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.RoleType);
                await _signInManager.SignInAsync(user, isPersistent: false);
                
                if (model.RoleType == "Donor")
                    return RedirectToAction("CompleteDonorProfile");
                else if (model.RoleType == "BloodBank")
                    return RedirectToAction("CompleteBloodBankProfile");
                else 
                    return RedirectToAction("CompleteDonorProfile");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
        public IActionResult CompleteDonorProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompleteDonorProfile(CompleteDonorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);

            var donor = new Donor
            {
                DonorId = user.Id,
                NationalID = model.NationalID,
                FullName = model.FullName,
                BloodType = model.BloodType,
                City = model.City,
            };

            await _context.Donors.AddAsync(donor);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CompleteBloodBankProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompleteBloodBankProfile(CompleteBloodBankViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);

            var bloodBank = new BloodBank
            {
                FullName = model.FullName,
                City = model.City,
                ApplicationUserId = user.Id
            };

            await _context.BloodBanks.AddAsync(bloodBank);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() {ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                if (String.IsNullOrEmpty(model.ReturnUrl))
                    return RedirectToAction("Index", "Home");
                return Redirect(model.ReturnUrl);
            }
                

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
