using ReferanceManagementSystem.Core.Entities;

namespace ReferanceManagementSystem.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task<IEnumerable<Account>> GetAccountsByHolderAsync(string holder);
        Task AddAccountAsync(Account account);
        Task DeleteAccountAsync(int id);
        Task UpdateAccountAsync(Account account);
    }
}
