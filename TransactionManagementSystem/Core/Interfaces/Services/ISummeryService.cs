using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Core.Interfaces.Services
{
    public interface ISummeryService : IBaseRepository
    {
        public Task<IEnumerable<SummeryDTO>> AccountSummeriesAsync(DateTime startDate, DateTime endDate);
        public Task<SummeryDTO> AccountSummeryAsync(int accountId, DateTime startDate, DateTime endDate);
    }
}
