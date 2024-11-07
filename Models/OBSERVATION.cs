
using System.Reflection.Metadata;


namespace ExotischNederlandKaasus.Models
{
    internal class OBSERVATION
    {
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

        public OBSERVATION(int observationid, DateTime dateoberserved, string observer, Blob picture, AREA area, int areaid, USER user, SPECIE specie, int specieid)
        {
            ObservationId = observationid;
            DateObserved = dateoberserved;
            Observer = observer;
            Picture = picture;
            Area = area;
            AreaId = areaid;
            User = user;
            Specie = specie;
            SpecieId = specieid;
        }
    }
}