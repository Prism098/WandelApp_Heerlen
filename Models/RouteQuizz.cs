using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class RouteQuizz
    {
        public int Id { get; private set; }
        public List<QUESTION> questions { get; set; } = new List<QUESTION>();
        public List<ANSWER> answer { get; set; } = new List<ANSWER>();

        public List<ANSWER> GetAnswers()
        {
            List<ANSWER> answers = new List<ANSWER>(); // Initialize the list
            try
            {
                string sql = "SELECT * FROM ANSWER";
                using (SqlConnection connection = new SqlConnection("your_connection_string"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string answerText = reader["AnswerText"]?.ToString() ?? string.Empty;
                                int answerId = Convert.ToInt32(reader["AnswerId"]);
                                int questionId = Convert.ToInt32(reader["QuestionId"]);
                                ANSWER answer = new ANSWER(answerId, answerText, questionId);
                                answers.Add(answer);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return answers;
        }

        public List<QUESTION> GetQuestions()
        {
            List<QUESTION> questions = new List<QUESTION>(); // Initialize the list
            try
            {
                string sql = "SELECT * FROM QUESTION";
                using (SqlConnection connection = new SqlConnection("your_connection_string"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string questionText = reader["QuestionText"]?.ToString() ?? string.Empty;
                                int gameId = Convert.ToInt32(reader["GameId"]);
                                QUESTION question = new QUESTION(gameId,questionText);
                                questions.Add(question);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return questions;
        }
    }
}
