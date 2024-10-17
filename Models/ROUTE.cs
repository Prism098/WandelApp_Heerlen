using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTE
    {
        private int Id { get; set; }
        private int Length { get; set; }
        private decimal Longitutde { get; set; }
        private decimal Latitude { get; set; }
        private string Type { get; set; }
        private AREA Area { get; set; }
        private int AreaId { get; set; }
        private List<USER> Users { get; set; }
        private List<GAME> Games { get; set; }
        //If ROUTEROUTEPOINTS is implemented :
        //private List<ROUTEROUTEPOINT> RouteRoutePoints { get; set; }

        public ROUTE()
        {
            
        }
    }
}
