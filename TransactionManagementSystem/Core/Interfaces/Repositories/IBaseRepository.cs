using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Core.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        public Task<IEnumerable<SummeryDTO>> AccountSummeriesAsync(DateTime startDate, DateTime endDate);
        public Task<SummeryDTO> AccountSummeryAsync(int accountId, DateTime startDate, DateTime endDate);
    }
}
