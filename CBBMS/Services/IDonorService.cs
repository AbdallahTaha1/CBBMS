using CBBMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBBMS.Services
{
    public interface IDonorService
    {
        Task<List<DonationRequest>> GetUserDonations(string userId);
        Task CreateDonationRequestAsync(DonationRequest donation);
        Task<BloodBank> GetBloodBankByIdAsync(string bloodBankId);
        Task<List<SelectListItem>> GetBloodBanksAsync();
        Task<Donor> GetDonorByUserIdAsync(string userId);
    }
}