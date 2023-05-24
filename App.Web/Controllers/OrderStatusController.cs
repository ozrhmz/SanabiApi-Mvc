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
	public class OrderStatusController : Controller
    {
        private readonly OrderStatusApiService _orderStatusApiService;

        public OrderStatusController(OrderStatusApiService orderStatusApiService)
        {
            _orderStatusApiService = orderStatusApiService;
        }

        public async Task<IActionResult> Index()
        {
            var orderStatus=await _orderStatusApiService.GetAllAsync();
            return View(orderStatus);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderStatusDto orderStatusDto)
        {
            if(ModelState.IsValid)
            {
                await _orderStatusApiService.SaveAsync(orderStatusDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<OrderStatus>))]
        public async Task<IActionResult> Update(int id)
        {
            var orderStatus = await _orderStatusApiService.GetByIdAsync(id);
            return View(orderStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderStatusDto orderStatusDto)
        {
            if (ModelState.IsValid)
            {
                await _orderStatusApiService.UpdateAsync(orderStatusDto);
                return RedirectToAction(nameof(Index));
            }
            return View(orderStatusDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _orderStatusApiService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

    }
}
