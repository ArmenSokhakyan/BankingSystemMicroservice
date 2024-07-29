using TransactionManagementSystem.Core.Entities;

namespace TransactionManagementSystem.Core.Interfaces.Repositories
{
    public interface IOutTransactionRepository
    {
        public Task<IEnumerable<OutTransaction>> GetTransactionsAsync();
        
        public Task<OutTransaction> GetTransactionByIdAsync(int id);
        
        public Task<IEnumerable<OutTransaction>> GetTransactionsByAccountIdAsync(int accountId);

        public Task<double> GetTotalAsync(int accountId, DateTime startDate, DateTime endDate);

        public Task AddTransactionAsync(OutTransaction transaction);
        
        public Task UpdateTransactionAsync(OutTransaction transaction);
        
        public Task DeleteTransactionAsync(int id);
    }
}
