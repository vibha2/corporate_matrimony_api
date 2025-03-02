using System.Data;
using CorporateMatrimony.API.Entities;
using CorporateMatrimony.API.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DatabaseHelperSP : IDatabaseHelperSP
{
    private readonly string _connectionString;

    public DatabaseHelperSP(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DBConnection")
                            ?? throw new InvalidOperationException("Database connection string is missing.");
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    /// <summary>
    /// Executes a stored procedure that returns multiple records.
    /// </summary>
    public async Task<IEnumerable<T>> QueryAsync<T>(StoreProcedureParams spParams)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<T>(spParams.ProcedureName, spParams.Parameters, commandType: CommandType.StoredProcedure);
    }

    /// <summary>
    /// Executes a stored procedure that returns a single record.
    /// </summary>
    public async Task<T?> QuerySingleAsync<T>(StoreProcedureParams spParams)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(spParams.ProcedureName, spParams.Parameters, commandType: CommandType.StoredProcedure);
    }

    /// <summary>
    /// Executes a stored procedure that does not return data, only number of affected rows.
    /// </summary>
    public async Task<int> ExecuteAsync(StoreProcedureParams spParams)
    {
        using var connection = CreateConnection();
        return await connection.ExecuteAsync(spParams.ProcedureName, spParams.Parameters, commandType: CommandType.StoredProcedure);
    }

    /// <summary>
    /// Executes a stored procedure that returns a single scalar value (e.g., COUNT, SUM).
    /// </summary>
    public async Task<T> ExecuteScalarAsync<T>(StoreProcedureParams spParams)
    {
        using var connection = CreateConnection();
        return await connection.ExecuteScalarAsync<T>(spParams.ProcedureName, spParams.Parameters, commandType: CommandType.StoredProcedure);
    }
}
