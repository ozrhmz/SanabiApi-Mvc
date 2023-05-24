using App.Core.Models;

namespace App.Core.Services
{
    public interface IAdressService : IService<Adress>
    {
        public Task<List<Adress>> GetAddressesByCustomerId(int customerId);
    }
}

