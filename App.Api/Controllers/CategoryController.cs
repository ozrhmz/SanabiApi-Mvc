using App.Api.Filters;
using App.Core.DTOs;
using App.Core.Models;
using App.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public CategoryController(IMapper mapper, ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Succes(200, categoriesDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _service.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            var categoriesDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Succes(200, categoriesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = await _service.AddAsync(_mapper.Map<Category>(categoryDto));
            var CategoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Succes(201, CategoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
    }
}
