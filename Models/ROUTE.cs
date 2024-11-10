using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class ROUTE
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int RouteId { get; private set; }
        public int Length { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Type { get; set; }
        public AREA ?Area { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public int AreaId { get; set; }
        public List<USER> Users { get; set; } = new List<USER>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<GAME> Games { get; set; } = new List<GAME>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
        public List<ROUTEPOINT> RoutePoints { get; set; } = new List<ROUTEPOINT>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
        public ROUTE(int length, decimal longitude, decimal latitude, string type, int areaId)
        {
            Length = length;
            Longitude = longitude;
            Latitude = latitude;
            Type = type;
            AreaId = areaId;
        }
        public ROUTE(int routeId, int length, decimal longitude, decimal latitude, string type, int areaId)
        {
            RouteId = routeId;
            Length = length;
            Longitude = longitude;
            Latitude = latitude;
            Type = type;
            AreaId = areaId;
        }

        public void SetRouteId(int id)
        {
            RouteId = id;
        }        // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public bool AddRoute()
        {
            return sqlDAL.AddRoute(this);
        }
        public bool UpdateRoute(ROUTE route)
        {
            return sqlDAL.UpdateRoute(route);
        }
        public List<ROUTE> GetRoutes()
        {
            return sqlDAL.GetRoutes();
        }
        public bool DeleteRoute()
        {
            return sqlDAL.DeleteRoute(this.RouteId);
        }

        public static List<int> FindShortestPath(int[,] graph, int startNode, int targetNode)
        {
            int numNodes = graph.GetLength(0);
            int[] distances = new int[numNodes];   // Array om kortste afstand bij de houden
            bool[] visited = new bool[numNodes];   // Track bezochte nodes
            int[] previousNodes = new int[numNodes]; // Track vorig node in het korste pad

            // Initializeer afstanden op "oneindig" en zet alle nodes als onbezocht
            for (int i = 0; i < numNodes; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
                previousNodes[i] = -1;
            }
            distances[startNode] = 0; // Zet afstand naar start node als 0

            // Itereer door de nodes om het korste pad te vinden
            for (int count = 0; count < numNodes - 1; count++)
            {
                int m = MinDistanceNode(distances, visited, numNodes); // vind node met de korste afstand
                if (m == -1 || distances[m] == int.MaxValue) break;    // stop als er geen bereikbare onbezochte nodes meer zijn
                visited[m] = true; //Markeeer de node als bezocht

                // Update afstanden naar aangrenzende nodes
                for (int j = 0; j < numNodes; j++)
                {
                    if (!visited[j] && graph[m, j] != 0 && distances[m] != int.MaxValue &&
                        distances[m] + graph[m, j] < distances[j])
                    {
                        distances[j] = distances[m] + graph[m, j]; // update afstand naar node v
                        previousNodes[j] = m;                      // houd vorige node Bij
                    }
                }
            }

            // Geef het kortste pad als een lijst van nodes terug
            return BuildPath(previousNodes, startNode, targetNode);
        }

        //Zoekt de node met de korste afstand die nog niet bezocht is
        private static int MinDistanceNode(int[] distances, bool[] visited, int numNodes)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < numNodes; i++)
            {
                if (!visited[i] && distances[i] < min)
                {
                    min = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        // Genereerd het kortste pad door vorige nodes te traceren van target naar start

        private static List<int> BuildPath(int[] previousNodes, int startNode, int targetNode)
        {
            List<int> path = new List<int>();

            //Bijhouden van target naar start route
            for (int currentNode = targetNode; currentNode != -1; currentNode = previousNodes[currentNode])
            {
                path.Insert(0, currentNode); // Invoegen aan het begin om het pad om te keren
            }

            // geef een leeg pad terug als de target niet bereikbaar is vanaf de start node
            if (path[0] != startNode)
                return new List<int>();

            return path;
        }
    }
}
