using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CBBMS.Models
{
    public class DonationRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BloodType { get; set; }
        public DateTime DonationDate { get; set; }
        public bool VirusTestResult { get; set; }
        public bool? IsAccepted { get; set; }

        public string DonorId { get; set; }
        [ForeignKey("DonorId")]
        public Donor Donor { get; set; }
        [Required]
        public string BloodBankId { get; set; }  // FK to BloodBank

        [ForeignKey("BloodBankId")]
        public BloodBank BloodBank { get; set; }
    }
}
