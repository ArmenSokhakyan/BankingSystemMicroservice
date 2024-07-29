using FrontEnd.Presentation.API.DTOs.Transactions;

namespace FrontEnd.Core.Interfaces.Services.Transactions
{
    public interface ITransferTransactionService : IBaseService
    {
        public Task<T> GetIncomingTransactionsAsync<T>();

        public Task<T> GetTransactionByIdAsync<T>(int id);

        public Task<T> GetTrsansactionsBySourceAccountId<T>(int accountId);
        public Task<T> GetTrsansactionsByDestinationAccountId<T>(int accountId);

        public Task<T> AddIncomingTransactionAsync<T>(TransferTransactionDTO transactionDTO);

        public Task<T> UpdateIncomingTransactionAsync<T>(TransferTransactionDTO transactionDTO, int id);
        
        public Task<T> DeleteIncomingTransactionAsync<T>(int id);

    }
}
