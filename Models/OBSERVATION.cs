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
        private int Id { get; set; }
        private DateTime DateObserved { get; set; }
        private string Observer { get; set; }
        private string Description { get; set; }
        private Blob Picture { get; set; }
        private AREA Area { get; set; }
        private int AreaId { get; set; }
        private USER User { get; set; }
        private int UserId { get; set; }
        private SPECIE Specie { get; set; }
        private int SpecieId { get; set; }

        public OBSERVATION()
        {
            
        }
    }
}
