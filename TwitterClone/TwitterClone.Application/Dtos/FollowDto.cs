namespace TwitterClone.Application.Dtos
{
    public class FollowDto
    {
        public required Guid Id { get; set; }
        public required Guid FollowerId { get; set; }
        public required Guid FollowingId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
