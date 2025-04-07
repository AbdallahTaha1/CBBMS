using System.ComponentModel.DataAnnotations;

namespace CBBMS.Models
{
    public class Hospital
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string? ManagerId { get; set; }   // FK to ApplicationUser

        public ApplicationUser? Manager { get; set; }
    }
}
