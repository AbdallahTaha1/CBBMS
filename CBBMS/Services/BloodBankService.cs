using CBBMS.Data;
using CBBMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CBBMS.Services
{
    public class BloodBankService : IBloodBankService
    {
        private readonly ApplicationDbContext _context;

        public BloodBankService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------- Donations Management -----------------
        public async Task<List<DonationRequest>> GetPendingDonationsAsync(string UserId)
        {
            return await _context.DonationRequests
                .Include(d => d.Donor)
                .Where(d => d.IsAccepted == null && d.BloodBankId == UserId)
                .ToListAsync();
        }

        public async Task<bool> AcceptDonationAsync(int id)
        {
            var donation = await _context.DonationRequests.FindAsync(id);

            if (donation == null) return false;

            donation.IsAccepted = true;

            var bloodBag = new BloodStockUnits
            {
                BloodType = donation.BloodType,
                DonationDate = donation.DonationDate,
                ExpiryDate = DateTime.Now.AddDays(42),
                IsAvailable = true,
                BloodBankId = donation.BloodBankId
            };

            await _context.BloodStockUnits.AddAsync(bloodBag);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectDonationAsync(int id)
        {
            var donation = await _context.DonationRequests.FindAsync(id);

            if (donation == null) return false;

            donation.IsAccepted = false;
            await _context.SaveChangesAsync();

            return true;
        }

        // ----------------- Blood Stock Management -----------------
        public async Task<List<BloodStockUnits>> GetBloodStockAsync(string bloodBankId)
        {
            return await _context.BloodStockUnits
                .Where(u => u.BloodBankId == bloodBankId)
                .ToListAsync();
        }

        // ----------------- Hospital Requests Management -----------------
        public async Task<List<HospitalRequest>> GetHospitalRequestsAsync()
        {
            return await _context.HospitalRequests
                .Include(r => r.Hospital)
                .Where(r => r.Status == "Pending")
                .ToListAsync();
        }

        public async Task<string> AcceptBloodRequestAsync(int requestId)
        {
            var request = await _context.HospitalRequests
                .Include(r => r.Hospital)
                .FirstOrDefaultAsync(r => r.Id == requestId);

            if (request == null || request.Status != "Pending")
                return "Request not found or already processed.";

            // Check availability
            var availableUnits = await _context.BloodStockUnits
                .Where(b => b.BloodType == request.BloodType &&
                            b.IsAvailable &&
                            b.ExpiryDate > DateTime.Now)
                .Take(request.Quantity)
                .ToListAsync();

            if (availableUnits.Count < request.Quantity)
                return "Not enough blood units available.";


            // Update stock units
            foreach (var unit in availableUnits)
            {
                unit.IsAvailable = false;
            }

            request.Status = "Accepted";

            await _context.SaveChangesAsync();
            return "Request accepted successfully.";
            ;
        }

        public async Task<bool> RejectBloodRequestAsync(int requestId)
        {
            var request = await _context.HospitalRequests.FindAsync(requestId);

            if (request == null || request.Status != "Pending")
                return false;

            request.Status = "Rejected";

            await _context.SaveChangesAsync();
            return true;
        }
    }
}