using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts(int page = 1, int pageSize = 10);
    }
}
