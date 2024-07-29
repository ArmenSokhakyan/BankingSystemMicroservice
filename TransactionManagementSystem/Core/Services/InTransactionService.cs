using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Core.Services
{
    public class InTransactionService : IInTransactionService
    {
        private readonly IInTransactionRepository _inTransactionRepository;

        public InTransactionService(IInTransactionRepository inTransactionRepository)
        {
            _inTransactionRepository = inTransactionRepository;
        }

        public async Task AddTransactionAsync(InTransaction transaction)
        {
            await _inTransactionRepository.AddTransactionAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _inTransactionRepository.DeleteTransactionAsync(id);
        }

        public async Task<IEnumerable<SummeryDTO>> GetAccountSummeryAsync(DateTime startDate, DateTime endDate)
        {
            return await _inTransactionRepository.AccountSummeriesAsync(startDate, endDate);
        }

        public async Task<InTransaction> GetTransactionByIdAsync(int id)
        {
            return await _inTransactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task<IEnumerable<InTransaction>> GetTransactionsAsync()
        {
            return await _inTransactionRepository.GetTransactionsAsync();
        }

        public async Task<IEnumerable<InTransaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _inTransactionRepository.GetTransactionsByAccountIdAsync(accountId);
        }

        public async Task UpdateTransactionAsync(InTransaction transaction)
        {
            await _inTransactionRepository.UpdateTransactionAsync(transaction);
        }
    }
}
