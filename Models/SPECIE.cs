using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class SPECIE
    {
        private int SpecieId { get; set; }
        private string Name { get; set; }
        private string? InvasivenessLevel { get; set; }
        private List<OBSERVATION> Observations { get; set; }

        public SPECIE()
        {
            
        }
    }
}
