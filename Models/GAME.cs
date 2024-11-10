using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class GAME
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int GameId { get; private set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public int? Points { get; set; }
        public ROUTE? Route { get; set; }
        public int RouteId { get; set; }
        public List<QUESTION> questions { get; set; } = new List<QUESTION>(); // Initializing the List of users in the property declaration to make sure it's never null! This way i do not have to check for null before accessing the list!

        public GAME(int gameId, string name, DateTime startTime, int routeId, int? points)
        {
            GameId = gameId;
            Name = name;
            StartTime = startTime;
            RouteId = routeId;
            Points = points;
        }
        public GAME(string name, DateTime startTime, int routeId)
        {
            Name = name;
            StartTime = startTime;
            RouteId = routeId;
        }

        public GAME()
        {
            
        }

        public GAME(string name, DateTime startTime, int routeId, int point)
        {
            Name = name;
            StartTime = startTime;
            RouteId = routeId;
            Points = point;
        }

        public void SetGameId(int id)
        {
            GameId = id;
        }
        // Interaction with the database methods.
        public void AddGame()
        {
            sqlDAL.AddGame(this);
        }
        public void UpdateGame(GAME game)
        {
            sqlDAL.UpdateGame(game);
        }
        public List<GAME> GetGames()
        {
            return sqlDAL.GetGames();
        }
        public void DeleteGame()
        {
            sqlDAL.DeleteGame(this.GameId);
        }

    }
}
