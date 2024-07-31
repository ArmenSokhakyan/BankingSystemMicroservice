using Microsoft.EntityFrameworkCore;
using NotificationServiceSystem.Core.Entities;

namespace NotificationServiceSystem.Infrastructure.Data
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options) { }

        //Entity DbSet
        public DbSet<Notification> Notifications { get; set; }
    }
}
