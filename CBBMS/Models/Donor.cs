using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBBMS.Models
{
    public class Donor
    {
        [Key, ForeignKey("User")]
        public string DonorId { get; set; }

        [Required, MaxLength(20)]
        public string NationalID { get; set; }

        [Required, MaxLength(20)]
        public string FullName { get; set; }

        [Required, MaxLength(20)]
        public string City { get; set; }

        [Required, MaxLength(5)]
        public string BloodType { get; set; }

        public bool CanDonate { get; set; } = true;
       
        public ApplicationUser User { get; set; }

        public virtual ICollection<DonationRequest> Donations { get; set; }
    }
}
