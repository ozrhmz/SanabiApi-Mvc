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
    public class AdressController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAdressService _service;

        public AdressController(IMapper mapper, IAdressService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetSingleAdressByIdCustomerAdressAsync(int customerId)
        {
            var addresses = await _service.GetAddressesByCustomerId(customerId);
            var addressDtos = _mapper.Map<List<AdressDto>>(addresses);
            return CreateActionResult(CustomResponseDto<List<AdressDto>>.Succes(200, addressDtos));
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var adresses = await _service.GetAllAsync();
            var AdressesDto = _mapper.Map<List<AdressDto>>(adresses.ToList());
            return CreateActionResult(CustomResponseDto<List<AdressDto>>.Succes(200, AdressesDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Adress>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adress = await _service.GetByIdAsync(id);
            var AdressDto = _mapper.Map<AdressDto>(adress);
            return CreateActionResult(CustomResponseDto<AdressDto>.Succes(200, AdressDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(AdressDto adressDto)
        {
            var adress = await _service.AddAsync(_mapper.Map<Adress>(adressDto));
            var AdressDtos = _mapper.Map<AdressDto>(adress);
            return CreateActionResult(CustomResponseDto<AdressDto>.Succes(201, AdressDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AdressDto adressDto)
        {
            await _service.UpdateAsync(_mapper.Map<Adress>(adressDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Adress>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var adress = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(adress);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
    }
}
