using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Infrastructure.Data;

namespace TransactionManagementSystem.Infrastructure.Repositories
{
    public class OutTransactionRepository : BaseRepository, IOutTransactionRepository
    {
        private readonly TransactionContext _transactionContext;

        public OutTransactionRepository(TransactionContext transactionContext) 
            : base(transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public async Task AddTransactionAsync(OutTransaction transaction)
        {
            _transactionContext.outTransactions.Add(transaction);
            await _transactionContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _transactionContext.outTransactions.FindAsync(id);

            if (transaction != null) 
            {
                _transactionContext.outTransactions.Remove(transaction);
                await _transactionContext.SaveChangesAsync();
            }
        }

        public async Task<OutTransaction> GetTransactionByIdAsync(int id)
        {
            return await _transactionContext.outTransactions.FindAsync(id);    
        }

        public async Task<IEnumerable<OutTransaction>> GetTransactionsAsync()
        {
            return await _transactionContext.outTransactions.ToListAsync();
        }

        public async Task<IEnumerable<OutTransaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _transactionContext.outTransactions.Where(t => t.AccountId == accountId).ToListAsync();
        }

        public async Task<double> GetTotalAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            return await _transactionContext.outTransactions.Where(i => i.AccountId == accountId && i.TransactionDate >= startDate && i.TransactionDate < endDate).SumAsync(i => i.Amount);
        }

        public async Task UpdateTransactionAsync(OutTransaction transaction)
        {
            _transactionContext.outTransactions.Update(transaction);
            await _transactionContext.SaveChangesAsync();
        }
    }
}
