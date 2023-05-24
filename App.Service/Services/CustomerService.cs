using App.Core.DTOs;
using App.Core.Models;
using App.Core.Repositories;
using App.Core.Services;
using App.Core.UnitOfWorks;
using AutoMapper;

namespace App.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IGenericRepository<Customer> repository, ICustomerRepository customerRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<int?>> GetIdWithMail(string mail)
        {
            var customerId = await _customerRepository.GetIdWithMail(mail);
            return CustomResponseDto<int?>.Succes(200, customerId);
        }
    }
}
