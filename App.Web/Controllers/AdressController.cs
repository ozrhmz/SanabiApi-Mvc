using App.Core.DTOs;
using App.Core.Models;
using App.Web.Filters;
using App.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdressController : Controller
    {
        private readonly AdressApiService _adressApiService;

        public AdressController(AdressApiService adressApiService)
        {
            _adressApiService = adressApiService;
        }

        public async Task<IActionResult> Index()
        {
            var adress=await _adressApiService.GetAllAsync();
            return View(adress);
        }

        [ServiceFilter(typeof(NotFoundFilter<Adress>))]
        public async Task<IActionResult> Update(int id)
        {
            var adress = await _adressApiService.GetByIdAsync(id);
            return View(adress);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdressDto adressDto)
        {
            if (ModelState.IsValid)
            {
                await _adressApiService.UpdateAsync(adressDto);
                return RedirectToAction(nameof(Index));
            }
            return View(adressDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _adressApiService.RemoveAsync(id);
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
