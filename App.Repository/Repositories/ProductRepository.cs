using App.Core.Models;
using App.Core.Repositories;

namespace App.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task UpdateStockAsync(int productId, int quantity)
        {
            var product = await GetByIdAsync(productId);
            product.Stock -= quantity;
            await _context.SaveChangesAsync();
        }
    }
}
