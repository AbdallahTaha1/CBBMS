using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBBMS.Models
{
    public class BloodStockUnits
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string BloodType { get; set; }
        [Required]
        public DateTime DonationDate { get; set; }

        public DateTime ExpiryDate { get; set; } 

        public bool IsAvailable { get; set; }

        public string BloodBankId { get; set; }  // FK to BloodBank

        [ForeignKey("BloodBankId")]
        public BloodBank BloodBank { get; set; }
    }
}
