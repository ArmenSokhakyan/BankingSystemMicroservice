using Microsoft.EntityFrameworkCore;
using ReferanceManagementSystem.Core.Entities;
using ReferanceManagementSystem.Core.Interfaces.Repositories;
using ReferanceManagementSystem.Infrastructure.Data;

namespace ReferanceManagementSystem.Infrastructure.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly RMSContext _rmsContext;

        public AccountRepository(RMSContext rmsContext)
        {
            _rmsContext = rmsContext;
        }

        public async Task AddAccountAsync(Account account)
        {
            _rmsContext.Accounts.Add(account);
            await _rmsContext.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _rmsContext.Accounts.FindAsync(id);

            if(account != null)
            {
                _rmsContext.Accounts.Remove(account);
                await _rmsContext.SaveChangesAsync();
            }
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _rmsContext.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _rmsContext.Accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsByHolderAsync(string holder)
        {
            return await _rmsContext.Accounts.Where(a => a.AccountHolder == holder).ToListAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _rmsContext.Accounts.Update(account);
            await _rmsContext.SaveChangesAsync();
        }
    }
}
