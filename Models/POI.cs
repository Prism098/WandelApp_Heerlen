using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class POI
    {
        private int Id { get; set; }
        private decimal Longitude { get; set; }
        private decimal Latitude { get; set; }
        private string Description { get; set; }
        private string Type { get; set; }
        private ROUTEPOINT RoutePoint { get; set; }
        private int RoutePointId { get; set; }

        public POI()
        {
            
        }
    }
}
