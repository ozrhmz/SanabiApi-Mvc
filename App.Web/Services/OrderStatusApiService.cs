using App.Core.DTOs;
using System.Net;

namespace App.Web.Services
{
    public class OrderStatusApiService
    {
        private readonly HttpClient _httpClient;

        public OrderStatusApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderStatusDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<OrderStatusDto>>>("orderstatus");
            return response.Data;
        }

        public async Task<OrderStatusDto> SaveAsync(OrderStatusDto neworderStatusDto)
        {
            var response = await _httpClient.PostAsJsonAsync("orderstatus", neworderStatusDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<OrderStatusDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(OrderStatusDto neworderStatusDto)
        {
            var response = await _httpClient.PutAsJsonAsync("orderstatus", neworderStatusDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"orderstatus/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"Order Status with ID {id} not found.");
            }
            else
            {
                throw new HttpRequestException($"Failed to delete Order Status with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<OrderStatusDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<OrderStatusDto>>($"orderstatus/{id}");
            return response.Data;
        }
    }
}
