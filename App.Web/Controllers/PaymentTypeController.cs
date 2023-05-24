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
	public class PaymentTypeController : Controller
    {
        private readonly PaymentTypeApiService _service;

        public PaymentTypeController(PaymentTypeApiService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var paymentType = await _service.GetAllAsync();
            return View(paymentType);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(PaymentTypeDto paymentTypeDto)
        {
            if (ModelState.IsValid)
            {
                await _service.SaveAsync(paymentTypeDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<PaymentType>))]
        public async Task<IActionResult> Update(int id)
        {
            var paymentType = await _service.GetByIdAsync(id);
            return View(paymentType);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PaymentTypeDto paymentTypeDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(paymentTypeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentTypeDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
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
