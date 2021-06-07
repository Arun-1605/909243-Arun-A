using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace PlayersManagerLib
{
    public class PlayerMapper : IPlayerMapper
    {
        private readonly string _connectionString = "data source=(local);initial catalog=GameDB;integrated security=true";
        
        public bool IsPlayerNameExistsInDb(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT count(*) FROM Player WHERE 'Name' = @name";
                    command.Parameters.AddWithValue("@name", name);
                    var existingPlayersCount = (int)command.ExecuteScalar();
                    return existingPlayersCount > 0 ;
                }
            }
        }

        public void AddNewPlayerIntoDb(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Player ([Name]) VALUES (@name)";
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
