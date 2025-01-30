using WebApplication1.Models;

namespace WebApplication1.Domains
{
    public interface IProductDomain
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}
