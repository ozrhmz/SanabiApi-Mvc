using App.Core.DTOs;
using App.Core.Models;
using App.Core.Services;
using App.Web.Filters;
using App.Web.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace App.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ProductsController : Controller
    {

        private readonly ProductApiService _productService;
        private readonly CategoryApiService _categoryService;

        public ProductsController(ProductApiService productService, CategoryApiService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name"); //Id sini listele ama kullanıcılar Name ini görücek
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.SaveAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            var categoriesDto = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();

        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var categoriesDto = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name",product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if(ModelState.IsValid)
            {
                await _productService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categoriesDto = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);
            return View(productDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _productService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
