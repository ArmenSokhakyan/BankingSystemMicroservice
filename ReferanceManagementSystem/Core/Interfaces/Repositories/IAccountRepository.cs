using ReferanceManagementSystem.Core.Entities;
using ReferanceManagementSystem.Infrastructure.Data;

namespace ReferanceManagementSystem.Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task<IEnumerable<Account>> GetAccountsByHolderAsync(string holder);
        Task AddAccountAsync(Account account);
        Task DeleteAccountAsync(int id);
        Task UpdateAccountAsync(Account account);
    }
}