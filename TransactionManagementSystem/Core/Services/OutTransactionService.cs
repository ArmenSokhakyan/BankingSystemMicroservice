using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Core.Interfaces.Services;

namespace TransactionManagementSystem.Core.Services
{
    public class OutTransactionService : IOutTransactionService
    {
        private readonly IOutTransactionRepository _outgoingTransactionRepository;

        public OutTransactionService(IOutTransactionRepository outgoingTransactionRepository)
        {
            _outgoingTransactionRepository = outgoingTransactionRepository;
        }

        public async Task AddTransactionAsync(OutTransaction transaction)
        {
            await _outgoingTransactionRepository.AddTransactionAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _outgoingTransactionRepository.DeleteTransactionAsync(id);
        }

        public async Task<OutTransaction> GetTransactionByIdAsync(int id)
        {
            return await _outgoingTransactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task<IEnumerable<OutTransaction>> GetTransactionsAsync()
        {
            return await _outgoingTransactionRepository.GetTransactionsAsync();
        }

        public async Task<IEnumerable<OutTransaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _outgoingTransactionRepository.GetTransactionsByAccountIdAsync(accountId);
        }

        public async Task UpdateTransactionAsync(OutTransaction transaction)
        {
            await _outgoingTransactionRepository.UpdateTransactionAsync(transaction);
        }
    }
}
