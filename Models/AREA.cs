using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class AREA
    {
        public int AreaId { get; private set; }
        public string? Owner { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string? Type { get; set; }
        public List<ROUTE> Routes { get; set; } = new List<ROUTE>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        public List<OBSERVATION> Oberservations { get; set; } = new List<OBSERVATION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public AREA(string name, string region)
        {
            Name = name;
            Region = region;
        }
    }
}
