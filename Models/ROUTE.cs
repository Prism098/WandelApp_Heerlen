using ExotischNederlandKaasus.DAL;

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
        public AREA ?Area { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int AreaId { get; set; }
        public List<USER> Users { get; set; } = new List<USER>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<GAME> Games { get; set; } = new List<GAME>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<ROUTEPOINT> RoutePoints { get; set; } = new List<ROUTEPOINT>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
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
        }        // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddRoute()
        {
            return sqlDAL.AddRoute(this);
        }
        public bool UpdateRoute(ROUTE route)
        {
            return sqlDAL.UpdateRoute(route);
        }
        public List<ROUTE> GetRoutes()
        {
            return sqlDAL.GetRoutes();
        }
        public bool DeleteRoute()
        {
            return sqlDAL.DeleteRoute(this.RouteId);
        }
    }
}
