using FrontEnd.Core.Common;
using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Transactions;
using System.Reflection.Metadata;

namespace FrontEnd.Core.Services.Transactions
{
    public class TransferTransactionService : BaseService, ITransferTransactionService
    {
        private readonly IHttpClientFactory _httpClient;

        public TransferTransactionService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<T> AddIncomingTransactionAsync<T>(TransferTransactionDTO transactionDTO)
        {
            return await this.SendPostAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/TransferTransaction",
                Data = transactionDTO
            });
        }

        public async Task<T> DeleteIncomingTransactionAsync<T>(int id)
        {
            return await this.SendDeleteAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/TransferTransaction/{id}",
            });
        }

        public async Task<T> GetIncomingTransactionsAsync<T>()
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/TransferTransaction"
            });
        }

        public async Task<T> GetTransactionByIdAsync<T>(int id)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/TransferTransaction/{id}"
            });
        }

        public async Task<T> GetTrsansactionsBySourceAccountId<T>(int accountId)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/TransferTransaction/sourceAccount/{accountId}"
            });
        }

        public async Task<T> GetTrsansactionsByDestinationAccountId<T>(int accountId)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/TransferTransaction/destinationAccount/{accountId}"
            });
        }

        public async Task<T> UpdateIncomingTransactionAsync<T>(TransferTransactionDTO transactionDTO, int id)
        {
            return await this.SendPutAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/TransferTransaction/{id}",
                Data = transactionDTO
            });
        }
    }
}
