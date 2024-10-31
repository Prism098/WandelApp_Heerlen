using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class USRQUEST
    {
        private int UsrQuestId { get; set; }
        private string AnswerText { get; set; }
        private USER User { get; set;}
        private int UserId { get; set; }
        private QUESTION Question { get; set; }
        private int QuestionId { get; set; }

        public USRQUEST()
        {
            
        }

    }
}
