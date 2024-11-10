using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class QUESTION
    {
<<<<<<< HEAD
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int QuestionId { get; private set; }
=======
        public int QuestionId { get; private set; } 
>>>>>>> dc12d0ebeafb51765c6f2e3273a9da850a8e6acd
        public string QuestionText { get; set; }
        public GAME? Game { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int GameId { get; set; }
        public List<ANSWER> answers { get; set; } = new List<ANSWER>();// Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
<<<<<<< HEAD
        public QUESTION(string questionText, int gameId)
        {
            QuestionText = questionText;
            GameId = gameId;
        }

        public bool SetQuestionId(int id)
        {
            QuestionId = id;
            return true; // Assuming setting the ID is always successful
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
            sqlDAL.DeleteQuestion(this.QuestionId);
=======
        public QUESTION(int questionid, string questiontext)
        {
            QuestionId = questionid;
            QuestionText = questiontext;
>>>>>>> dc12d0ebeafb51765c6f2e3273a9da850a8e6acd
            return sqlDAL.DeleteQuestion(this.QuestionId);
        }
    }
}
