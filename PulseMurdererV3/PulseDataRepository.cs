using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PulseMurdererV3
{
    public class PulseDataRepository
    {
        private readonly string _connectionString;

        public PulseDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(PulseData pulseData)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("INSERT INTO pulseData (Id, Iterval) VALUES (@Id, @Iterval)", connection);
            command.Parameters.AddWithValue("@Id", pulseData.Id);
            command.Parameters.AddWithValue("@Iterval", pulseData.Iterval);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public PulseData? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT Id, Iterval FROM pulseData WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PulseData(reader.GetInt32(0), reader.GetString(1));
            }
            return null;
        }

        public List<PulseData> GetAll()
        {
            var result = new List<PulseData>();
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT Id, Iterval FROM pulseData", connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new PulseData(reader.GetInt32(0), reader.GetString(1)));
            }
            return result;
        }
    }
}
