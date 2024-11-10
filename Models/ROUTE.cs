using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTE
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int RouteId { get; private set; }
        public int Length { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Type { get; set; }
        public AREA Area { get; set; }
        public int AreaId { get; set; }
        public List<USER> Users { get; set; } = new List<USER>();
        public List<GAME> Games { get; set; } = new List<GAME>();
        public List<ROUTEPOINT> RoutePoints { get; set; } = new List<ROUTEPOINT>();

        public ROUTE()
        {
        }
        public ROUTE(int length, decimal longitude, decimal latitude, string type, int areaId)
        {
            Length = length;
            Longitude = longitude;
            Latitude = latitude;
            Type = type;
            AreaId = areaId;
        }
        public ROUTE(int routeId, int length, decimal longitude, decimal latitude, string type, int areaId)
        {
            RouteId = routeId;
            Length = length;
            Longitude = longitude;
            Latitude = latitude;
            Type = type;
            AreaId = areaId;
        }

        public void SetRouteId(int id)
        {
            RouteId = id;
        }
        // Interaction with the database methods.
        public void AddRoute()
        {
            sqlDAL.AddRoute(this);
        }
        public void UpdateRoute(ROUTE route)
        {
            sqlDAL.UpdateRoute(route);
        }
        public List<ROUTE> GetRoutes()
        {
            return sqlDAL.GetRoutes();
        }
        public void DeleteRoute()
        {
            sqlDAL.DeleteRoute(this.RouteId);
        }
    }
}
