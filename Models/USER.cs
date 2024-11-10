  using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class USER
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int UserId { get; private set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Role { get; set; }
        public int? Experience { get; set; }
        public ROUTE? Route { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int RouteId { get; set; }
        public List<OBSERVATION> Observations { get; set; } = new List<OBSERVATION>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<ROLE> Roles { get; set; } = new List<ROLE>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
        public USER(int userId, string name, string? description, int role, int? experience, int routeId)
        {
            UserId = userId;
            Name = name;
            Description = description;
            Role = role;
            Experience = experience;
            RouteId = routeId;
        }
        public USER(string name, string? description, int role, int routeId)
        {
            Name = name;
            Description = description;
            Role = role;
            RouteId = routeId;
        }

        public void SetUserId(int id)
        {
            UserId = id;
        }       // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddUser()
        {
            return sqlDAL.AddUser(this);
        }
        public bool UpdateUser(USER user)
        {
            return sqlDAL.UpdateUser(user);
        }
        public List<USER> GetUsers()
        {
            return sqlDAL.GetUsers();
        }
        public bool DeleteUser()
        {
            return sqlDAL.DeleteUser(this.UserId);
        }
    }
}
    

