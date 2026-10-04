namespace TwitterClone.Application.Dtos
{
    public class TweetDto
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
