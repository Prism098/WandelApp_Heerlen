using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class QUESTION
    {
        private int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public GAME Game { get; set; }
        public int GameId { get; set; }
        public List<ANSWER> answers { get; set; } = new List<ANSWER>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public QUESTION()
        {
            
        }
    }
}
