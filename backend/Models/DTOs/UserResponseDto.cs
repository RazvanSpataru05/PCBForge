namespace backend.backend.Models.DTOs
{
    public record UserResponseDto
    {
        public int? Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; } 
        public string? Email { get; init; } 
    }
}
