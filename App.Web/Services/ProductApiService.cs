using App.Core.DTOs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;

namespace App.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<ProductDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductDto>>>("products");
            return response.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto newproductDto)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newproductDto);
            if(!response.IsSuccessStatusCode) return null;

            var responseBody=await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto newproductDto)
        {
           var response= await _httpClient.PutAsJsonAsync("products", newproductDto);
           return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Products?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"Product with ID {id} not found.");
            }
            else
            {
                throw new HttpRequestException($"Failed to delete product with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<ProductDto>GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            return response.Data;
        }   

    }
}
