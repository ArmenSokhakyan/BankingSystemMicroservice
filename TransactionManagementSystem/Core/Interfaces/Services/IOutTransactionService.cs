using TransactionManagementSystem.Core.Entities;

namespace TransactionManagementSystem.Core.Interfaces.Services
{
    public interface IOutTransactionService
    {
        public Task<IEnumerable<OutTransaction>> GetTransactionsAsync();
        public Task<OutTransaction> GetTransactionByIdAsync(int id);
        public Task<IEnumerable<OutTransaction>> GetTransactionsByAccountIdAsync(int accountId);
        public Task AddTransactionAsync(OutTransaction transaction);
        public Task UpdateTransactionAsync(OutTransaction transaction);
        public Task DeleteTransactionAsync(int id);
    }
}
