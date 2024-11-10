using ExotischNederlandKaasus.DAL;

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
        public List<ROUTE> Routes { get; set; } = new List<ROUTE>();  // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<OBSERVATION> Oberservations { get; set; } = new List<OBSERVATION>();  // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
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
        }         // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )
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
