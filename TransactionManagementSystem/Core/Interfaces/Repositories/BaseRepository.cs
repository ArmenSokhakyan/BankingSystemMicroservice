using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Infrastructure.Data;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Core.Interfaces.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly TransactionContext _transactionContext;

        protected BaseRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public async Task<IEnumerable<SummeryDTO>> AccountSummeriesAsync(DateTime startDate, DateTime endDate)
        {
            using (var command = _transactionContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT\r\n\tT.AccountId,\r\n\tSUM(T.TotalIncom) as TotalIncom,\r\n\tSUM(T.TotalExpense) as TotalExpense\r\nFROM\r\n(SELECT\r\n\tT1.AccountId as AccountId,\r\n\tT1.Amount as TotalIncom,\r\n\t0 as TotalExpense\r\nFROM\r\n\tdbo.InTransaction as T1\r\nWHERE\r\n\tT1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate\r\nUNION ALL\r\nSELECT\r\n\tT1.AccountId as AccountId,\r\n\t0,\r\n\tT1.Amount\r\nFROM\r\n\tdbo.OutTransaction as T1\r\nWHERE\r\n\tT1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate\r\nUNION ALL\r\nSELECT\r\n\tT1.SourceAccountId as AccountId,\r\n\t0,\r\n\tT1.Amount\r\nFROM\r\n\tdbo.TransferTransaction as T1\r\nWHERE\r\n\tT1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate\r\nUNION ALL\r\nSELECT\r\n\tT1.DestinationAccountId as AccountId,\r\n\tT1.Amount,\r\n\t0\r\nFROM\r\n\tdbo.TransferTransaction as T1\r\nWHERE\r\n\tT1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate) as T\r\nGROUP BY\r\n\tT.AccountId";
                command.Parameters.Add(new SqlParameter("@startDate", startDate));
                command.Parameters.Add(new SqlParameter("@endDate", endDate));

                _transactionContext.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    List<SummeryDTO> summeryDTOs = new List<SummeryDTO>();
                    while(await result.ReadAsync())
                    {
                        summeryDTOs.Add(new SummeryDTO
                        {
                            AccountID = int.Parse(result["AccountId"].ToString()),
                            TotalIncom = double.Parse(result["TotalIncom"].ToString()),
                            TotalExpense = double.Parse(result["TotalExpense"].ToString())
                        });
                    }
                    
                    return summeryDTOs;
                }
            }
        }

        public async Task<SummeryDTO> AccountSummeryAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            using (var command = _transactionContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT\r\n\tT.AccountId,\r\n\tSUM(T.TotalIncom) as TotalIncom,\r\n\tSUM(T.TotalExpense) as TotalExpense\r\nFROM\r\n(SELECT\r\n\tT1.AccountId as AccountId,\r\n\tT1.Amount as TotalIncom,\r\n\t0 as TotalExpense\r\nFROM\r\n\tdbo.InTransaction as T1\r\nWHERE\r\n\tT1.AccountId = @accountId and T1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate\r\nUNION ALL\r\nSELECT\r\n\tT1.AccountId as AccountId,\r\n\t0,\r\n\tT1.Amount\r\nFROM\r\n\tdbo.OutTransaction as T1\r\nWHERE\r\n\tT1.AccountId = @accountId and T1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate\r\nUNION ALL\r\nSELECT\r\n\tT1.SourceAccountId as AccountId,\r\n\t0,\r\n\tT1.Amount\r\nFROM\r\n\tdbo.TransferTransaction as T1\r\nWHERE\r\n\tT1.SourceAccountId = @accountId and T1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate\r\nUNION ALL\r\nSELECT\r\n\tT1.DestinationAccountId as AccountId,\r\n\tT1.Amount,\r\n\t0\r\nFROM\r\n\tdbo.TransferTransaction as T1\r\nWHERE\r\n\tT1.DestinationAccountId = @accountId and T1.TransactionDate >= @startDate and T1.TransactionDate <= @endDate) as T\r\nGROUP BY\r\n\tT.AccountId";
                command.Parameters.Add(new SqlParameter("@accountId", accountId));
                command.Parameters.Add(new SqlParameter("@startDate", startDate));
                command.Parameters.Add(new SqlParameter("@endDate", endDate));

                _transactionContext.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    SummeryDTO summeryDTO = new();
                    while (await result.ReadAsync())
                    {
                        summeryDTO = new SummeryDTO
                        {
                            AccountID = int.Parse(result["AccountId"].ToString()),
                            TotalIncom = double.Parse(result["TotalIncom"].ToString()),
                            TotalExpense = double.Parse(result["TotalExpense"].ToString())
                        };
                    }

                    return summeryDTO;
                }
            }
        }
    }
}
