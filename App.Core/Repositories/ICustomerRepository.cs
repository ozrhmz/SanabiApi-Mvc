using App.Core.Models;

namespace App.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<int?> GetIdWithMail(string mail);
    }
}
