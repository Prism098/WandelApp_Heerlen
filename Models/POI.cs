using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class POI
    {
        public int POIId { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public ROUTEPOINT RoutePoint { get; set; }
        public int RoutePointId { get; set; }

        public POI()
        {
            
        }
    }
}
