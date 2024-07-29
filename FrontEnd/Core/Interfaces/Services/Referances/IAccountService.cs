using FrontEnd.Presentation.API.DTOs.Referances;

namespace FrontEnd.Core.Interfaces.Services.Referances
{
    public interface IAccountService : IBaseService
    {
        public Task<T> GetAccountsAsync<T>();

        public Task<T> GetAccountAsync<T>(int id);

        public Task<T> AddAccount<T>(AccountDTO accountDTO);

        public Task<T> UpdateAccount<T>(int id, AccountDTO accountDTO);

        public Task<T> DeleteAccount<T>(int id);
    }
}
