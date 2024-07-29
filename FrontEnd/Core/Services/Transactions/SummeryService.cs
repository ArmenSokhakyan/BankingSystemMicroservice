using FrontEnd.Core.Common;
using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Transactions;

namespace FrontEnd.Core.Services.Transactions
{
    public class SummeryService : BaseService, ISummeryService
    {
        private readonly IHttpClientFactory _httpClient;
        public SummeryService(IHttpClientFactory httpClient)
            : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> AccountSummeriesAsync<T>(SummeryQueryDTO summeryQuery)
        {
            return await this.SendPostAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/summery",
                Data = summeryQuery
            });
        }

        public async Task<T> AccountSummeryAsync<T>(SummeryQueryDTO summeryQuery)
        {
            return await this.SendPostAsync<T>(new ApiRequest()
            {
                Url = Constants.TransactionUrlBase + "/api/summery/account",
                Data = summeryQuery
            });
        }
    }
}
