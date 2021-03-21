using Dapper;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";


        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U param)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {              
                var data = await cnn.QueryAsync<T>(sql, param);                
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T param)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                await cnn.ExecuteAsync(sql, param);
            }
        }

        public async Task SaveRecord(TransportationModel model)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Transportation", cnn);
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO dbo.Transportation(CompanyName,TransportationName,TransportationType,TransportationCharacteristics,Registered) 
                                        VALUES(@CompanyName,@TransportationName,@TransportationType,@TransportationCharacteristics,@Registered)";

                command.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                command.Parameters.AddWithValue("@TransportationName", model.TransportationName);
                command.Parameters.AddWithValue("@TransportationType", model.TransportationType);
                command.Parameters.AddWithValue("@TransportationCharacteristics", model.TransportationCharacteristics);
                command.Parameters.AddWithValue("@Registered", model.Registered);

                try
                {
                    cnn.Open();
                    command.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (SqlException ex)
                {

                }
            }
        }
        public async Task<string> DeleteRow(int Id)
        {
            var returnText = "";

            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Transportation", cnn);
                command.CommandType = CommandType.Text;
                command.CommandText = @"DELETE FROM dbo.Transportation Where Id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                try
                {
                    cnn.Open();
                    command.ExecuteNonQuery();
                    cnn.Close();
                    returnText = $"{Id} was deleted";
                }
                catch (SqlException ex)
                {
                    returnText = ex.Message;
                }
            }
            return returnText;
        }
        public async Task<string> UpdateRow(TransportationModel model)
        {
            var returnText = "";

            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Transportation", cnn);
                command.CommandType = CommandType.Text;
                command.CommandText = @"UPDATE dbo.Transportation 
                                        SET TransportationName = @TransportationName, TransportationType = @TransportationType, TransportationCharacteristics = @TransportationCharacteristics Where Id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = model.id;

                command.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                command.Parameters.AddWithValue("@TransportationName", model.TransportationName);
                command.Parameters.AddWithValue("@TransportationType", model.TransportationType);
                command.Parameters.AddWithValue("@TransportationCharacteristics", model.TransportationCharacteristics);
                command.Parameters.AddWithValue("@Registered", model.Registered);

                try
                {
                    cnn.Open();
                    command.ExecuteNonQuery();
                    cnn.Close();
                    returnText = $"{model.id} was updated";
                }
                catch (SqlException ex)
                {
                    returnText = ex.Message;
                }
            }
            return returnText;
        }
    }
}
