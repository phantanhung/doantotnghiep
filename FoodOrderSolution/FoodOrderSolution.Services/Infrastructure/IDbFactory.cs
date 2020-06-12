using System;

namespace FoodOrderSolution.Services.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EntitiesDbContext Init();
    }
}
