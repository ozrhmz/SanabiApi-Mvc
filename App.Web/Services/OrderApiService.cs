using App.Core.DTOs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace App.Web.Services
{
    public class OrderApiService
    {
        private readonly HttpClient _httpClient;

        public OrderApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<OrderDto>>("order");
            return response;
        }

        public async Task<bool> UpdateAsync(int orderId, int statusId)
        {
            var url = string.Format("Order?orderId={0}&statusId={1}", orderId, statusId);
            var response = await _httpClient.PutAsJsonAsync<object>(url, null);
            return response.IsSuccessStatusCode;
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<OrderDto>>($"order/GetOrdersById?selectId={id}");
                if (response != null && response.Count > 0)
                {
                    return response[0]; // İlk OrderDto öğesini döndürüyoruz
                }
                else
                {
                    // İstediğiniz hata işleme kodunu buraya ekleyebilirsiniz
                    throw new Exception("Sipariş bulunamadı");
                }

            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"An error occurred while retrieving the order with ID {id}. {ex.Message}");
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Order/{id}");
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
    }
}
