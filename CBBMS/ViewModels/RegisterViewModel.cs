using System.ComponentModel.DataAnnotations;

namespace CBBMS.ViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Account Type")]
        public string RoleType { get; set; } // Donor / Hospital / BloodBank
    }
}
