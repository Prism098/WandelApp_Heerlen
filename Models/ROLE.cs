using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class ROLE
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int RoleId { get; private set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<USER> Users { get; set; }

        public ROLE(string name, string description)
        {
            Description = description;
            Name = name;
            Users = new List<USER>();
        }
        public void SetRoleId(int id)
        {
            RoleId = id;
        }

        // Method to set the SpecieId in the Specie Class
        public List<ROLE> AddRole()
        {
            return sqlDAL.AddRole(this);
        }

        public List<ROLE> GetRoles()
        {

        }

        public void DeleteRole()
        {

        }
    }
}
