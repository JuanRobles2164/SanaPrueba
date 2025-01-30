using WebApplication1.Database;

namespace WebApplication1.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDBConnection _conn;
        public BaseRepository(IDBConnection conn)
        {
            _conn = conn;
        }
    }
}
