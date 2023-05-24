using App.Core.Models;
using App.Core.Repositories;
using App.Core.Services;
using App.Core.UnitOfWorks;
using AutoMapper;


namespace App.Service.Services
{
    public class AdressService : Service<Adress>, IAdressService
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;


        public AdressService(IUnitOfWork unitOfWork, IGenericRepository<Adress> repository, IAdressRepository adressRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
        }

        public async Task<List<Adress>> GetAddressesByCustomerId(int customerId)
        {
            var addresses = await _adressRepository.GetAddressesByCustomerId(customerId);
            return addresses.ToList();
        }
    }
}
