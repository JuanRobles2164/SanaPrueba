using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Impl
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly string _GET_PRODUCTS_QUERY = 
            @"SELECT * FROM Products 
                ORDER BY ID 
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY; ";
        public ProductRepository(IDBConnection conn): base(conn) { }

        /// <summary>
        /// Fetch the list of products from the database. It has pagination
        /// </summary>
        /// <param name="page">Which page are you searching</param>
        /// <param name="pageSize">How many items per page would you like to return</param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts(int page = 1, int pageSize = 10)
        {
            int offset = (page - 1) * pageSize;
            var parameters = new { Offset = offset, PageSize = pageSize };

            return await _conn.QueryAsync<Product>(_GET_PRODUCTS_QUERY, parameters);
        }
    }
}
