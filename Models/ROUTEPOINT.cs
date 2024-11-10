using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTEPOINT
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int RoutePointId { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int SequenceNumber { get; set; }
        public List<POI> Pois { get; set; } = new List<POI>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
        public ROUTEPOINT( decimal longitude, decimal latitude, int sequenceNumber)
        {
            Longitude = longitude;
            Latitude = latitude;
            SequenceNumber = sequenceNumber;
 
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
        }         // Method for auto incrementing the ID ( Must be auto inc. due to database restrictions )

        // Interaction with the database methods.
        public bool AddRoutePoint()
        {
            return sqlDAL.AddRoutePoint(this);
        }
        public bool UpdateRoutePoint(ROUTEPOINT routePoint)
        {
            return sqlDAL.UpdateRoutePoint(routePoint);
        }
        public List<ROUTEPOINT> GetRoutePoints()
        {
            return sqlDAL.GetRoutePoints();
        }
        public bool DeleteRoutePoint()
        {
            return sqlDAL.DeleteRoutePoint(this.RoutePointId);
        }
    }
}
