using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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

        public OBSERVATION()
        {
            
        }

        //public List<OBSERVATION> AddObservation()
        //{
        //    return SQLDAL.AddObservation(this);
        //}
    }
}
