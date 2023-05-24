using App.Core.DTOs;
using System.Net;

namespace App.Web.Services
{
    public class AdressApiService
    {
        private readonly HttpClient _httpClient;

        public AdressApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AdressDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync < CustomResponseDto<List<AdressDto>>>("adress");
            return response.Data;
        }

        public async Task<AdressDto> SaveAsync(AdressDto adressDto)
        {
            var response = await _httpClient.PostAsJsonAsync("adress", adressDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AdressDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(AdressDto adressDto)
        {
            var response = await _httpClient.PutAsJsonAsync("adress", adressDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"adress/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"Adress with ID {id} not found.");
            }
            else
            {
                throw new HttpRequestException($"Failed to delete Adress with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<AdressDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<AdressDto>>($"adress/{id}");
            return response.Data;
        }
    }
}
