using Models;
using QueueFactory.Models;

namespace ServiceWorker.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<Product> GetProduct(int productId);
    }
}