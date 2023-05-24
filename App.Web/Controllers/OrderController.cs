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
	public class OrderController : Controller
    {
        private readonly OrderApiService _orderApiService;
        private readonly OrderStatusApiService _orderStatusApiService;

        public OrderController(OrderApiService orderApiService, OrderStatusApiService orderStatusApiService)
        {
            _orderApiService = orderApiService;
            _orderStatusApiService = orderStatusApiService;
        }

        public async Task<IActionResult> Index()
        {
            var order = await _orderApiService.GetAllAsync();
            return View(order);
        }

        public async Task<IActionResult> Update(int id)
        {
            var orders = await _orderApiService.GetByIdAsync(id);
            var statusDto = await _orderStatusApiService.GetAllAsync();
            ViewBag.status = new SelectList(statusDto, "Id", "StatusType");
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int orderId, int statusId)
        {
            var result = await _orderApiService.UpdateAsync(orderId, statusId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            var statusDto = await _orderStatusApiService.GetAllAsync();
            ViewBag.status = new SelectList(statusDto, "Id", "StatusType");
            ModelState.AddModelError("", "Sipariş durumu güncellenirken bir hata oluştu.");
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _orderApiService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
