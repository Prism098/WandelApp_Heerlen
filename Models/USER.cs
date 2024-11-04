using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class USER
    {
        public int UserId { get; private set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Role { get; set; }
        public int? Experience { get; set; }
        public ROUTE Route { get; set; }
        public int RouteId { get; set; }
        public List<OBSERVATION> Observations { get; set; } = new List<OBSERVATION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        public List<ROLE> Roles { get; set; } = new List<ROLE>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public USER()
        {
               
        }
    }
}
