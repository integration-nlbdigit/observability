using Microsoft.AspNetCore.Mvc;
using Models;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private List<Product> _products = new List<Product>();

        public CatalogController()
        {
            _products.Add(new Product(1, "Product1")
             {
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddYears(1),
             });

            _products.Add(new Product(2, "Product2")
             {
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddYears(2),
             });

            _products.Add(new Product(3, "Product3")
             {
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddYears(3),
             });
            
        }

        [HttpGet]
        [Route("items")]
        public IActionResult Items()
        {
            return Ok(_products);
        }

        [HttpGet]
        [Route("items/{id}")]
        public IActionResult GetItem(string id)
        {
            return Ok(_products.FirstOrDefault(i => int.Equals(i.Id, id)));
        }
    }
}