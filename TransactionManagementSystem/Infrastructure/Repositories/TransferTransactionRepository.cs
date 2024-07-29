using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Infrastructure.Data;

namespace TransactionManagementSystem.Infrastructure.Repositories
{
    public class TransferTransactionRepository : BaseRepository, ITransferTransactionRepository
    {
        private readonly TransactionContext _transactionContext;

        public TransferTransactionRepository(TransactionContext transactionContext)
            : base(transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public async Task AddTransactionAsync(TransferTransaction transaction)
        {
            _transactionContext.transferTransactions.Add(transaction);
            await _transactionContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _transactionContext.transferTransactions.FindAsync(id);

            if (transaction != null) 
            {
                _transactionContext.transferTransactions.Remove(transaction);
                await _transactionContext.SaveChangesAsync();
            }
        }

        public async Task<TransferTransaction> GetTransactionByIdAsync(int id)
        {
            return await _transactionContext.transferTransactions.FindAsync(id);    
        }

        public async Task<IEnumerable<TransferTransaction>> GetTransactionsAsync()
        {
            return await _transactionContext.transferTransactions.ToListAsync();
        }

        public async Task<IEnumerable<TransferTransaction>> GetTransactionsBySourceAccountIdAsync(int accountId)
        {
            return await _transactionContext.transferTransactions.Where(t => t.SourceAccountId == accountId).ToListAsync();
        }

        public async Task<IEnumerable<TransferTransaction>> GetTransactionsByDestinationAccountIdAsync(int accountId)
        {
            return await _transactionContext.transferTransactions.Where(t => t.DestinationAccountId == accountId).ToListAsync();
        }

        public async Task UpdateTransactionAsync(TransferTransaction transaction)
        {
            _transactionContext.transferTransactions.Update(transaction);
            await _transactionContext.SaveChangesAsync();
        }
    }
}
