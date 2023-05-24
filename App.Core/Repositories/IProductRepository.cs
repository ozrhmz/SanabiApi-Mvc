using App.Core.Models;

namespace App.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task UpdateStockAsync(int productId, int quantity);
    }
}
