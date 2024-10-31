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
        private int AnswerId { get; set; }
        private string AnswerText { get; set; }
        private QUESTION? Question { get; set; }
        private int QuestionId { get; set; }

        public ANSWER(string answerText)
        {
            AnswerText = answerText;
        }

    }
}
