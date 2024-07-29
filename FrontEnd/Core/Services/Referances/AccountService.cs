using FrontEnd.Core.Common;
using FrontEnd.Core.Interfaces.Services.Referances;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Referances;
using System.Reflection.Metadata;

namespace FrontEnd.Core.Services.Referances
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IHttpClientFactory _httpClient;

        public AccountService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> AddAccount<T>(AccountDTO accountDTO)
        {
            return await SendPostAsync<T>(new ApiRequest()
            {
                Url = Constants.AccountUrlBase + "/api/Account",
                Data = accountDTO
            });
        }

        public async Task<T> DeleteAccount<T>(int id)
        {
            return await SendDeleteAsync<T>(new ApiRequest()
            {
                Url = Constants.AccountUrlBase + $"/api/Account/{id}"
            });
        }

        public async Task<T> GetAccountAsync<T>(int id)
        {
            return await SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.AccountUrlBase + $"/api/Account/{id}",
                Data = id
            });
        }

        public async Task<T> GetAccountsAsync<T>()
        {
            return await SendGetAsync<T>(new ApiRequest()
            {
                Url = Constants.AccountUrlBase + "/api/Account"
            });
        }

        public async Task<T> UpdateAccount<T>(int id, AccountDTO accountDTO)
        {
            return await SendPutAsync<T>(new ApiRequest()
            {
                Url = Constants.AccountUrlBase + $"/api/Account/{id}",
                Data = accountDTO
            });
        }
    }
}
