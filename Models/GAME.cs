using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class GAME
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private DateTime StartTime { get; set; } = DateTime.Now;
        private DateTime EndTime { get; set; }
        private ROUTE Route { get; set; }
        private int RouteId { get; set; }
        private List<QUESTION> questions { get; set; }


        public GAME()
        {
            
        }
    }
}
