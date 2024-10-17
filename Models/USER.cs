using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class USER
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private int Role { get; set; }
        private int Experience { get; set; }
        // Indien koppeltabbel aangemaakt wordt : 
        // private List<USERROLES> UserRoles { get; set; }
        private int RouteId { get; set; }
        private List<OBSERVATION> Observations { get; set; }
        private ROUTE Route { get; set; }

        public USER()
        {
               
        }
    }
}
