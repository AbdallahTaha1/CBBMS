using CBBMS.Data;
using CBBMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CBBMS.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HospitalService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Hospital> GetHospitalByUserAsync(string userId) =>
                await _context.Hospitals
                .Include(h => h.HospitalRequests)
                .FirstOrDefaultAsync(h => h.HospitalId == userId);

        public async Task CreateHospitalRequestAsync(HospitalRequest request)
        {
            await _context.HospitalRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
    }
}
