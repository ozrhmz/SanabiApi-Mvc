using App.Core.DTOs;
using App.Core.Models;
using App.Web.Filters;
using App.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace App.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
    {
        private readonly CategoryApiService _categoryService;
        private readonly ProductApiService _productService;

        public CategoryController(CategoryApiService categoryService, ProductApiService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.GetAllAsync();
            return View(category);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.SaveAsync(categoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(categoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _categoryService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
