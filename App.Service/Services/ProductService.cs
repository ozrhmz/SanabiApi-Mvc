using App.Core.Models;
using App.Core.Repositories;
using App.Core.Services;
using App.Core.UnitOfWorks;

namespace App.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IProductRepository productRepository) : base(unitOfWork, repository)
        {
            _productRepository = productRepository;
        }

        public async Task UpdateStockAsync(int productId, int quantity)
        {
            await _productRepository.UpdateStockAsync(productId, quantity);
        }
    }
}
