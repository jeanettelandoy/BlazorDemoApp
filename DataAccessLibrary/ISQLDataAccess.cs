using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ISQLDataAccess
    {
        string ConnectionStringName { get; set; }
        Task<List<T>> LoadData<T, U>(string sql, U param);
        Task SaveData<T>(string sql, T param);
        Task SaveRecord(TransportationModel model);
        Task<string> DeleteRow(int Id);
        Task<string> UpdateRow(TransportationModel model);
    }
}