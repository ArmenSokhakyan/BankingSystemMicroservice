using FrontEnd.Presentation.API.DTOs.Transactions;

namespace FrontEnd.Core.Interfaces.Services.Transactions
{
    public interface ISummeryService
    {
        public Task<T> AccountSummeriesAsync<T>(SummeryQueryDTO summeryQuery);
        public Task<T> AccountSummeryAsync<T>(SummeryQueryDTO summeryQuery);
    }
}
