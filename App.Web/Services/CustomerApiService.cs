using App.Core.DTOs;
using System.Net;

namespace App.Web.Services
{
    public class CustomerApiService
    {
        private readonly HttpClient _httpClient;

        public CustomerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CustomerDto>>>("customers");
            return response.Data;
        }

        public async Task<CustomerDto> SaveAsync(CustomerDto newcustomerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("customers", newcustomerDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CustomerDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(CustomerDto newcustomerDto)
        {
            var response = await _httpClient.PutAsJsonAsync("customers", newcustomerDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"Customer with ID {id} not found.");
            }
            else
            {
                throw new HttpRequestException($"Failed to delete product with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CustomerDto>>($"customers/{id}");
            return response.Data;
        }
    }
}
