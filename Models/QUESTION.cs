using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class QUESTION
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int QuestionId { get; private set; }
        public string QuestionText { get; set; }
        public GAME? Game { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int GameId { get; set; }
        public List<ANSWER> answers { get; set; } = new List<ANSWER>();// Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
        public QUESTION(string questionText, int gameId)
        {
            QuestionText = questionText;
            GameId = gameId;
        }
        public QUESTION(int questionid, string questiontext)
        {
            QuestionId = questionid;
            QuestionText = questiontext;
        }
        public QUESTION()
        {
            
        }

        public bool SetQuestionId(int id)
        {
            QuestionId = id;
            return true;
        }// Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddQuestion()
        {
            return sqlDAL.AddQuestion(this);
        }
        public bool UpdateQuestion(QUESTION question)
        {
            return sqlDAL.UpdateQuestion(question);
        }
        public List<QUESTION> GetQuestions()
        {
            return sqlDAL.GetQuestions();
        }
        public bool DeleteQuestion()
        {
            return sqlDAL.DeleteQuestion(this.QuestionId);
        }

    }
}