namespace TwitterClone.Application.Dtos
{
    public class UserDto
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }

    }
}
