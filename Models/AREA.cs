using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class AREA
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int AreaId { get; private set; }
        public string? Owner { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string? Type { get; set; }
        public List<ROUTE> Routes { get; set; } = new List<ROUTE>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        public List<OBSERVATION> Oberservations { get; set; } = new List<OBSERVATION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public AREA(string owner, string name, string region, string type)
        {
            Owner = owner;
            Name = name;
            Region = region;
            Type = type;
        }

        public void SetAreaId(int id)
        {
            AreaId = id;
        }
        // Interaction with the database methods.
        public void AddArea()
        {
            sqlDAL.AddArea(this);
        }
        public void UpdateArea(AREA area)
        {
            sqlDAL.UpdateArea(area);
        }
        public List<AREA> GetAreas()
        {
            return sqlDAL.GetAreas();
        }
        public void DeleteAreas()
        {
            sqlDAL.DeleteArea(this.AreaId);
        }
    }
}
