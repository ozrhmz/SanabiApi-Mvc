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
	public class CustomerController : Controller
    {
        private readonly CustomerApiService _customerApiService;

        public CustomerController(CustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }

        public async Task<IActionResult> Index()
        {
            var customers= await _customerApiService.GetAllAsync();
            return View(customers);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            if(ModelState.IsValid)
            {
                await _customerApiService.SaveAsync(customerDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        public async Task<IActionResult> update(int id)
        {
            var customer=await _customerApiService.GetByIdAsync(id);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            if(ModelState.IsValid) 
            {
                await _customerApiService.UpdateAsync(customerDto);
                return RedirectToAction(nameof(Index));
            }
            return View(customerDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _customerApiService.RemoveAsync(id);
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
