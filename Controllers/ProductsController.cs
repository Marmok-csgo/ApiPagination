using ApiPagination.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> _productsTable = new List<Product>();

        public ProductsController()
        {
            for (int i = 1; i <= 150; i++)
            {
                _productsTable.Add(new Product{Id = i, Name = "Product" + i, Price = 10.0m * i});
            }
        }

        [HttpGet]
        public IEnumerable<Product> Get(int page = 1)
        {
            int pageSize = 15;
            
            var productsPerPage = _productsTable
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return productsPerPage;
        }
    }
}

/**
 * 1) Best practice to validate
 * 2) Error messages
 * 3) Filters
 * --- genres
 * --- query=Star20%Wars
 */
