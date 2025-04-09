using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CBBMS.Models
{
    public class HospitalRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string BloodType { get; set; }
        [Required]
        [MaxLength(10)]
        public string PatientStatus { get; set; }
        [Required]
        public int Quantity { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
