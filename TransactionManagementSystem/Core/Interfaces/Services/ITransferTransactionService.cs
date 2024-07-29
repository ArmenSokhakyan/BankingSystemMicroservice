using TransactionManagementSystem.Core.Entities;

namespace TransactionManagementSystem.Core.Interfaces.Services
{
    public interface ITransferTransactionService
    {
        public Task<IEnumerable<TransferTransaction>> GetTransactionsAsync();
        public Task<TransferTransaction> GetTransactionByIdAsync(int id);
        public Task<IEnumerable<TransferTransaction>> GetTransactionsBySourceAccountIdAsync(int accountId);
        public Task<IEnumerable<TransferTransaction>> GetTransactionsByDestinationAccountIdAsync(int accountId);
        public Task AddTransactionAsync(TransferTransaction transaction);
        public Task UpdateTransactionAsync(TransferTransaction transaction);
        public Task DeleteTransactionAsync(int id);
    }
}
