using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Core.Interfaces.Services
{
    public interface IInTransactionService
    {
        public Task<IEnumerable<InTransaction>> GetTransactionsAsync();
        public Task<InTransaction> GetTransactionByIdAsync(int id);
        public Task<IEnumerable<InTransaction>> GetTransactionsByAccountIdAsync(int accountId);
        public Task AddTransactionAsync(InTransaction transaction);
        public Task UpdateTransactionAsync(InTransaction transaction);
        public Task DeleteTransactionAsync(int id);
        public Task<IEnumerable<SummeryDTO>> GetAccountSummeryAsync(DateTime startDate, DateTime endDate);
    }
}
