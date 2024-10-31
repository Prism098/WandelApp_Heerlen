using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class USER
    {
        private int UserId { get; set; }
        private string Name { get; set; }
        private string? Description { get; set; }
        private int Role { get; set; }
        private int? Experience { get; set; }
        private ROUTE Route { get; set; }
        private int RouteId { get; set; }
        private List<OBSERVATION> Observations { get; set; } = new List<OBSERVATION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
        private List<ROLE> Roles { get; set; } = new List<ROLE>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public USER()
        {
               
        }
    }
}
