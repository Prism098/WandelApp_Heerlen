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
        private List<ANSWER> answers;
        private List<QUESTION> questions;
        private List<AREA> areas;
        private List<GAME> games;

        private List<OBSERVATION> observations;
        private SQLDAL()
        {
            answers = new List<ANSWER>();
            roles = new List<ROLE>();
            questions = new List<QUESTION>();
            areas = new List<AREA>();
            games = new List<GAME>();
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

        // AREA METHODS FOR DATABASE INTERACTIONS
        public void AddArea(AREA area)
        {
            string query = "INSERT INTO AREA (Owner, Name, Region, Type) VALUES (@Owner, @Name, @Region, @Type)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Owner", area.Owner);
            command.Parameters.AddWithValue("@Name", area.Name);
            command.Parameters.AddWithValue("@Region", area.Region);
            command.Parameters.AddWithValue("@Type", area.Type);

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
                    area.SetAreaId(addId);
                }

                areas.Add(area);
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
        public void UpdateArea(AREA area)
        {
            string query = "UPDATE AREA SET Owner = @Owner, Name = @Name, Region = @Region, Type = @Type WHERE AreaId = @AreaId ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Owner", area.Owner);
            command.Parameters.AddWithValue("@Name", area.Name);
            command.Parameters.AddWithValue("@Region", area.Region);
            command.Parameters.AddWithValue("@Type", area.Type);

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
        public List<AREA> GetAreas()
        {
            List<AREA> areas = new List<AREA>();
            try
            {
                string sql = "SELECT * FROM AREA";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AREA area = new AREA(
                                reader["Owner"].ToString(),
                                reader["Name"].ToString(),
                                reader["Region"].ToString(),
                                reader["Type"].ToString()
                            );
                            area.SetAreaId((int)reader["AreaId"]);
                            areas.Add(area);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return areas;
        }
        public void DeleteArea(int areaId)
        {
            try
            {
                string sql = "DELETE FROM AREA WHERE AreaId=@AreaId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AreaId", areaId);
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

        // GAME METHODS FOR DATABASE INTERACTIONS
        public bool AddGame(GAME game)
        {
            string checkQuery = "SELECT COUNT(1) FROM ROUTE WHERE RouteId = @RouteId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@RouteId", game.RouteId);
            try
            {
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    // Provide more information about the failure, made a choice to fix this in the DB, we know we want.
                    Console.WriteLine($"The provided RouteId '{game.RouteId}' does not exist in the database.");
                    return false;
                }

                // Set the StartTime to DateTime.Now
                game.StartTime = DateTime.Now;

                // Proceed with inserting the game
                string query = "INSERT INTO GAME (Name, StartTime, RouteId) VALUES (@Name, @StartTime, @RouteId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@StartTime", game.StartTime);
                command.Parameters.AddWithValue("@RouteId", game.RouteId);

                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int addId = (int)result;
                    game.SetGameId(addId);
                }
                games.Add(game);
                return true;
            }
            catch (KeyNotFoundException knfEx)
            {
                Console.WriteLine(knfEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the game.", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateGame(GAME game)
        {
            string query = "UPDATE GAME SET Name = @Name, StartTime = @StartTime, RouteId = @RouteId, Points = @Points, EndTime = @EndTime WHERE GameId = @GameId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", game.Name);
            command.Parameters.AddWithValue("@StartTime", game.StartTime);
            command.Parameters.AddWithValue("@RouteId", game.RouteId);
            command.Parameters.AddWithValue("@Points", game.Points.HasValue ? (object)game.Points.Value : DBNull.Value);
            command.Parameters.AddWithValue("@EndTime", game.EndTime.HasValue ? (object)game.EndTime.Value : DBNull.Value);
            command.Parameters.AddWithValue("@GameId", game.GameId);
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
        public List<GAME> GetGames()
        {
            List<GAME> games = new List<GAME>(); // Initialize the list
            try
            {
                string sql = "SELECT * FROM GAME";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"]?.ToString() ?? string.Empty;
                            DateTime startTime = Convert.ToDateTime(reader["StartTime"]);
                            int routeId = Convert.ToInt32(reader["RouteId"]);
                            GAME game = new GAME(name, startTime, routeId);
                            game.SetGameId((int)reader["GameId"]);
                            games.Add(game);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return games;
        }
        public void DeleteGame(int gameId)
        {
            try
            {
                string sql = "DELETE FROM GAME WHERE GameId=@GameId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@gameId", gameId);
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

        // QUESTION METHODS FOR DATABASE INTERACTIONS
        public bool AddQuestion(QUESTION question)
        {
            string checkQuery = "SELECT COUNT(1) FROM GAME WHERE GameId = @GameId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@GameId", question.GameId);
            try
            {
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    // Provide more information about the failure
                    Console.WriteLine($"The provided GameId '{question.GameId}' does not exist in the database.");
                    return false;
                }

                // Proceed with inserting the answer
                string query = "INSERT INTO QUESTION (QuestionText, GameId) VALUES (@QuestionText, @GameId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@GameId", question.GameId);

                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int addId = (int)result;
                    question.SetQuestionId(addId);
                }
                questions.Add(question);
                return true;
            }
            catch (KeyNotFoundException knfEx)
            {
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
        public void UpdateQuestion(QUESTION question)
        {
            string query = "UPDATE QUESTION SET QuestionText = @QuestionText, GameId = @GameId WHERE QuestionId = @QuestionId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AnswerId", question.QuestionText);
            command.Parameters.AddWithValue("@GameId", question.GameId);
            command.Parameters.AddWithValue("@QuestionId", question.QuestionId);
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
        public List<QUESTION> GetQuestions()
        {
            List<QUESTION> questions = new List<QUESTION>(); // Initialize the list
            try
            {
                string sql = "SELECT * FROM QUESTION";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string questionText = reader["QuestionText"]?.ToString() ?? string.Empty;
                            int gameId = Convert.ToInt32(reader["GameId"]);
                            QUESTION question = new QUESTION(questionText, gameId);
                            question.SetQuestionId((int)reader["QuestionId"]);
                            questions.Add(question);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return questions;
        }
        public void DeleteQuestion(int questionId)
        {
            try
            {
                string sql = "DELETE FROM QUESTION WHERE QuestionId=@QuestionId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@QuestionId", questionId);
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