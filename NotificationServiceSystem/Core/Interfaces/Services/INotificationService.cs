using NotificationServiceSystem.Core.Entities;

namespace NotificationServiceSystem.Core.Interfaces.Services
{
    public interface INotificationService
    {
        public Task<IEnumerable<Notification>> GetNotificationsAsync();

        public Task<IEnumerable<Notification>> GetNotificationsByReceiverAsync(string receiver);

        public Task<Notification> GetNotificationAsync(int id);

        public Task AddNotificationAsync(Notification notification);

        public Task UpdateNotificationAsync(Notification notification);

        public Task DeleteNotificationAsync(int id);
    }
}
