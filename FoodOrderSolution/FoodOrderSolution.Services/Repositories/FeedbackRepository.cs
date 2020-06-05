using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Services.Infrastructure;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {

    }
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
