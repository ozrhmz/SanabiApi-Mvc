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
    public class AdminController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Admin> _service;

        public AdminController(IMapper mapper, IService<Admin> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var admins = await _service.GetAllAsync();
            var adminsDto = _mapper.Map<List<AdminDto>>(admins.ToList());
            return CreateActionResult(CustomResponseDto<List<AdminDto>>.Succes(200, adminsDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Admin>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _service.GetByIdAsync(id);
            var adminDto = _mapper.Map<AdminDto>(admin);
            return CreateActionResult(CustomResponseDto<AdminDto>.Succes(200, adminDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(AdminDto adminDtos)
        {
            var admin = await _service.AddAsync(_mapper.Map<Admin>(adminDtos));
            var adminDtoss=_mapper.Map<AdminDto>(admin);
            return CreateActionResult(CustomResponseDto<AdminDto>.Succes(201, adminDtoss));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AdminDto adminDto)
        {
            await _service.UpdateAsync(_mapper.Map<Admin>(adminDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Admin>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var admin = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(admin);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
    }
}
