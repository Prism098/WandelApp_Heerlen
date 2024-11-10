using System.Data.SqlClient;
using ExotischNederlandKaasus.Models;
using ExotischNederlandKaasus.Models.ExotischNederlandKaasus.Models;

namespace ExotischNederlandKaasus.DAL
{
    internal class SQLDAL
    {
        private static SQLDAL? instance;

        private readonly SqlConnection connection;
        private string connectionString;

        private List<ROLE> roles;
        private List<ANSWER> answers;
        private List<QUESTION> questions;
        private List<AREA> areas;
        private List<GAME> games;
        private List<ROUTE> routes;
        private List<USER> users;
        private List<USRQUEST> usrQuests;
        private List<OBSERVATION> observations;

        private SQLDAL()
        {
            answers = new List<ANSWER>();
            roles = new List<ROLE>();
            questions = new List<QUESTION>();
            areas = new List<AREA>();
            games = new List<GAME>();
            observations = new List<OBSERVATION>();
            routes = new List<ROUTE>();
            users = new List<USER>();
            usrQuests = new List<USRQUEST>();

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
        public bool AddAnswer(ANSWER answer) // in this method we tried checking for database constraint in the DAL. There is also a couple of functions where we don't check this on the backend. Wasn't as succesfull as we hoped.
        {
            // Query checks by counting the elements in the database if there is a questionId.
            string checkQuery = "SELECT COUNT(1) FROM QUESTION WHERE QuestionId = @QuestionId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@QuestionId", answer.QuestionId);
            try
            {
                // Make a check if the question ID exists in the database
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
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
                return true;
            }
            catch (KeyNotFoundException knfEx)
            {
                Console.WriteLine(knfEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the answer: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateAnswer(ANSWER answer)
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
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the answer.", ex);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return answers;
        }
        public bool DeleteAnswer(int answerId)
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // AREA METHODS FOR DATABASE INTERACTIONS
        public bool AddArea(AREA area)
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
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the area.", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateArea(AREA area)
        {
            string query = "UPDATE AREA SET Owner = @Owner, Name = @Name, Region = @Region, Type = @Type WHERE AreaId = @AreaId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Owner", area.Owner);
            command.Parameters.AddWithValue("@Name", area.Name);
            command.Parameters.AddWithValue("@Region", area.Region);
            command.Parameters.AddWithValue("@Type", area.Type);
            command.Parameters.AddWithValue("@AreaID", area.AreaId);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the area.", ex);
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
                            string owner = reader["Owner"]?.ToString() ?? string.Empty;
                            string name = reader["Name"]?.ToString() ?? string.Empty;
                            string region = reader["Region"]?.ToString() ?? string.Empty;
                            string type = reader["Type"]?.ToString() ?? string.Empty;

                            AREA area = new AREA(owner, name, region, type);
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
        public bool DeleteArea(int areaId)
        {
            string sql = "DELETE FROM AREA WHERE AreaId=@AreaId";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AreaId", areaId);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
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
                    Console.WriteLine($"The provided RouteId '{game.RouteId}' does not exist in the database.");
                    return false;
                }

                game.StartTime = DateTime.Now;

                string query = "INSERT INTO GAME (Name, StartTime, RouteId) VALUES (@Name, @StartTime, @RouteId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@StartTime", game.StartTime);
                command.Parameters.AddWithValue("@RouteId", game.RouteId);

                command.ExecuteNonQuery();

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
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the game: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateGame(GAME game)
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the game: " + ex.Message);
                return false;
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
                            int gameId = Convert.ToInt32(reader["GameId"]);
                            string name = reader["Name"]?.ToString() ?? string.Empty;
                            DateTime startTime = Convert.ToDateTime(reader["StartTime"]);
                            int routeId = Convert.ToInt32(reader["RouteId"]);
                            int? points = reader["Points"] != DBNull.Value ? (int?)reader["Points"] : null;

                            GAME game = new GAME(gameId, name, startTime, routeId, points);

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
        public bool DeleteGame(int gameId)
        {
            try
            {
                string sql = "DELETE FROM GAME WHERE GameId=@GameId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@gameId", gameId);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // OBSERVATION METHODS FOR DATABASE INTERACTIONS
        public bool AddObservation(OBSERVATION observation)
        {
            string checkQuery = "SELECT COUNT(1) FROM AREA WHERE AreaId = @AreaId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@AreaId", observation.AreaId);
            try
            {
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    // Provide more information about the failure
                    Console.WriteLine($"The provided AreaId '{observation.AreaId}' does not exist in the database.");
                    return false;
                }

                // Proceed with inserting the observation
                string query = "INSERT INTO OBSERVATION (DateObserved, Observer, Description, AreaId, UserId, SpecieId) VALUES (@DateObserved, @Observer, @Description, @AreaId, @UserId, @SpecieId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DateObserved", DateTime.Now);
                command.Parameters.AddWithValue("@Observer", observation.Observer);
                command.Parameters.AddWithValue("@Description", observation.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@AreaId", observation.AreaId);
                command.Parameters.AddWithValue("@UserId", observation.UserId);
                command.Parameters.AddWithValue("@SpecieId", observation.SpecieId);

                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int addId = (int)result;
                    observation.SetObservationId(addId);
                }
                observations.Add(observation);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the observation: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateObservation(OBSERVATION observation)
        {
            string query = "UPDATE OBSERVATION SET DateObserved = @DateObserved, Observer = @Observer, Description = @Description, AreaId = @AreaId, UserId = @UserId, SpecieId = @SpecieId WHERE ObservationId = @ObservationId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DateObserved", observation.DateObserved);
            command.Parameters.AddWithValue("@Observer", observation.Observer);
            command.Parameters.AddWithValue("@Description", observation.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@AreaId", observation.AreaId);
            command.Parameters.AddWithValue("@UserId", observation.UserId);
            command.Parameters.AddWithValue("@SpecieId", observation.SpecieId);
            command.Parameters.AddWithValue("@ObservationId", observation.ObservationId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the observation: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<OBSERVATION> GetObservations()
        {
            List<OBSERVATION> observations = new List<OBSERVATION>();
            try
            {
                string sql = "SELECT * FROM OBSERVATION";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int observationId = (int)reader["ObservationId"];
                            DateTime dateObserved = (DateTime)reader["DateObserved"];
                            string observer = reader["Observer"]?.ToString() ?? string.Empty;
                            string description = reader["Description"]?.ToString() ?? string.Empty;
                            int areaId = (int)reader["AreaId"];
                            int userId = (int)reader["UserId"];
                            int specieId = (int)reader["SpecieId"];

                            OBSERVATION observation = new OBSERVATION(observationId, dateObserved, observer, description, areaId, userId, specieId);
                            observations.Add(observation);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return observations;
        }
        public bool DeleteObservation(int observationId)
        {
            try
            {
                string sql = "DELETE FROM OBSERVATION WHERE ObservationId=@ObservationId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ObservationId", observationId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // POI METHODS FOR DATABASE INTERACTIONS
        public bool AddPOI(POI poi)
        {
            string checkQuery = "SELECT COUNT(1) FROM ROUTEPOINT WHERE RoutePointId = @RoutePointId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@RoutePointId", poi.RoutePointId);
            try
            {
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    // Provide more information about the failure
                    Console.WriteLine($"The provided RoutePointId '{poi.RoutePointId}' does not exist in the database.");
                    return false;
                }

                // Proceed with inserting the POI
                string query = "INSERT INTO POI (Longitude, Latitude, Description, Type, RoutePointId) VALUES (@Longitude, @Latitude, @Description, @Type, @RoutePointId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Longitude", poi.Longitude);
                command.Parameters.AddWithValue("@Latitude", poi.Latitude);
                command.Parameters.AddWithValue("@Description", poi.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Type", poi.Type);
                command.Parameters.AddWithValue("@RoutePointId", poi.RoutePointId);

                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int poiId = (int)result;
                    poi.SetPOIId(poiId);
                }
                return true;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdatePOI(POI poi)
        {
            string query = "UPDATE POI SET Longitude = @Longitude, Latitude = @Latitude, Description = @Description, Type = @Type, RoutePointId = @RoutePointId WHERE POIId = @POIId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Longitude", poi.Longitude);
            command.Parameters.AddWithValue("@Latitude", poi.Latitude);
            command.Parameters.AddWithValue("@Description", poi.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Type", poi.Type);
            command.Parameters.AddWithValue("@RoutePointId", poi.RoutePointId);
            command.Parameters.AddWithValue("@POIId", poi.POIId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the POI: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<POI> GetPOI()
        {
            List<POI> pois = new List<POI>();
            try
            {
                string sql = "SELECT * FROM POI";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int poiId = Convert.ToInt32(reader["POIId"]);
                            decimal longitude = Convert.ToDecimal(reader["Longitude"]);
                            decimal latitude = Convert.ToDecimal(reader["Latitude"]);
                            string? description = reader["Description"]?.ToString() ?? string.Empty;
                            string type = reader["Type"]?.ToString() ?? string.Empty;
                            int routePointId = Convert.ToInt32(reader["RoutePointId"]);

                            POI poi = new POI(poiId, longitude, latitude, description, type, routePointId);
                            pois.Add(poi);
                        }
                    }
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
            return pois;
        }
        public bool DeletePOI(int poiId)
        {
            try
            {
                string sql = "DELETE FROM POI WHERE POIId=@POIId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@POIId", poiId);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
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
        public bool UpdateQuestion(QUESTION question)
        {
            string query = "UPDATE QUESTION SET QuestionText = @QuestionText, GameId = @GameId WHERE QuestionId = @QuestionId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
            command.Parameters.AddWithValue("@GameId", question.GameId);
            command.Parameters.AddWithValue("@QuestionId", question.QuestionId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the question: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<QUESTION> GetQuestions()
        {
            List<QUESTION> questions = new List<QUESTION>();
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
        public bool DeleteQuestion(int questionId)
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // ROLE METHODS FOR DATABASE INTERACTIONS
        public bool AddRole(ROLE role)
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the role: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateRole(ROLE role)
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the role: " + ex.Message);
                return false;
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
                            string name = reader["Name"]?.ToString() ?? string.Empty;
                            string description = reader["Description"]?.ToString() ?? string.Empty;

                            ROLE role = new ROLE(name, description);
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
        public bool DeleteRole(int roleId)
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // ROUTE METHOD FOR DATABASE INTERACTIONS
        public bool AddRoute(ROUTE route)
        {
            string query = "INSERT INTO ROUTE (Length, Longitude, Latitude, Type, AreaId) VALUES (@Length, @Longitude, @Latitude, @Type, @AreaId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Length", route.Length);
            command.Parameters.AddWithValue("@Longitude", route.Longitude);
            command.Parameters.AddWithValue("@Latitude", route.Latitude);
            command.Parameters.AddWithValue("@Type", route.Type);
            command.Parameters.AddWithValue("@AreaId", route.AreaId);

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
                    route.SetRouteId(addId);
                }

                routes.Add(route);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the route: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateRoute(ROUTE route)
        {
            string query = "UPDATE ROUTE SET Length = @Length, Longitude = @Longitude, Latitude = @Latitude, Type = @Type, AreaId = @AreaId WHERE RouteId = @RouteId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RouteId", route.RouteId);
            command.Parameters.AddWithValue("@Length", route.Length);
            command.Parameters.AddWithValue("@Longitude", route.Longitude);
            command.Parameters.AddWithValue("@Latitude", route.Latitude);
            command.Parameters.AddWithValue("@Type", route.Type);
            command.Parameters.AddWithValue("@AreaId", route.AreaId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the route: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<ROUTE> GetRoutes()
        {
            List<ROUTE> routes = new List<ROUTE>();
            try
            {
                string sql = "SELECT * FROM ROUTE";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ROUTE route = new ROUTE(
                                (int)reader["RouteId"],
                                (int)reader["Length"],
                                (decimal)reader["Longitude"],
                                (decimal)reader["Latitude"],
                                reader["Type"]?.ToString() ?? string.Empty,
                                (int)reader["AreaId"]);

                            routes.Add(route);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return routes;
        }
        public bool DeleteRoute(int routeId)
        {
            try
            {
                string sql = "DELETE FROM ROUTE WHERE RouteId=@RouteId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@RouteId", routeId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // ROUTEPOINT METHODS FOR DATABASE INTERACTION 
        public bool AddRoutePoint(ROUTEPOINT routePoint)
        {
            string query = "INSERT INTO ROUTEPOINT (Longitude, Latitude, SequenceNumber) VALUES (@Longitude, @Latitude, @SequenceNumber)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Longitude", routePoint.Longitude);
            command.Parameters.AddWithValue("@Latitude", routePoint.Latitude);
            command.Parameters.AddWithValue("@SequenceNumber", routePoint.SequenceNumber);

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
                    routePoint.SetRoutePointId(addId);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the route point: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateRoutePoint(ROUTEPOINT routePoint)
        {
            string query = "UPDATE ROUTEPOINT SET Longitude = @Longitude, Latitude = @Latitude, SequenceNumber = @SequenceNumber WHERE RoutePointId = @RoutePointId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RoutePointId", routePoint.RoutePointId);
            command.Parameters.AddWithValue("@Longitude", routePoint.Longitude);
            command.Parameters.AddWithValue("@Latitude", routePoint.Latitude);
            command.Parameters.AddWithValue("@SequenceNumber", routePoint.SequenceNumber);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the route point: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<ROUTEPOINT> GetRoutePoints()
        {
            List<ROUTEPOINT> routePoints = new List<ROUTEPOINT>();
            try
            {
                string sql = "SELECT * FROM ROUTEPOINT";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ROUTEPOINT routePoint = new ROUTEPOINT(
                                (int)reader["RoutePointId"],
                                (decimal)reader["Longitude"],
                                (decimal)reader["Latitude"],
                                (int)reader["SequenceNumber"]);

                            routePoints.Add(routePoint);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return routePoints;
        }
        public bool DeleteRoutePoint(int routePointId)
        {
            try
            {
                string sql = "DELETE FROM ROUTEPOINT WHERE RoutePointId=@RoutePointId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@RoutePointId", routePointId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the route point: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // SPECIE METHODS FOR DATABASE INTERACTIONS
        public bool AddSpecie(SPECIE specie)
        {
            string query = "INSERT INTO SPECIE (Name, InvasivenessLevel) VALUES (@Name, @InvasivenessLevel)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", specie.Name);
            command.Parameters.AddWithValue("@InvasivenessLevel", specie.InvasivenessLevel);

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
                    specie.SetSpecieId(addId);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the specie: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateSpecie(SPECIE specie)
        {
            string query = "UPDATE SPECIE SET Name = @Name, InvasivenessLevel = @InvasivenessLevel WHERE SpecieId = @SpecieId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SpecieId", specie.SpecieId);
            command.Parameters.AddWithValue("@Name", specie.Name);
            command.Parameters.AddWithValue("@InvasivenessLevel", specie.InvasivenessLevel);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the specie: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<SPECIE> GetSpecies()
        {
            List<SPECIE> species = new List<SPECIE>();
            try
            {
                string sql = "SELECT * FROM SPECIE";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SPECIE specie = new SPECIE(
                            (int)reader["SpecieId"],
                            (string)reader["Name"],
                            reader["InvasivenessLevel"] as string);

                        species.Add(specie);
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return species;
        }
        public bool DeleteSpecie(int specieId)
        {
            try
            {
                string sql = "DELETE FROM SPECIE WHERE SpecieId=@SpecieId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SpecieId", specieId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the specie: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // USER METHODS FOR DATABASE INTERACTIONS
        public bool AddUser(USER user)
        {
            string checkQuery = "SELECT COUNT(1) FROM ROUTE WHERE RouteId = @RouteId";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@RouteId", user.RouteId);
            try
            {
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    throw new KeyNotFoundException($"The provided RouteId '{user.RouteId}' does not exist in the database.");
                }

                // Proceed with inserting the user
                string query = "INSERT INTO [USER] (Name, Description, Role, Experience, RouteId) VALUES (@Name, @Description, @Role, @Experience, @RouteId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Description", user.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Experience", user.Experience ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@RouteId", user.RouteId);

                command.ExecuteNonQuery();

                // Retrieve the auto-incremented ID
                command.CommandText = "SELECT CAST(scope_identity() AS INT)";
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    int addId = (int)result;
                    user.SetUserId(addId);
                }
                users.Add(user);
                return true;
            }
            catch (KeyNotFoundException knfEx)
            {
                // Handle known exception type specifically
                Console.WriteLine(knfEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the user: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateUser(USER user)
        {
            string query = "UPDATE [USER] SET Name = @Name, Description = @Description, Role = @Role, Experience = @Experience, RouteId = @RouteId WHERE UserId = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Description", user.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Role", user.Role);
            command.Parameters.AddWithValue("@Experience", user.Experience ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@RouteId", user.RouteId);
            command.Parameters.AddWithValue("@UserId", user.UserId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the user: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<USER> GetUsers()
        {
            List<USER> users = new List<USER>();
            try
            {
                string sql = "SELECT * FROM [USER]";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            USER user = new USER(
                                (int)reader["UserId"],
                                (string)reader["Name"],
                                reader["Description"] as string,
                                (int)reader["Role"],
                                reader["Experience"] as int?,
                                (int)reader["RouteId"]);

                            users.Add(user);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return users;
        }
        public bool DeleteUser(int userId)
        {
            try
            {
                string sql = "DELETE FROM [USER] WHERE UserId=@UserId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // USERGAME METHODS FOR DATABASE INTERACTIONS
        public bool AddUsrQuest(USRQUEST usrQuest)
        {
            string query = "INSERT INTO USRQUEST (AnswerText, UserId, QuestionId) VALUES (@AnswerText, @UserId, @QuestionId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AnswerText", usrQuest.AnswerText);
            command.Parameters.AddWithValue("@UserId", usrQuest.UserId);
            command.Parameters.AddWithValue("@QuestionId", usrQuest.QuestionId);

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
                    usrQuest.SetUsrQuestId(addId);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the usrQuest: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateUsrQuest(USRQUEST usrQuest)
        {
            string query = "UPDATE USRQUEST SET AnswerText = @AnswerText, UserId = @UserId, QuestionId = @QuestionId WHERE UsrQuestId = @UsrQuestId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AnswerText", usrQuest.AnswerText ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UserId", usrQuest.UserId);
            command.Parameters.AddWithValue("@QuestionId", usrQuest.QuestionId);
            command.Parameters.AddWithValue("@UsrQuestId", usrQuest.UsrQuestId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the usrQuest: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<USRQUEST> GetUsrQuests()
        {
            List<USRQUEST> usrQuests = new List<USRQUEST>();
            try
            {
                string sql = "SELECT * FROM USRQUEST";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int usrQuestId = (int)reader["UsrQuestId"];
                            string answerText = reader["AnswerText"]?.ToString() ?? string.Empty;
                            int userId = (int)reader["UserId"];
                            int questionId = (int)reader["QuestionId"];

                            USRQUEST usrQuest = new USRQUEST(usrQuestId, answerText, userId, questionId);
                            usrQuests.Add(usrQuest);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return usrQuests;
        }
        public bool DeleteUsrQuest(int usrQuestId)
        {
            try
            {
                string sql = "DELETE FROM USRQUEST WHERE UsrQuestId=@UsrQuestId";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UsrQuestId", usrQuestId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}