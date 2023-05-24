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
    public class PaymentTypeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<PaymentType> _service;

        public PaymentTypeController(IService<PaymentType> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var paymentTypes= await _service.GetAllAsync();
            var paymentTypeDtos=_mapper.Map<List<PaymentTypeDto>>(paymentTypes.ToList());
            return CreateActionResult(CustomResponseDto<List<PaymentTypeDto>>.Succes(200, paymentTypeDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PaymentTypeDto paymentTypeDto)
        {
            var paymentType = await _service.AddAsync(_mapper.Map<PaymentType>(paymentTypeDto));
            var paymentTypeDtos = _mapper.Map<PaymentTypeDto>(paymentType);
            return CreateActionResult(CustomResponseDto<PaymentTypeDto>.Succes(201, paymentTypeDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentTypeDto paymentTypeDto)
        {
            await _service.UpdateAsync(_mapper.Map<PaymentType>(paymentTypeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<PaymentType>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var paymentType = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(paymentType);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<PaymentType>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentType = await _service.GetByIdAsync(id);
            var paymentTypeDto = _mapper.Map<PaymentTypeDto>(paymentType);
            return CreateActionResult(CustomResponseDto<PaymentTypeDto>.Succes(200, paymentTypeDto));
        }
    }
}
