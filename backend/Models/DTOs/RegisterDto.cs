using System.ComponentModel.DataAnnotations;

namespace backend.backend.Models.DTOs
{
    public record RegisterDto
    (
        [Required, StringLength(50, MinimumLength = 2)] string FirstName,
        [Required, StringLength(50, MinimumLength = 2)] string LastName,

        [Required, StringLength(255)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            ErrorMessage = "Invalid email.")]
        string Email,

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,128}$",
            ErrorMessage = "Password must be at least 8 characters long.")]
        string Password
    );
}
