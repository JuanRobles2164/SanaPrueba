namespace WebApplication1.Database
{
    public interface IDBConnection
    {
        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null);
    }
}
