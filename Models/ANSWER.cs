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
        public int AnswerId { get; private set; }
        public string AnswerText { get; set; }
        public QUESTION? Question { get; set; }  // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int QuestionId { get; set; }

        //Constructors that are being used to make database calls
        public ANSWER(string answerText, int questionId)
        {
            AnswerId = answerid;
            AnswerText = answerText;
            QuestionId = questionID;
        }

        public void SetAnswerId(int id)
        {
            AnswerId = id;
        } // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddAnswer()
        {
            return sqlDAL.AddAnswer(this);
        }
        public bool UpdateAnswer(ANSWER answer)
        {
            try
            {
                sqlDAL.UpdateAnswer(answer);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ANSWER> GetAnswers()
        {
            return sqlDAL.GetAnswers();
        }
        public bool DeleteAnswer()
        {
            try
            {
                sqlDAL.DeleteAnswer(this.AnswerId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
