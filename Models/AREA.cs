using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class AREA
    {
        private int AreaId { get; set; }
        private string? Owner { get; set; }
        private string Name { get; set; }
        private string Region { get; set; }
        private string? Type { get; set; }
        private List<ROUTE> Routes { get; set; } = new List<ROUTE>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        private List<OBSERVATION> Oberservations { get; set; } = new List<OBSERVATION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public AREA(string name, string region)
        {
            Name = name;
            Region = region;
        }
    }
}
