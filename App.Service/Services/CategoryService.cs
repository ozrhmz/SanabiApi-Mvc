using App.Core.DTOs;
using App.Core.Models;
using App.Core.Repositories;
using App.Core.Services;
using App.Core.UnitOfWorks;
using AutoMapper;

namespace App.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICagetoryRepository _cagetoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, IMapper mapper, ICagetoryRepository cagetoryRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _cagetoryRepository = cagetoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _cagetoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Succes(200, categoryDto);
        }
    }
}
