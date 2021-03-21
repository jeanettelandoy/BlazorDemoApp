using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ITransportationData
    {
        Task<List<TransportationModel>> GetTransportationData();
        Task InsertTransportation(TransportationModel model);
        Task<string> DeleteRowFromDb(int Id);
        Task<string> UpdateRowInDb(TransportationModel model);

    }
}