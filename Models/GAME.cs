using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class GAME
    {
        public int GameId { get; private set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public int? Points { get; set; }
        public ROUTE? Route { get; set; }
        public int RouteId { get; set; }
        public List<QUESTION> questions { get; set; } = new List<QUESTION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!


        public GAME(string name)
        {
            Name = name;
        }
    }
}
