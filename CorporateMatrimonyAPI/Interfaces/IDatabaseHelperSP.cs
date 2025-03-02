using CorporateMatrimony.API.Entities;

namespace CorporateMatrimony.API.Interfaces
{
    public interface IDatabaseHelperSP
    {
        Task<IEnumerable<T>> QueryAsync<T>(StoreProcedureParams spParams);
        Task<T?> QuerySingleAsync<T>(StoreProcedureParams spParams);
        Task<int> ExecuteAsync(StoreProcedureParams spParams);
        Task<T> ExecuteScalarAsync<T>(StoreProcedureParams spParams);
    }
}
