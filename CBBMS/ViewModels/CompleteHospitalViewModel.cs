using System.ComponentModel.DataAnnotations;

namespace CBBMS.ViewModels
{
    public class CompleteHospitalViewModel
    {
        [Required, MaxLength(100), Display(Name ="Full Name")]
        public string FullName { get; set; }
        
        [Required, MaxLength(20)]
        public string City { get; set; }
    }
}
