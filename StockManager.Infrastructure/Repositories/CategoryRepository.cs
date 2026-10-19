using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}