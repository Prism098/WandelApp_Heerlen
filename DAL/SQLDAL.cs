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
        private List<OBSERVATION> observations;
        private List<ANSWER> answers;
        private SQLDAL()
        {
            answers = new List<ANSWER>();
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




        // ANSWER METHODS FOR DATABASE INTERACTIONS
        public void AddAnswer(ANSWER answer)
        {
            string checkQuery = "SELECT COUNT(1) FROM QUESTION WHERE QuestionId = @QuestionId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@QuestionId", answer.QuestionId);
            try
            {
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    // Provide more information about the failure
                    throw new KeyNotFoundException($"The provided QuestionId '{answer.QuestionId}' does not exist in the database.");
                }

                // Proceed with inserting the answer
                string query = "INSERT INTO ANSWER (AnswerText, QuestionId) VALUES (@AnswerText, @QuestionId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AnswerText", answer.AnswerText);
                command.Parameters.AddWithValue("@QuestionId", answer.QuestionId);

                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int addId = (int)result;
                    answer.SetAnswerId(addId);
                }
                answers.Add(answer);
            }
            catch (KeyNotFoundException knfEx)
            {
                // Handle known exception type specifically
                Console.WriteLine(knfEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the answer.", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateAnswer(ANSWER answer)
        {
            string query = "UPDATE ANSWER SET AnswerText = @AnswerText, QuestionId = @QuestionId WHERE AnswerId = @AnswerId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AnswerId", answer.AnswerId);
            command.Parameters.AddWithValue("@AnswerText", answer.AnswerText);
            command.Parameters.AddWithValue("@QuestionId", answer.QuestionId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the role.", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<ANSWER> GetAnswers()
        {
            List<ANSWER> answers = new List<ANSWER>(); // Initialize the list
            try
            {
                string sql = "SELECT * FROM ANSWER";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          
                            string answerText = reader["AnswerText"]?.ToString() ?? string.Empty;
                            int questionId = Convert.ToInt32(reader["QuestionId"]);
                            ANSWER answer = new ANSWER(answerText, questionId);
                            answer.SetAnswerId((int)reader["AnswerId"]);
                            answers.Add(answer);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return answers;
        }
        public void DeleteAnswer(int answerId)
        {
            try
            {
                string sql = "DELETE FROM ANSWER WHERE AnswerId=@AnswerId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AnswerId", answerId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // ROLE METHODS FOR DATABASE INTERACTIONS
        public void AddRole(ROLE role)
        {
            string query = "INSERT INTO ROLE (Name, Description) VALUES (@Name, @Description)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", role.Name);
            command.Parameters.AddWithValue("@Description", role.Description);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int addId = (int)result;
                    role.SetRoleId(addId);
                }

                roles.Add(role);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the role.", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateRole(ROLE role)
        {
            string query = "UPDATE ROLE SET Name = @Name, Description = @Description WHERE RoleId = @RoleId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RoleId", role.RoleId);
            command.Parameters.AddWithValue("@Name", role.Name);
            command.Parameters.AddWithValue("@Description", role.Description);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the role.", ex);
            }
            finally
            {
                connection.Close();
            }
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
            finally
            {
                connection.Close();
            }
        }

        // OBSERVATION METHODS FOR DATABASE INTERACTIONS

        // CRUD for Observation
        public List<OBSERVATION> GetAllObservations()
        {
            observations.Clear();
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
            return observations;
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