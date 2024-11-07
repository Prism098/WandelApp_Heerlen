using System.Data.SqlClient;
using ExotischNederlandKaasus.Models;

namespace ExotischNederlandKaasus.DAL
{
    internal class SQLDAL
    {
        private static SQLDAL? instance;
        private SqlConnection connection;
        private string connectionString;
        private List<ROLE> roles;
        private List<OBSERVATION> Observation;
        private SQLDAL()
        {
            roles = new List<ROLE>();
            connectionString = "Data Source=.;Initial Catalog=EXOTISCHNEDERLAND; Trusted_Connection=True";
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

        // ROLE METHODS FOR DATABASE INTERACTIONS
        public List<ROLE> AddOrUpdateRole(ROLE role)
        {
            // Add role to database
            string query = "INSERT INTO ROLE (Name, Description) " +
                           "VALUES (@Name, @Description)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", role.Name);
            command.Parameters.AddWithValue("@Description", role.Description);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                int addId = (int)command.ExecuteScalar();
                role.SetRoleId(addId); // Use the method to set the ID
                // Check if the role exists
                string checkQuery = "SELECT COUNT(*) FROM ROLE WHERE Name = @Name";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Name", role.Name);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Update existing role
                    command = new SqlCommand("UPDATE ROLE SET Description = @Description WHERE Name = @Name", connection);
                }
                else
                {
                    // Insert new role
                    command = new SqlCommand("INSERT INTO ROLE (Name, Description) VALUES (@Name, @Description); SELECT CAST(scope_identity() AS INT)", connection);
                }

                command.Parameters.AddWithValue("@Name", role.Name);
                command.Parameters.AddWithValue("@Description", role.Description);

                // Auto increment the Role ID.
                int roleId = (int)command.ExecuteScalar();
                role.SetRoleId(roleId);

                roles.Add(role);
            }
            // Catch exceptions
            catch (Exception ex)
            {
                // Handle exceptions 
                throw new Exception("An error occurred while adding/updating the role.", ex);
            }
            finally
            {
                connection.Close();
            }

            roles.Add(role);
            return roles;
        }
        public List<ROLE> GetRoles()
        {
            try
            {
                string sql = "SELECT * FROM ROLE";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ROLE role = new ROLE(reader["Name"].ToString(), reader["Description"].ToString());
                            role.SetRoleId((int)reader["RoleId"]);
                            roles.Add(role);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return roles;
        }
        public void DeleteRole(int roleId)
        {
            try
            {
                string sql = "DELETE FROM ROLE WHERE RoleId=@RoleId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@RoleId", roleId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        // OBSERVATION METHODS FOR DATABASE INTERACTIONS

        // CRUD for Observation
        public List<OBSERVATION> GetAllObservations()
        {
            Observation.Clear();
            string query = "SELECT * FROM OBSERVATION";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int observationId = Convert.ToInt32(reader["ObservationId"]);
                    DateTime dateObserved = Convert.ToDateTime(reader["DateObserved"]);
                    string observer = reader["Observer"].ToString();
                    string description = reader["Description"].ToString();
                    //Blob picture = reader["Picture"].ToString(); ;
                    int areaId = Convert.ToInt32(reader["AreaId"]);
                    int specieId = Convert.ToInt32(reader["SpecieId"]);
                    int userId = Convert.ToInt32(reader["UserId"]);

                }
                reader.Close();
            }

            connection.Close();
            return Observation;
        }
    }






    // SPECIE METHODS FOR DATABASE INTERACTIONS
    //private SPECIE AddSpecie(SPECIE specie)
    //{
    //    // Add specie to database
    //    string query = "INSERT INTO SPECIE (Name, InvasivenessLevel) " +
    //        "VALUES (@Name, @InvasivenessLevel)";
    //    SqlCommand command = new SqlCommand(query, connection);
    //    command.Parameters.AddWithValue("@Name", specie.Name);
    //    command.Parameters.AddWithValue("@InvasivenessLevel", specie.InvasivenessLevel);

    //    try
    //    {
    //        connection.Open();
    //        command.ExecuteNonQuery();

    //        // Retrieve the auto-incremented ID
    //        command.CommandText = "SELECT CAST(scope_identity() AS INT)";
    //        int addId = (int)command.ExecuteScalar();
    //        specie.SpecieId = addId;
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle exceptions 
    //        throw new Exception("An error occurred while adding the specie.", ex);
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }

    //    return specie;
    //}


    //public void DeleteSpecie(int specieId)
    //{
    //    try
    //    {

    //        string sql = "DELETE FROM Player WHERE Id=@Id";
    //        connection.Open();

    //        using (SqlCommand command = new SqlCommand(sql, connection))
    //        {
    //            command.Parameters.AddWithValue("@Id", specieId);
    //            command.ExecuteNonQuery();
    //        }

    //        connection.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("An error occurred: " + ex.Message);
    //    }
    //}

}