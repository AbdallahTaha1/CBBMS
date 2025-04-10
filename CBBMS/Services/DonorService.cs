using CBBMS.Data;
using CBBMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CBBMS.Services
{
    public class DonorService : IDonorService
    {
        private readonly ApplicationDbContext _context;

        public DonorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DonationRequest>> GetUserDonations(string userId)
        {
            return await _context.DonationRequests
                .Include(d => d.BloodBank)
               .Where(d => d.DonorId == userId)
               .OrderByDescending(d => d.DonationDate)
               .ToListAsync();
        }
        public async Task<List<SelectListItem>> GetBloodBanksAsync()
        {
            return await _context.BloodBanks
                .Select(b => new SelectListItem
                {
                    Value = b.BloodBankId.ToString(),
                    Text = b.FullName
                })
                .ToListAsync();
        }

        public async Task<BloodBank> GetBloodBankByIdAsync(string bloodBankId)
        {
            return await _context.BloodBanks
                .FirstOrDefaultAsync(b => b.BloodBankId == bloodBankId);
        }

        public async Task<Donor> GetDonorByUserIdAsync(string userId)
        {
            return await _context.Donors
                .FirstOrDefaultAsync(d => d.DonorId == userId);
        }

        public async Task CreateDonationRequestAsync(DonationRequest donation)
        {
            await _context.DonationRequests.AddAsync(donation);
            await _context.SaveChangesAsync();
        }
    }
}
