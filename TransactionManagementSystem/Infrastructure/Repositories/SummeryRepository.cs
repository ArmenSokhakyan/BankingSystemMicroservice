using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Infrastructure.Data;

namespace TransactionManagementSystem.Infrastructure.Repositories
{
    public class SummeryRepository : BaseRepository, ISummeryRepository
    {
        private readonly TransactionContext _transactionContext;

        public SummeryRepository(TransactionContext transactionContext)
            : base(transactionContext)
        {
            _transactionContext = transactionContext;
        }


    }
}
