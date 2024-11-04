using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTEPOINT
    {
        public int RoutePointId { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int SequenceNumber { get; set; }
        // If the RoueRoutepoint table will be added :
        // private List<ROUTEROUTEPOINT> RouteRoutePoints { get; set; }
        public List<POI> Pois { get; set; } = new List<POI>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public ROUTEPOINT()
        {
            Longitude = 0.0m;
            Latitude = 0.0m;
            SequenceNumber = 0;
        }
    }
}
