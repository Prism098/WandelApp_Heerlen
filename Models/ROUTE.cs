using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTE
    {
        private int RouteId { get; set; }
        private int Length { get; set; }
        private decimal Longitude { get; set; }
        private decimal Latitude { get; set; }
        private string Type { get; set; }
        private AREA Area { get; set; }
        private int AreaId { get; set; }
        private List<USER> Users { get; set; } = new List<USER>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        private List<GAME> Games { get; set; } = new List<GAME>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        private List<ROUTEPOINT> RoutePoints { get; set; } = new List<ROUTEPOINT>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!  

        public ROUTE()
        {
            
        }
    }
}
