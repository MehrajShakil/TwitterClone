using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface INotificationRepository
    {
        Notification AddNotification(Notification notification);
        Notification UpdateNotification(Notification notification);
        bool DeleteNotification(Notification notification);
        int DeleteNotificationsByUserId(Guid userId);
        Notification? GetNotificationById(Guid id);
        List<Notification> GetNotifications(Guid? userId, string? type, bool? isRead);
    }
}
