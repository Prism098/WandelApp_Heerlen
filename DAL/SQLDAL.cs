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
    internal class SQLDAL
    {
        private static SQLDAL? instance;
        private SqlConnection connection;
        private string connectionString;
        private List<ROLE> roles;

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
        public List<ROLE> AddRole(ROLE role)
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
            }
            catch (Exception ex)
            {
                // Handle exceptions 
                throw new Exception("An error occurred while adding the role.", ex);
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
}
