using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CBBMS.Models
{
    public class DonationRequest
    {
        [Key]
        public int Id { get; set; }
        public string BloodType { get; set; }
        public DateTime DonationDate { get; set; }
        public bool? VirusTestResult { get; set; }
        public bool IsAccepted { get; set; } = false;

        public string DonorId { get; set; }
        [ForeignKey("DonorId")]
        public ApplicationUser Donor { get; set; }

        public string BloodBankId { get; set; }  // FK to BloodBank

        [ForeignKey("BloodBankId")]
        public BloodBank BloodBank { get; set; }
    }
}
