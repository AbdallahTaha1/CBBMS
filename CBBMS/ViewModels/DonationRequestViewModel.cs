using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBBMS.ViewModels
{
    public class DonationRequestViewModel
    {
        public string BloodBankId { get; set; }

        public IEnumerable<SelectListItem> BloodBanks { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
