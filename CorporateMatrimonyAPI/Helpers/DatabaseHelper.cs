using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using CorporateMatrimony.API.Interfaces;

namespace CorporateMatrimony.API.Helpers
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly string? _connectionString = "";

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        // IEnumerable retrieve list
        //Task<IEnumerable<T>> → An async method that, when awaited, will return an enumerable collection.
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql, parameters);
        }

        //Task<T?> → Represents an asynchronous operation that returns a single result(T), which might be null.
        //QuerySingleAsync<T> is a Dapper method used to execute a SQL query and return a single row asynchronously.
        public async Task<T?> QuerySingleAsync<T>(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
        }


        //Execute async and return only integer (no of rows affected)
        public async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }


        //return boolean
        public async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<T>(sql, parameters);
        }
    }

}
