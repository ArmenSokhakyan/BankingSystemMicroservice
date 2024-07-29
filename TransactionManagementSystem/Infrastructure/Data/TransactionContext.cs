using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Core.Entities;

namespace TransactionManagementSystem.Infrastructure.Data
{
    public class TransactionContext: DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options) { }

        //Entity DbSet
        public DbSet<InTransaction> inTransactions { get; set; }
        public DbSet<OutTransaction> outTransactions { get; set; }
        public DbSet<TransferTransaction> transferTransactions { get; set; }
    }
}
