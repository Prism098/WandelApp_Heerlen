
using ExotischNederlandKaasus.DAL;
using System.Reflection.Metadata; // Is here for the Blob, but due to the app not being mobile it is not being used.


namespace ExotischNederlandKaasus.Models
{
    internal class OBSERVATION
    {
        private readonly SQLDAL sqlDAL = SQLDAL.Instance;
        public int ObservationId { get; private set; }
        public DateTime DateObserved { get; set; } = DateTime.Now;
        public string Observer { get; set; }
        public string? Description { get; set; }
        public Blob? Picture { get; set; }
        public AREA ?Area { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int AreaId { get; set; }
        public USER ?User { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int UserId { get; set; }
        public SPECIE ?Specie { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int SpecieId { get; set; }

        //Constructors that are being used to make database calls
        public OBSERVATION(int observationId, DateTime dateObserved, string observer, string description, int areaId, int userId, int specieId)
        {
            ObservationId = observationId;
            DateObserved = dateObserved;
            Observer = observer;
            Description = description;
            AreaId = areaId;
            UserId = userId;
            SpecieId = specieId;
        }


        public bool SetObservationId(int id)
        {
            ObservationId = id;
            return true;
        } // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddObservation()
        {
            return sqlDAL.AddObservation(this);
        }
        public bool UpdateObservation(OBSERVATION observation)
        {
            return sqlDAL.UpdateObservation(observation);
        }
        public List<OBSERVATION> GetObservation()
        {
            return sqlDAL.GetObservations();
        }
        public bool DeleteObservation()
        {
            return sqlDAL.DeleteObservation(this.ObservationId);
        }
    }
}