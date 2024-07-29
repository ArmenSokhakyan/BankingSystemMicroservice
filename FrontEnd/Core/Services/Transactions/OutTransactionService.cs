using FrontEnd.Core.Common;
using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Transactions;
using System.Reflection.Metadata;

namespace FrontEnd.Core.Services.Transactions
{
    public class OutTransactionService : BaseService, IOutTransactionService
    {
        private readonly IHttpClientFactory _httpClient;

        public OutTransactionService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<T> AddIncomingTransactionAsync<T>(OutTransactionDTO transactionDTO)
        {
            return await this.SendPostAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/OutTransaction",
                Data = transactionDTO
            });
        }

        public async Task<T> DeleteIncomingTransactionAsync<T>(int id)
        {
            return await this.SendDeleteAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/OutTransaction/{id}",
            });
        }

        public async Task<T> GetIncomingTransactionsAsync<T>()
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/OutTransaction"
            });
        }

        public async Task<T> GetTransactionByIdAsync<T>(int id)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/OutTransaction/{id}"
            });
        }

        public async Task<T> GetTrsansactionsByAccountId<T>(int accountId)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/OutTransaction/account/{accountId}"
            });
        }

        public async Task<T> UpdateIncomingTransactionAsync<T>(OutTransactionDTO transactionDTO, int id)
        {
            return await this.SendPutAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/OutTransaction/{id}",
                Data = transactionDTO
            });
        }
    }
}
