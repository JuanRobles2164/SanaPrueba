using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Impl
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly string _GET_PRODUCTS_QUERY = "SELECT * FROM Products; ";
        public ProductRepository(IDBConnection conn): base(conn) { }

        public async Task<IEnumerable<Product>> GetCatalog()
        {
            return await _conn.QueryAsync<Product>(_GET_PRODUCTS_QUERY);
        }
    }
}
