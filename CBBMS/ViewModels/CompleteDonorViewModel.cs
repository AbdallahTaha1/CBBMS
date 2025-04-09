using CBBMS.Models;
using System.ComponentModel.DataAnnotations;

namespace CBBMS.ViewModels
{
    public class CompleteDonorViewModel
    {
        [Key]
        [MaxLength(20)]
        public string NationalID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(5)]
        public string BloodType { get; set; }
        public ApplicationUser User { get; set; }
    }
}
