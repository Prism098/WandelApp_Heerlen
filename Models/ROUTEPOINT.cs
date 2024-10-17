using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTEPOINT
    {
        private int Id { get; set; }
        private decimal Longitutde { get; set; }
        private decimal Latitude { get; set; }
        private int SequenceNumber { get; set; }
        // If the RoueRoutepoint table will be added :
        // private List<ROUTEROUTEPOINT> RouteRoutePoints { get; set; }
        private List<POI> Pois { get; set; }

        public ROUTEPOINT()
        {
            
        }
    }
}
