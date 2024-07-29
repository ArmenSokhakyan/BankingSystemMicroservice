using Microsoft.AspNetCore.Http.HttpResults;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Core.Services
{
    public class SummeryService : ISummeryService
    {
        private readonly ISummeryRepository _summeryRepository;

        public SummeryService(ISummeryRepository summeryRepository)
        {
            _summeryRepository = summeryRepository;
        }

        public async Task<IEnumerable<SummeryDTO>> AccountSummeriesAsync(DateTime startDate, DateTime endDate)
        {
            return await _summeryRepository.AccountSummeriesAsync(startDate, endDate);
        }

        public async Task<SummeryDTO> AccountSummeryAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            return await _summeryRepository.AccountSummeryAsync(accountId, startDate, endDate);
        }
    }
}
