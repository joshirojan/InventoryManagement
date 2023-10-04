using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Dtos.AuthDto
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
