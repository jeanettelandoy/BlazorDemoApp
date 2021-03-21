using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class TransportationData : ITransportationData
    {
        private readonly ISQLDataAccess _db;
        public TransportationData(ISQLDataAccess db)
        {
            _db = db;
        }

        public Task<List<TransportationModel>> GetTransportationData()
        {
            string sql = "select * from dbo.Transportation";
            
            var res = _db.LoadData<TransportationModel, dynamic>(sql, new { });
            return res;
        }

        public async Task InsertTransportation(TransportationModel model)
        {
            await _db.SaveRecord(model);
        }
        public async Task<string> DeleteRowFromDb(int id)
        {
            var result = await _db.DeleteRow(id);
            return result;
        }
        public async Task<string> UpdateRowInDb(TransportationModel model)
        {
            var result = await _db.UpdateRow(model);
            return result;
        }
    }
}
