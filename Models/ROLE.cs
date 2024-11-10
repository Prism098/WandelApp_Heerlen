using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class ROLE
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int RoleId { get; private set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<USER> Users { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
        public ROLE(string name, string description)
        {
            Description = description;
            Name = name;
            Users = new List<USER>();
        }
        public void SetRoleId(int id)        // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )
        {
            RoleId = id;
        }

        // Interaction with the database methods.
        public bool AddRole()
        {
            return sqlDAL.AddRole(this);
        }
        public bool UpdateRole(ROLE role)
        {
            return sqlDAL.UpdateRole(role);
        }
        public List<ROLE> GetRoles()
        {
            return sqlDAL.GetRoles();
        }
        public bool DeleteRole()
        {
            return sqlDAL.DeleteRole(this.RoleId);
        }
    }
}