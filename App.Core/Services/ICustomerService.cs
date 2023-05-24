using App.Core.DTOs;
using App.Core.Models;

namespace App.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        public Task<CustomResponseDto<int?>> GetIdWithMail(string mail);
    }
}
