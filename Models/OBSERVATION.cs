
using ExotischNederlandKaasus.DAL;
using System;
using System.Reflection.Metadata;
using ExotischNederlandKaasus.Models;


namespace ExotischNederlandKaasus.Models
{
    internal class OBSERVATION
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int ObservationId { get; private set; }
        public DateTime DateObserved { get; set; } = DateTime.Now;
        public string Observer { get; set; }
        public string? Description { get; set; }
        public Blob? Picture { get; set; }
        public AREA Area { get; set; }
        public int AreaId { get; set; }
        public USER User { get; set; }
        public int UserId { get; set; }
        public SPECIE Specie { get; set; }
        public int SpecieId { get; set; }


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
        public OBSERVATION(int observationid, DateTime dateoberserved, string observer, Blob picture, AREA area, int areaid, int specieid)
        {
            ObservationId = observationid;
            DateObserved = dateoberserved;
            Observer = observer;
            Picture = picture;
            Area = area;
            AreaId = areaid;
            SpecieId = specieid;
        }

        public void SetObservationId(int id)
        {
            ObservationId = id;
        }
        // Interaction with the database methods.
        public void AddObservation()
        {
            sqlDAL.AddObservation(this);
        }
        public void UpdateObservation(OBSERVATION observation)
        {
            sqlDAL.UpdateObservation(observation);
        }
        public List<OBSERVATION> GetObservation()
        {
            return sqlDAL.GetObservations();
        }
        public void DeleteObservation()
        {
            sqlDAL.DeleteObservation(this.ObservationId);
        }
    }
}