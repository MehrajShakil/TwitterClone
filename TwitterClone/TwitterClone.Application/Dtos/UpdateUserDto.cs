using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Only letters, numbers and _ are allowed.")]
        public required string Username { get; set; }

        [StringLength(160)]
        public string Bio { get; set; } = string.Empty;

        [StringLength(200)]
        public string? AvatarUrl { get; set; }

    }
}
