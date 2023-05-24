using App.Core.DTOs;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using App.Web.Filters;
using App.Core.Services;
using System.Net;

namespace App.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("category");
            return response.Data;
        }

        public async Task<CategoryDto> SaveAsync(CategoryDto newcategoryDto)
        {
            var response = await _httpClient.PostAsJsonAsync("category", newcategoryDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CategoryDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(CategoryDto newcategoryDto)
        {
            var response = await _httpClient.PutAsJsonAsync("category", newcategoryDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"Category with ID {id} not found.");
            }
            else
            {
                throw new HttpRequestException($"Failed to delete Category with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CategoryDto>>($"category/{id}");
            return response.Data;
        }
    }
}
