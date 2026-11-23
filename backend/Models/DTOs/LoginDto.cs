using System.ComponentModel.DataAnnotations;

namespace backend.backend.Models.DTOs
{
    public record LoginDto
    (
        [Required] string Email,
        [Required] string Password
    );
}
