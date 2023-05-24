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
    public class OrderStatusController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<OrderStatus> _service;

        public OrderStatusController(IService<OrderStatus> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orderStatuses = await _service.GetAllAsync();
            var orderStatusDtos = _mapper.Map<List<OrderStatusDto>>(orderStatuses.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderStatusDto>>.Succes(200, orderStatusDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderStatusDto orderStatusDto)
        {
            var orderStatus = await _service.AddAsync(_mapper.Map<OrderStatus>(orderStatusDto));
            var orderStatusDtos = _mapper.Map<OrderStatusDto>(orderStatus);
            return CreateActionResult(CustomResponseDto<OrderStatusDto>.Succes(201, orderStatusDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderStatusDto orderStatusDto)
        {
            await _service.UpdateAsync(_mapper.Map<OrderStatus>(orderStatusDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<OrderStatus>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var orderStatus = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(orderStatus);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<OrderStatus>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderStatus = await _service.GetByIdAsync(id);
            var orderStatusDto = _mapper.Map<OrderStatusDto>(orderStatus);
            return CreateActionResult(CustomResponseDto<OrderStatusDto>.Succes(200, orderStatusDto));
        }
    }
}
