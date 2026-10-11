namespace TwitterClone.Application.Dtos
{
    public class CreateBookmarkDto
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
    }
}
