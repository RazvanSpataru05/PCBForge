using PCBForge.backend.Models;

namespace backend.backend.Models.DTOs
{
    public record UserResponseDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Role { get; init; } = null!;
    }
}
