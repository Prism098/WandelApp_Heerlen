using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class QUESTION
    {
        private int Id { get; set; }
        private string QuestionText { get; set; }
        private GAME Game { get; set; }
        private int GameId { get; set; }
        private List<ANSWER> answers { get; set; }

        public QUESTION()
        {
            
        }
    }
}
