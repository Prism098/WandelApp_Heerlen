using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTEPOINT
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int RoutePointId { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int SequenceNumber { get; set; }
        public List<POI> Pois { get; set; }

        public ROUTEPOINT(decimal longitude, decimal latitude, int sequenceNumber)
        {
            Longitude = longitude;
            Latitude = latitude;
            SequenceNumber = sequenceNumber;
            Pois = new List<POI>();
        }

        public ROUTEPOINT(int routepointId, decimal longitude, decimal latitude, int sequenceNumber)
        {
            RoutePointId = routepointId;
            Longitude = longitude;
            Latitude = latitude;
            SequenceNumber = sequenceNumber;
        }

        public void SetRoutePointId(int id)
        {
            RoutePointId = id;
        }

        // Interaction with the database methods.
        public void AddRoutePoint()
        {
            sqlDAL.AddRoutePoint(this);
        }

        public void UpdateRoutePoint(ROUTEPOINT routePoint)
        {
            sqlDAL.UpdateRoutePoint(routePoint);
        }

        public List<ROUTEPOINT> GetRoutePoints()
        {
            return sqlDAL.GetRoutePoints();
        }

        public void DeleteRoutePoint()
        {
            sqlDAL.DeleteRoutePoint(this.RoutePointId);
        }
    }
}
