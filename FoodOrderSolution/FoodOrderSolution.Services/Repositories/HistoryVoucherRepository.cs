using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Services.Infrastructure;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IHistoryVoucherRepository : IRepository<HistoryVoucher>
    {

    }
    public class HistoryVoucherRepository : RepositoryBase<HistoryVoucher>, IHistoryVoucherRepository
    {
        public HistoryVoucherRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
