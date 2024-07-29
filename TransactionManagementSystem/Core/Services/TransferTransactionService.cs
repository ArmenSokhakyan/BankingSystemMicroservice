using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Core.Interfaces.Services;

namespace TransactionManagementSystem.Core.Services
{
    public class TransferTransactionService : ITransferTransactionService
    {
        private readonly ITransferTransactionRepository _transferTransactionRepository;

        public TransferTransactionService(ITransferTransactionRepository transferTransactionRepository)
        {
            _transferTransactionRepository = transferTransactionRepository;
        }

        public async Task AddTransactionAsync(TransferTransaction transaction)
        {
            await _transferTransactionRepository.AddTransactionAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transferTransactionRepository.DeleteTransactionAsync(id);
        }

        public async Task<TransferTransaction> GetTransactionByIdAsync(int id)
        {
            return await _transferTransactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task<IEnumerable<TransferTransaction>> GetTransactionsAsync()
        {
            return await _transferTransactionRepository.GetTransactionsAsync();
        }

        public async Task<IEnumerable<TransferTransaction>> GetTransactionsBySourceAccountIdAsync(int accountId)
        {
            return await _transferTransactionRepository.GetTransactionsBySourceAccountIdAsync(accountId);
        }

        public async Task<IEnumerable<TransferTransaction>> GetTransactionsByDestinationAccountIdAsync(int accountId)
        {
            return await _transferTransactionRepository.GetTransactionsByDestinationAccountIdAsync(accountId);
        }

        public async Task UpdateTransactionAsync(TransferTransaction transaction)
        {
            await _transferTransactionRepository.UpdateTransactionAsync(transaction);
        }
    }
}
