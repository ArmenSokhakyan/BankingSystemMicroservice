using Microsoft.EntityFrameworkCore;
using NotificationServiceSystem.Core.Entities;
using NotificationServiceSystem.Core.Interfaces.Repositories;
using NotificationServiceSystem.Infrastructure.Data;

namespace NotificationServiceSystem.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationContext _notificationContext;

        public NotificationRepository(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _notificationContext.Notifications.Add(notification);
            await _notificationContext.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notification = await _notificationContext.Notifications.FindAsync(id);

            if (notification != null)
            {
                _notificationContext.Notifications.Remove(notification);
                await _notificationContext.SaveChangesAsync();

            }
        }

        public async Task<Notification> GetNotificationAsync(int id)
        {
            return await _notificationContext.Notifications.FindAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            return await _notificationContext.Notifications.ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByReceiverAsync(string receiver)
        {
            return await _notificationContext.Notifications.Where(n => n.Receiver == receiver).ToListAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            _notificationContext.Notifications.Update(notification);
            await _notificationContext.SaveChangesAsync();
        }
    }
}
