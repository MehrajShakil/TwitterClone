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
    }
}
