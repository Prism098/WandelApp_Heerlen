using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class POI
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int POIId { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; } = string.Empty; // Initialize with a default value, making sure it is never null
        public ROUTEPOINT? RoutePoint { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int RoutePointId { get; set; }


        //Constructors that are being used to make database calls
        public POI()
        {
            
        }
        public POI(decimal longitude, decimal latitude, string description, string type, int routePointId)
        {
            Longitude = longitude;
            Latitude = latitude;
            Description = description;
            Type = type;
            RoutePointId = routePointId;
        }

        public POI(int poiId, decimal longitude, decimal latitude, string description, string type, int routePointId)
        {
            POIId = poiId;
            Longitude = longitude;
            Latitude = latitude;
            Description = description;
            Type = type;
            RoutePointId = routePointId;
        }

        public bool SetPOIId(int id)
        {
            POIId = id;
            return true; // Assuming setting the ID is always successful
        }// Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddPOI()
        {
            return sqlDAL.AddPOI(this);
        }

        public bool UpdatePOI(POI poi)
        {
            return sqlDAL.UpdatePOI(poi);
        }

        public List<POI> GetPOI()
        {
            return sqlDAL.GetPOI();
        }

        public bool DeletePOI()
        {
            return sqlDAL.DeletePOI(this.POIId);
        }
    }
}
