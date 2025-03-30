using Microsoft.Extensions.Logging;
using Models;
using ServiceWorker.Services.Interfaces;
using System.Text.Json;

namespace ServiceWorker.Services
{
    public class CatalogService : ICatalogService
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _options;
        private ILogger<CatalogService> _logger;

        public CatalogService(HttpClient httpClient, ILogger<CatalogService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Product> GetProduct(int productId)
        {
            _logger.LogInformation("Get Product {productId}", productId);
            #pragma warning disable CS8603 // Possible null reference return.

            return JsonSerializer.Deserialize<Product>(await _httpClient.GetStringAsync($"http://localhost:6001/api/v1/catalog/items/{productId}"), _options);
            #pragma warning restore CS8603 // Possible null reference return.

        }
    }
}

