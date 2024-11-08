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
        public QUESTION? Question { get; set; }
        public int QuestionId { get; set; }

        public ANSWER(int answerid ,string answerText, int questionID)
        {
            AnswerId = answerid;
            AnswerText = answerText;
            QuestionId = questionID;
        }

    }
}
