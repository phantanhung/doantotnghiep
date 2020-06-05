using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Services.Infrastructure;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IHistoryPointRepository : IRepository<HistoryPoint>
    {

    }
    public class HistoryPointRepository : RepositoryBase<HistoryPoint>, IHistoryPointRepository
    {
        public HistoryPointRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
