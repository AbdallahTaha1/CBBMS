
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBBMS.Models
{
    public class Hospital
    {
        [Key, ForeignKey("User")]
        public string HospitalId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<HospitalRequest> HospitalRequests { get; set; }
    }
}
