using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CBBMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string RoleType { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
