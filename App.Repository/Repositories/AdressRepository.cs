using App.Core.Models;
using App.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Repository.Repositories
{
    public class AdressRepository : GenericRepository<Adress>, IAdressRepository
    {
        public AdressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Adress>> GetAddressesByCustomerId(int customerId)
        {
            return await _context.Adresses.Where(x => x.CustomerId == customerId).ToListAsync();

        }
    }
}
