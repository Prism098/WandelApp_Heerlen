using System;
using System.Collections.Generic;

public class Dijkstra
{
    /// <summary>
    /// Finds the shortest path between two nodes using Dijkstra's algorithm.
    /// </summary>
    /// <param name="graph">Adjacency matrix representing distances between nodes</param>
    /// <param name="startNode">Index of the starting node</param>
    /// <param name="targetNode">Index of the target node</param>
    /// <returns>List of nodes representing the shortest path from startNode to targetNode</returns>
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
            int u = MinDistanceNode(distances, visited, numNodes); // vind node met de korste afstand
            if (u == -1 || distances[u] == int.MaxValue) break;    // stop als er geen bereikbare onbezochte nodes meer zijn
            visited[u] = true; //Markeeer de node als bezocht

            // Update afstanden naar aangrenzende nodes
            for (int v = 0; v < numNodes; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue &&
                    distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v]; // update afstand naar node v
                    previousNodes[v] = u;                      // houd vorige node Bij
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
