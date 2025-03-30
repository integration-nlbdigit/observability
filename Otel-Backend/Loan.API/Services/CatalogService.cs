using System.Text.Json;
using Loan.API.Services.Interfaces;
using Models;
using QueueFactory.Models;

namespace Loan.API.Services
{
    public class CatalogService : ICatalogService
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _options;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Product> GetProduct(int productId)
        {

            return JsonSerializer.Deserialize<Product>(await _httpClient.GetStringAsync($"http://localhost:6001/api/v1/catalog/items/{productId}"), _options);

        }

        public Task<bool> GetScoring(LoanApplication loan)
        {
            throw new NotImplementedException();
        }
    }
}