using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ExotischNederlandKaasus.Models;

namespace ExotischNederlandKaasus.DAL
{
    public class SQLDAL
    {
        private static SQLDAL instance;
        private SqlConnection connection;
        private string connectionString;

        private SQLDAL()
        {
            connectionString = "Data Source=.;Initial Catalog=EXOTISCHNEDERLAND;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            // Create a new SqlConnection object
            connection = new SqlConnection(connectionString);
        }
        // Singleton pattern, only one instance of this class can exist at any given time. 
        public static SQLDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLDAL();
                }
                return instance;
            }
        }

        private List<OBSERVATION> AddObservation(OBSERVATION observation)
        {
            // Add vehicle to database

            string query = "INSERT INTO OBSERVATION (DateObserved, Observer, Description, Picture, AreaId, UserId, SpecieId) " +
                "VALUES (@DateObserved, @Observer, @Description, @Picture, @AreaId, @UserId, @SpecieId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DateObserved", observation.DateObserved);
            command.Parameters.AddWithValue("@Observer", observation.Observer);
            command.Parameters.AddWithValue("@Description", observation.Description);
            command.Parameters.AddWithValue("@Picture", observation.Picture);
            command.Parameters.AddWithValue("@AreaId", observation.AreaId);
            command.Parameters.AddWithValue("@UserId", observation.UserId);
            command.Parameters.AddWithValue("@SpecieId", observation.SpecieId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                int addId = (int)command.ExecuteScalar();
                observation.ObservationId(addId);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                throw new Exception("An error occurred while adding the observation.", ex);
            }
            finally
            {
                connection.Close();
            }

            return observation;
        }


    }
}
