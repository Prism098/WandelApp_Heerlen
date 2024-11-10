    using System;
    using System.Collections.Generic;
    using ExotischNederlandKaasus.Models;
    using global::ExotischNederlandKaasus.DAL;

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
            public ROUTE Route { get; set; }
            public int RouteId { get; set; }
            public List<OBSERVATION> Observations { get; set; } = new List<OBSERVATION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!
            public List<ROLE> Roles { get; set; } = new List<ROLE>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

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
            public USER()
            {
            }
            public void SetUserId(int id)
            {
                UserId = id;
            }

            // Interaction with the database methods.
            public void AddUser()
            {
                sqlDAL.AddUser(this);
            }

            public void UpdateUser(USER user)
            {
                sqlDAL.UpdateUser(user);
            }

            public List<USER> GetUsers()
            {
                return sqlDAL.GetUsers();
            }

            public void DeleteUser()
            {
                sqlDAL.DeleteUser(this.UserId);
            }
        }
    }

