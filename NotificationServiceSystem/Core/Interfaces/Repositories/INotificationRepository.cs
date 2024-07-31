using NotificationServiceSystem.Core.Entities;

namespace NotificationServiceSystem.Core.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        public Task<IEnumerable<Notification>> GetNotificationsAsync();

        public Task<IEnumerable<Notification>> GetNotificationsByReceiverAsync(string receiver);

        public Task<Notification> GetNotificationAsync(int id);

        public Task AddNotificationAsync(Notification notification);
        
        public Task UpdateNotificationAsync(Notification notification);
        
        public Task DeleteNotificationAsync(int id);
    }
}
