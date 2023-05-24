using App.Core.Models;

namespace App.Core.Repositories
{
    public interface IAdressRepository : IGenericRepository<Adress>
    {
        public Task<List<Adress>> GetAddressesByCustomerId(int customerId);
    }
}
