using CBBMS.Models;

namespace CBBMS.Services
{
    public interface IBloodBankService
    {
        Task<string> AcceptBloodRequestAsync(int id);
        Task<bool> AcceptDonationAsync(int id);
        Task<List<BloodStockUnits>> GetBloodStockAsync(string bloodBankId);
        Task<List<HospitalRequest>> GetHospitalRequestsAsync();
        Task<List<DonationRequest>> GetPendingDonationsAsync(string UserId);
        Task<bool> RejectBloodRequestAsync(int id);
        Task<bool> RejectDonationAsync(int id);
    }
}