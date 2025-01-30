using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;


namespace WebApplication1.Database.Impl
{
    public class DBConnection : IDBConnection
    {
        private readonly string _connectionString;

        public DBConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }
    }
}
