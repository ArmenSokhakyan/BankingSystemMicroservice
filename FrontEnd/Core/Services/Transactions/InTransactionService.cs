using FrontEnd.Core.Common;
using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Transactions;
using System.Reflection.Metadata;

namespace FrontEnd.Core.Services.Transactions
{
    public class InTransactionService : BaseService, IInTransactionService
    {
        private readonly IHttpClientFactory _httpClient;

        public InTransactionService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<T> AddIncomingTransactionAsync<T>(InTransactionDTO incomingTransactionDTO)
        {
            return await this.SendPostAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/InTransaction",
                Data = incomingTransactionDTO
            });
        }

        public async Task<T> DeleteIncomingTransactionAsync<T>(int id)
        {
            return await this.SendDeleteAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/InTransaction/{id}",
            });
        }

        public async Task<T> GetIncomingTransactionsAsync<T>()
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/InTransaction"
            });
        }

        public async Task<T> GetTransactionByIdAsync<T>(int id)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/InTransaction/{id}"
            });
        }

        public async Task<T> GetTrsansactionsByAccountId<T>(int accountId)
        {
            return await this.SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/InTransaction/account/{accountId}"
            });
        }

        public async Task<T> UpdateIncomingTransactionAsync<T>(InTransactionDTO incomingTransactionDTO, int id)
        {
            return await this.SendPutAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + $"/api/InTransaction/{id}",
                Data = incomingTransactionDTO
            });
        }
    }
}
