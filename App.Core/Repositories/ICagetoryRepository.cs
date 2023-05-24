using App.Core.Models;

namespace App.Core.Repositories
{
    public interface ICagetoryRepository : IGenericRepository<Category>
    {
        public Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
