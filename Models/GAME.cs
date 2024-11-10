using ExotischNederlandKaasus.DAL;

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
        public List<QUESTION> questions { get; set; } = new List<QUESTION>();  // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
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

        public void SetGameId(int id)
        {
            GameId = id;
        }         // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )
 
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
