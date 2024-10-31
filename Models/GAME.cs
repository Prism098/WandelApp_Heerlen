using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class GAME
    {
        private int GameId { get; set; }
        private string Name { get; set; }
        private DateTime StartTime { get; set; } = DateTime.Now;
        private DateTime? EndTime { get; set; }
        private int? Points { get; set; }
        private ROUTE? Route { get; set; }
        private int RouteId { get; set; }
        private List<QUESTION> questions { get; set; } = new List<QUESTION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!


        public GAME(string name)
        {
            Name = name;
        }
    }
}
