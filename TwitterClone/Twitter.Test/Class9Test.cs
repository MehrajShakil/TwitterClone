using TwitterClone.Domain.Entities;

namespace Twitter.Test
{
    public class Class9Test
    {
        public void Run()
        {
            var notifications = new List<Notification>()
            {
                new LikeNotification(Guid.NewGuid()),
                new CommentNotification(Guid.NewGuid()),
                new FriendRequestNotification(Guid.NewGuid()),
                new MentionNotification(Guid.NewGuid()),
                new SystemNotification()
            };

            foreach (var notification in notifications)
            {
                Console.WriteLine(notification.GetMessage());
            }
        }
    }
}
