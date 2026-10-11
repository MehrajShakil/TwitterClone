using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class CreateMessageDto
    {
        public required Guid SenderId { get; set; }

        public required Guid ReceiverId { get; set; }

        [Required]
        [StringLength(1000)]
        public required string Content { get; set; }
    }
}
