using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTE
    {
        public int RouteId { get; private set; }
        public int Length { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Type { get; set; }
        public AREA Area { get; set; }
        public int AreaId { get; set; }
        public List<USER> Users { get; set; } = new List<USER>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        public List<GAME> Games { get; set; } = new List<GAME>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        public List<ROUTEPOINT> RoutePoints { get; set; } = new List<ROUTEPOINT>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!  

        public ROUTE()
        {
            
        }
    }
}
