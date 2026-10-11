namespace TwitterClone.Application.Dtos
{
    public class MessageDto
    {
        public required Guid Id { get; set; }
        public required Guid SenderId { get; set; }
        public required Guid ReceiverId { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
