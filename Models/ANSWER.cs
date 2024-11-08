using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExotischNederlandKaasus.Models
{
    internal class ANSWER
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int AnswerId { get; private set; }
        public string AnswerText { get; set; }
        public QUESTION? Question { get; set; }
        public int QuestionId { get; set; }

        public ANSWER(string answerText, int questionId)
        {
            AnswerText = answerText;
            QuestionId = questionId;
        }

        public void SetAnswerId(int id)
        {
            AnswerId = id;
        }
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
