using CBBMS.Models;

namespace CBBMS.Services
{
    public interface IHospitalService
    {
        Task CreateHospitalRequestAsync(HospitalRequest request);
        Task<Hospital> GetHospitalByUserAsync(string userId);
    }
}