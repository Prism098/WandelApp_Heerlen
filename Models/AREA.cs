using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class AREA
    {
        private int Id { get; set; }
        private string Owner { get; set; }
        private string Name { get; set; }
        private string Region { get; set; }
        private string Type { get; set; }
        private List<ROUTE> Routes { get; set; }
        private List<OBSERVATION> Oberservations { get; set; }

        public AREA()
        {
            
        }
    }
}
