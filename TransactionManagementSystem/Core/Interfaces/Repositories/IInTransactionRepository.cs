using System.Security.Principal;
using TransactionManagementSystem.Core.Entities;

namespace TransactionManagementSystem.Core.Interfaces.Repositories
{
    public interface IInTransactionRepository : IBaseRepository
    {
        public Task<IEnumerable<InTransaction>> GetTransactionsAsync();
        
        public Task<InTransaction> GetTransactionByIdAsync(int id);
        
        public Task<IEnumerable<InTransaction>> GetTransactionsByAccountIdAsync(int accountId);
        
        public Task<double> GetTotalAsync(int accountId, DateTime startDate, DateTime endDate);
        
        public Task AddTransactionAsync(InTransaction transaction);
        
        public Task UpdateTransactionAsync(InTransaction transaction);
        
        public Task DeleteTransactionAsync(int id);
    }
}
