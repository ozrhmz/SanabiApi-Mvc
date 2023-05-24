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
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        public CustomersController(IMapper mapper,ICustomerService customerService)
        {
            _mapper = mapper;
            _service = customerService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetIdWithMail(string mail)
        {
            var customer = await _service.GetIdWithMail(mail);
            return CreateActionResult(customer);
        }

        //Get api/Customers
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers=await _service.GetAllAsync();
            var customersDtos=_mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Succes(200, customersDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        //Get /api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            var customerDtos = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Succes(200, customerDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customer = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customerDtos = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Succes(201, customerDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        //Delete api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer =await _service.GetByIdAsync(id);

            await _service.RemoveAsync(customer);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
    }
}
