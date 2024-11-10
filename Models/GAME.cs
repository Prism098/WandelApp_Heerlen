using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class GAME
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        private List<ANSWER>? answers;
        private GAME gamequestions;

        public int GameId { get; private set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public int? Points { get; set; }
        public ROUTE? Route { get; set; }
        public int RouteId { get; set; }
        public List<QUESTION> questions { get; set; } = new List<QUESTION>();  // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<ANSWER> Answers { get; set; } = new List<ANSWER>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public string QuestionText { get; set; }
        public int QuestionId { get; set; }
        public string AnswerId { get; set; }

        //Constructors that are being used to make database calls
        public GAME(int gameId, string name, DateTime startTime, int routeId, int? points)
        {
            GameId = gameId;
            Name = name;
            StartTime = startTime;
            RouteId = routeId;
            Points = points;
            this.questions = questions ?? new List<QUESTION>();
            this.Answers = answers ?? new List<ANSWER>();
        }
        public GAME(string name, DateTime startTime, int routeId)
        {
            Name = name;
            StartTime = startTime;
            RouteId = routeId;
        }

        public GAME(GAME gamequestions)
        {
            this.gamequestions = gamequestions;
        }

        public bool SetGameId(int id)
        {
            GameId = id;
            return true;
        }// Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddGame()
        {
            return sqlDAL.AddGame(this);
        }
        public bool UpdateGame(GAME game)
        {
            return sqlDAL.UpdateGame(game);
        }
        public List<GAME> GetGames()
        {
            return sqlDAL.GetGames();
        }
        public bool DeleteGame()
        {
            return sqlDAL.DeleteGame(this.GameId);
        }

        // Randomizer questions
        public (string QuestionText, string? CorrectAnswer) AskRandomQuestion()
        {
            if (questions == null || questions.Count == 0)
            {
                return ("No questions available.", null);
            }

            Random rand = new Random();
            var randomQuestion = questions[rand.Next(questions.Count)];

            var correctAnswer = Answers
                .Where(a => a.QuestionId == randomQuestion.QuestionId)
                .FirstOrDefault()?.AnswerText;

            return (randomQuestion.QuestionText, correctAnswer);
        }
    }
}
