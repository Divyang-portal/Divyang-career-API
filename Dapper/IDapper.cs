using Dapper;

namespace DivyangCareerApi.Dapper
{
    public interface IDapper
    {
        T Get<T>(string sp, DynamicParameters parameters);
        List<T> GetAll<T>(string sp, DynamicParameters parameters);
        T Post<T>(string sp, DynamicParameters parameters);
        T Delete<T>(string sp, DynamicParameters parameters);
        List<T> GetAllList<T>(string sp);
    }
}
