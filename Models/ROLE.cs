using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROLE
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        // Indien koppel tabel : 
        // private List<USERROLE> UserRoles { get; set; }

        public ROLE()
        {
            
        }
    }
}
