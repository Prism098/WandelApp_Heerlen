using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExotischNederlandKaasus.Models;

namespace ExotischNederlandKaasus.Models
{
    internal class GAME
    {
        public int GameId { get; private set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public int? Points { get; set; }
        public ROUTE? Route { get; set; }
        public int RouteId { get; set; }
        public List<QUESTION> Questions { get; set; } = new List<QUESTION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        public List<ANSWER> Answers { get; set; } = new List<ANSWER>();


        public GAME()
        {
           
        }
        public List<ANSWER> GetAnswers()  // Methode om antwoorden op te halen uit de database
        {
            List<ANSWER> answers = new List<ANSWER>();
            try
            {
                string sql = "SELECT * FROM ANSWER";  // SQL query om antwoorden op te halen
                using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EXOTISCHNEDERLAND; Trusted_Connection=True"))
                {
                    connection.Open(); // Verbind met de database
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) // Voer de query uit en lees de resultaten
                        {
                            while (reader.Read())
                            {
                                string answerText = reader["AnswerText"]?.ToString() ?? string.Empty; // Lees de tekst van het antwoord
                                int answerId = Convert.ToInt32(reader["AnswerId"]); // Haal het bijbehorende antwoordID op
                                int questionId = Convert.ToInt32(reader["QuestionId"]); // Haal het bijbehorende vraagiD op
                                ANSWER answer = new ANSWER(answerId, answerText, questionId); // Maak een nieuw antwoord object
                                answers.Add(answer); // Voeg het antwoord toe aan de lijst
                            }
                        }
                    }
                    connection.Close(); // Sluit de verbinding met de database
                }
            }
            catch (Exception ex)
            {
                // Foutmelding als er iets misgaat met de databaseverbinding of query
                Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
            }
            return answers;  // Return de lijst met antwoorden
        }
        public List<QUESTION> GetQuestions() // Methode om vragen op te halen uit de database 
        {
            List<QUESTION> Questions = new List<QUESTION>();
            try
            {
                string sql = "SELECT * FROM QUESTION";  // SQL query om vragen op te halen
                using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EXOTISCHNEDERLAND; Trusted_Connection=True"))
                {
                    connection.Open(); // Verbind met de database
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) // Voer de query uit en lees de resultaten
                        {
                            while (reader.Read())
                            {
                                string questionText = reader["QuestionText"]?.ToString() ?? string.Empty; // Lees de tekst van de vraag
                                int gameId = Convert.ToInt32(reader["GameId"]); // Haal het bijbehorende gameID op
                                QUESTION question = new QUESTION(gameId, questionText); // Maak een nieuw vraag object
                                Questions.Add(question); // Voeg de vraag toe aan de lijst
                            }
                        }
                    }
                    connection.Close(); // Sluit de verbinding met de database
                }
            }
            catch (Exception ex)
            {
                // Foutmelding als er iets misgaat met de databaseverbinding of query
                Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
            }
            return Questions;  // Retourneer de lijst met vragen
        }
        public (string QuestionText, string CorrectAnswer) AskRandomQuestion()
        {
            // een random vraag uit de DB lijst
            Random rand = new Random();
            var randomQuestion = Questions[rand.Next(Questions.Count)];

            // Zoek juiste antwoord bij de vraag uit de DB
            var correctAnswer = Answers
                .Where(a => a.QuestionId == randomQuestion.QuestionId)
                .FirstOrDefault()?.AnswerText;

            return (randomQuestion.QuestionText, correctAnswer);
        }
    }
}
