using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBBMS.Models
{
    public class BloodBank
    {
        [Key, ForeignKey("User")]
        public string BloodBankId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, StringLength(20)]
        public string City { get; set; }
        
        public ApplicationUser User { get; set; }

        public ICollection<BloodStockUnits> BloodStockUnits { get; set; }

    }
}
