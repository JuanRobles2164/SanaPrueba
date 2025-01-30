using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Domains;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductDomain _domain;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductDomain domain, ILogger<ProductController> logger) 
        {
            _domain = domain;
            _logger = logger;
        }

        /// <summary>
        /// Fetch a list of products. It has a pagination option
        /// </summary>
        /// <returns>A list of products.</returns>
        /// <response code="200">Returns the list of products.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [Route("/")]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var products = await _domain.GetProducts(page, pageSize);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching products.");
                return StatusCode(500, "Internal server error: Unable to fetch products.");
            }
        }
    }
}
