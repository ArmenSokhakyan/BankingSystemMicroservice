using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Infrastructure.Data;

namespace TransactionManagementSystem.Infrastructure.Repositories
{
    public class InTransactionRepository : BaseRepository, IInTransactionRepository
    {
        private readonly TransactionContext _transactionContext;

        public InTransactionRepository(TransactionContext transactionContext)
            : base(transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public async Task AddTransactionAsync(InTransaction transaction)
        {
            _transactionContext.inTransactions.Add(transaction);
            await _transactionContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _transactionContext.inTransactions.FindAsync(id);

            if(transaction != null)
            {
                _transactionContext.inTransactions.Remove(transaction);
                await _transactionContext.SaveChangesAsync();
            }
        }

        public async Task<double> GetTotalAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            return await _transactionContext.inTransactions.Where(i => i.AccountId == accountId && i.TransactionDate >= startDate && i.TransactionDate < endDate).SumAsync(i => i.Amount);
        }

        public async Task<InTransaction> GetTransactionByIdAsync(int id)
        {
            return await _transactionContext.inTransactions.FindAsync(id);
        }

        public async Task<IEnumerable<InTransaction>> GetTransactionsAsync()
        {
            return await _transactionContext.inTransactions.ToListAsync();
        }

        public async Task<IEnumerable<InTransaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _transactionContext.inTransactions.Where(t => t.AccountId == accountId).ToListAsync();
        }

        public async Task UpdateTransactionAsync(InTransaction transaction)
        {
            _transactionContext.inTransactions.Update(transaction);
            await _transactionContext.SaveChangesAsync();
        }
    }
}
