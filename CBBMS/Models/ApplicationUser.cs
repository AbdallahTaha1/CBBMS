using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CBBMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(5)]
        public string BloodType { get; set; }       // A+, A-, B+, B-, O+, O-, AB+, AB-

        [StringLength(20)]
        public string City { get; set; }

        public bool CanDonate { get; set; } = true;

        public ICollection<DonationRequest> Donations { get; set; }
    }
}
