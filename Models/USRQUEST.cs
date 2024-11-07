using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class USRQUEST
    {
        public int UsrQuestId { get; private set; }
        public string AnswerText { get; set; }
        public USER User { get; set;}
        public int UserId { get; set; }
        public QUESTION Question { get; set; }
        public int QuestionId { get; set; }

        public USRQUEST()
        {
            
        }

    }
}
