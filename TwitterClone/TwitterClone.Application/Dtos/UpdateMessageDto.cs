using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class UpdateMessageDto
    {
        [Required]
        [StringLength(1000)]
        public required string Content { get; set; }
    }
}
