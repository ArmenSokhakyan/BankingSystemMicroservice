using Microsoft.EntityFrameworkCore;
using ReferanceManagementSystem.Core.Entities;

namespace ReferanceManagementSystem.Infrastructure.Data
{
    public class RMSContext : DbContext
    {
        public RMSContext(DbContextOptions<RMSContext> options) : base(options) { }

        //Entity DbSet
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
