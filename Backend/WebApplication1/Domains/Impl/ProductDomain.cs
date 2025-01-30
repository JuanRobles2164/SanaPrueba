using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Domains.Impl
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductRepository _repository;
        public ProductDomain(IProductRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetProducts();
        }
    }
}
