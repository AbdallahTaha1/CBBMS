using System.ComponentModel.DataAnnotations;

namespace CBBMS.ViewModels
{
    public class HospitalRequestViewModel
    {
        [Required, MaxLength(5), Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [Required, MaxLength(10), Display(Name = "Patient Status")]
        public string PatientStatus { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
