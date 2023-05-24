using App.Core.Models;
using App.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int?> GetIdWithMail(string mail)
        {
            var Customer = await _context.Customers.FirstOrDefaultAsync(x => x.Mail == mail);
            return Customer?.Id;
        }
    }
}
