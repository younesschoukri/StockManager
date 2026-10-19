using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}