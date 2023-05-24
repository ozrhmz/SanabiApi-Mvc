using App.Core.Models;

namespace App.Core.Services
{
    public interface IProductService : IService<Product>
    {
        public Task UpdateStockAsync(int productId, int quantity);
    }
}
