using FrontEnd.Presentation.API.DTOs.Transactions;

namespace FrontEnd.Core.Interfaces.Services.Transactions
{
    public interface IInTransactionService : IBaseService
    {
        public Task<T> GetIncomingTransactionsAsync<T>();

        public Task<T> GetTransactionByIdAsync<T>(int id);

        public Task<T> GetTrsansactionsByAccountId<T>(int accountId);

        public Task<T> AddIncomingTransactionAsync<T>(InTransactionDTO transactionDTO);

        public Task<T> UpdateIncomingTransactionAsync<T>(InTransactionDTO transactionDTO, int id);
        
        public Task<T> DeleteIncomingTransactionAsync<T>(int id);

    }
}
