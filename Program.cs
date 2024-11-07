using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // een 15 x 15 matrix die de afstanden tussen de locaties voorstelt , 15 omdat er 15 locaties zijn.
        int[,] graph = new int[15, 15]
        {
            { 0, 10, 10, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 10, 0, 3, 0, 0, 0, 0, 14, 0, 0, 0, 18, 0, 0, 0 },
            { 10, 3, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 12, 0, 3, 0, 10, 9, 10, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 10, 0, 4, 0, 0, 13, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 9, 4, 0, 3, 0, 13, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 10, 0, 3, 0, 2, 14, 0, 0, 0, 0, 0, 0 },
            { 0, 14, 0, 0, 0, 0, 2, 0, 0, 0, 1, 6, 0, 0, 0 },
            { 0, 0, 0, 0, 13, 13, 14, 0, 0, 11, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 6, 0, 6, 6, 6 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 6, 0, 6, 4, 0, 0 },
            { 0, 18, 0, 0, 0, 0, 0, 6, 0, 0, 6, 0, 5, 9, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 4, 5, 0, 3, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 9, 3, 0, 8 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 8, 0 }
        };

        // Defineer elke node met de gegeven naam van de locatie
        Dictionary<int, string> nodeNames = new Dictionary<int, string>
        {
            { 0, "Het Weerterbos" },
            { 1, "Moeselpeel" },
            { 2, "Roeventerpeel" },
            { 3, "Natuurreservaat Wellensteijn" },
            { 4, "Het Spaanse Bos" },
            { 5, "Landgoed Beijlshof" },
            { 6, "Landgoed Exaten" },
            { 7, "De Tuspeel" },
            { 8, "Beesels Broek" },
            { 9, "Melickerheide" },
            { 10, "Isabelle Griend en Oolder Griend" },
            { 11, "Molengreend" },
            { 12, "Linnerheide" },
            { 13, "Het Munnichsbos" },
            { 14, "Nationaal park de Meinweg" }
        };

        // geef de locaties weer voor de gebruiker
        Console.WriteLine("Available locations:");
        foreach (var location in nodeNames)
        {
            Console.WriteLine($"{location.Key + 1}. {location.Value}");
        }

        // vraag de gebruiker voor een start en eind locatie in integer formaat
        Console.Write("\nEnter the starting location number: ");
        int startNode = GetNodeInput(nodeNames.Count) - 1;

        Console.Write("Enter the target location number: ");
        int targetNode = GetNodeInput(nodeNames.Count) - 1;

        // bereken en geef het kortste pad tussen de opgegeven locaties weer
        List<int> path = Dijkstra.FindShortestPath(graph, startNode, targetNode);

        if (path.Count > 0)
        {
            // Bereken de totale afstand van het pad
            int totalDistance = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                totalDistance += graph[path[i], path[i + 1]];
            }

            // Geef het kortste pad en de totale afstand weer
            Console.WriteLine($"\nShortest path from {nodeNames[startNode]} to {nodeNames[targetNode]}:");
            foreach (int node in path)
            {
                Console.Write(nodeNames[node]);
                if (node != targetNode) Console.Write(" -> ");
            }
            Console.WriteLine();
            Console.WriteLine($"Total distance: {totalDistance} km");
        }
        else
        {
            Console.WriteLine($"\nNo path found from {nodeNames[startNode]} to {nodeNames[targetNode]}.");
        }
    }

    private static int GetNodeInput(int numLocations)
    {
        int node;
        while (true) // Blijft herhalen totdat de gebruiker een geldige invoer geeft
        {
            if (int.TryParse(Console.ReadLine(), out node) && node >= 1 && node <= numLocations)
            {
                return node;
            }
            Console.WriteLine("Invalid input. Please enter a valid location number:");
        }
    }
}
