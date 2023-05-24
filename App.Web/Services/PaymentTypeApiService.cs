using App.Core.DTOs;
using System.Net;

namespace App.Web.Services
{
    public class PaymentTypeApiService
    {
        private readonly HttpClient _httpClient;

        public PaymentTypeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PaymentTypeDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PaymentTypeDto>>>("paymenttype");
            return response.Data;
        }

        public async Task<PaymentTypeDto> SaveAsync(PaymentTypeDto newpaymentTypeDto)
        {
            var response = await _httpClient.PostAsJsonAsync("paymenttype", newpaymentTypeDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<PaymentTypeDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(PaymentTypeDto newpaymentTypeDto)
        {
            var response = await _httpClient.PutAsJsonAsync("paymenttype", newpaymentTypeDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"paymenttype/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"Payment Type with ID {id} not found.");
            }
            else
            {
                throw new HttpRequestException($"Failed to delete Payment Type with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<PaymentTypeDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PaymentTypeDto>>($"paymenttype/{id}");
            return response.Data;
        }
    }
}
