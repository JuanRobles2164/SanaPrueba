using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domains;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductDomain _domain;
        public ProductController(IProductDomain domain) 
        {
            _domain = domain;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _domain.GetProducts());
        }
    }
}
