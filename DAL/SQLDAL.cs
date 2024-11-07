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
        public List<ROLE> AddOrUpdateRole(ROLE role)
        {
            try
            {
                connection.Open();

                // Check if the role exists
                string checkQuery = "SELECT COUNT(*) FROM ROLE WHERE Name = @Name";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Name", role.Name);
                int count = (int)checkCommand.ExecuteScalar();

                SqlCommand command;

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
                throw new Exception("An error occurred while adding/updating the role.", ex);
            }
            finally
            {
                connection.Close();
            }

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

    }
}
