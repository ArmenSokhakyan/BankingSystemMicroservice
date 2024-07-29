using FrontEnd.Presentation.API.DTOs.Transactions;

namespace FrontEnd.Core.Interfaces.Services.Transactions
{
    public interface IOutTransactionService : IBaseService
    {
        public Task<T> GetIncomingTransactionsAsync<T>();

        public Task<T> GetTransactionByIdAsync<T>(int id);

        public Task<T> GetTrsansactionsByAccountId<T>(int accountId);

        public Task<T> AddIncomingTransactionAsync<T>(OutTransactionDTO transactionDTO);

        public Task<T> UpdateIncomingTransactionAsync<T>(OutTransactionDTO transactionDTO, int id);
        
        public Task<T> DeleteIncomingTransactionAsync<T>(int id);

    }
}
