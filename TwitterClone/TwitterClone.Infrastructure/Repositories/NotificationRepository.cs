using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly List<Notification> _notifications = new List<Notification>();

        public Notification AddNotification(Notification notification)
        {
            _notifications.Add(notification);

            return notification;
        }

        public Notification UpdateNotification(Notification notification)
        {
            _notifications.RemoveAll(n => n.Id == notification.Id);
            _notifications.Add(notification);
            return notification;
        }

        public bool DeleteNotification(Notification notification)
        {
            return _notifications.Remove(notification);
        }

        public int DeleteNotificationsByUserId(Guid userId)
        {
            return _notifications.RemoveAll(n => n.UserId == userId);
        }

        public Notification? GetNotificationById(Guid id)
        {
            return _notifications.SingleOrDefault(n => n.Id == id);
        }

        public List<Notification> GetNotifications(Guid? userId, string? type, bool? isRead)
        {
            return _notifications
                .Where(n => (userId == null || n.UserId == userId) &&
                            (type == null || string.Equals(n.Type, type, StringComparison.OrdinalIgnoreCase)) &&
                            (isRead == null || n.IsRead == isRead))
                .ToList();
        }
    }
}
