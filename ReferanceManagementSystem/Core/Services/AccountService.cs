using ReferanceManagementSystem.Core.Entities;
using ReferanceManagementSystem.Core.Interfaces.Repositories;
using ReferanceManagementSystem.Core.Interfaces.Services;

namespace ReferanceManagementSystem.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task AddAccountAsync(Account account)
        {
            await _accountRepository.AddAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _accountRepository.DeleteAccountAsync(id);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _accountRepository.GetAccountByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountRepository.GetAccountsAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsByHolderAsync(string holder)
        {
            return await _accountRepository.GetAccountsByHolderAsync(holder);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _accountRepository.UpdateAccountAsync(account);
        }
    }
}
