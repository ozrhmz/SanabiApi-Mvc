using App.Core.Models;
using App.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICagetoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
