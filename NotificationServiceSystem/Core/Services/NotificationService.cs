using NotificationServiceSystem.Core.Entities;
using NotificationServiceSystem.Core.Interfaces.Repositories;
using NotificationServiceSystem.Core.Interfaces.Services;

namespace NotificationServiceSystem.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            await _notificationRepository.AddNotificationAsync(notification);
        }

        public async Task DeleteNotificationAsync(int id)
        {
            await _notificationRepository.DeleteNotificationAsync(id);
        }

        public async Task<Notification> GetNotificationAsync(int id)
        {
            return await _notificationRepository.GetNotificationAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            return await _notificationRepository.GetNotificationsAsync();
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByReceiverAsync(string receiver)
        {
            return await _notificationRepository.GetNotificationsByReceiverAsync(receiver);
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _notificationRepository.UpdateNotificationAsync(notification);
        }
    }
}
