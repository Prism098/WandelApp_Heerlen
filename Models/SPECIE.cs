using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class SPECIE
    {
        public int SpecieId { get; private set; }
        public string Name { get; set; }
        public string? InvasivenessLevel { get; set; }
        public List<OBSERVATION> Observations { get; set; }

        public SPECIE()
        {
            
        }
        // Method to set the SpecieId in the Specie Class
        public void SetSpecieId(int id)
        {
            SpecieId = id;
        }

    }
}
