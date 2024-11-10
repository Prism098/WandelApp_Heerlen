using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class ANSWER
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int AnswerId { get; private set; }
        public string AnswerText { get; set; }
        public QUESTION? Question { get; set; }  // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int QuestionId { get; set; }

        //Constructors that are being used to make database calls
        public ANSWER(string answerText, int questionId)
        {
            AnswerText = answerText;
            QuestionId = questionId;
        }

        public void SetAnswerId(int id)
        {
            AnswerId = id;
        }         // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )
        // Interaction with the database methods.
        public void AddAnswer()
        {
            sqlDAL.AddAnswer(this);
        }
        public void UpdateAnswer(ANSWER answer)
        {
            sqlDAL.UpdateAnswer(answer);
        }
        public List<ANSWER> GetAnswers()
        {
            return sqlDAL.GetAnswers();
        }
        public void DeleteAnswer()
        {
            sqlDAL.DeleteAnswer(this.AnswerId);
        }
    }
}
