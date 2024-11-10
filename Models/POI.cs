using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class POI
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int POIId { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public ROUTEPOINT RoutePoint { get; set; }
        public int RoutePointId { get; set; }
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

        public void SetPOIId(int id)
        {
            POIId = id;
        }
        // Interaction with the database methods.
        public void AddPOI()
        {
            sqlDAL.AddPOI(this);
        }
        public void UpdatePOI(POI poi)
        {
            sqlDAL.UpdatePOI(poi);
        }
        public List<POI> GetPOI()
        {
            return sqlDAL.GetPOI();
        }
        public void DeletePOI()
        {
            sqlDAL.DeletePOI(this.POIId);
        }
    }
}
