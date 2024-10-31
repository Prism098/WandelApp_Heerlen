using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROLE
    {
        private int RoleId { get; set; }
        private string Name { get; set; }
        private string? Description { get; set; }
        private List<USER> Users { get; set; } = new List<USER>();   // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public ROLE()
        {
            
        }
    }
}
