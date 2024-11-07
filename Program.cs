using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Menu System
        bool exit = false;
        while (!exit)
        {
            Console.Clear(); // Clear the console screen
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Calculate Route");
            Console.WriteLine("2. Exit");

            // Ask for the user's choice
            Console.Write("\nEnter your choice: ");
            int choice = GetMenuChoice();

            // Perform action based on the user's choice
            switch (choice)
            {
                case 1:
                    // Call the Calculate Route function
                    CalculateRoute();
                    break;

                case 2:
                    // Exit the program
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // Method to calculate the route between two nodes
    private static void CalculateRoute()
    {
        // een 15 x 15 matrix die de aftanden tussen de locaties voorstelt
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

        // Geef de locaties weer voor de gebruiker
        Console.WriteLine("Available locations:");
        foreach (var location in nodeNames)
        {
            Console.WriteLine($"{location.Key + 1}. {location.Value}");
        }

        // Vraag gebruiker voor een start en eind locatie in integer formaat
        Console.Write("\nEnter the starting location number: ");
        int startNode = GetNodeInput(nodeNames.Count) - 1;

        Console.Write("Enter the target location number: ");
        int targetNode = GetNodeInput(nodeNames.Count) - 1;

        // Bereken en geef het kortste pad tussen de opgegeven locaties weer
        List<int> path = Dijkstra.FindShortestPath(graph, startNode, targetNode);

        if (path.Count > 0)
        {
            Console.WriteLine($"\nShortest path from {nodeNames[startNode]} to {nodeNames[targetNode]}:");
            int totalDistance = 0; // Variable to keep track of total distance
            for (int i = 0; i < path.Count - 1; i++)
            {
                int currentNode = path[i];
                int nextNode = path[i + 1];
                totalDistance += graph[currentNode, nextNode]; // Add the distance between nodes

                Console.Write(nodeNames[currentNode]);
                if (i < path.Count - 2)
                    Console.Write(" -> ");
            }
            Console.WriteLine($"\nTotal distance: {totalDistance} km");
        }
        else
        {
            Console.WriteLine($"\nNo path found from {nodeNames[startNode]} to {nodeNames[targetNode]}.");
        }

        // Wait for user input before returning to the menu
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    // Method to get valid menu choice
    private static int GetMenuChoice()
    {
        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
            {
                return choice;
            }
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }

    // Method to get valid node input
    private static int GetNodeInput(int numLocations)
    {
        int node;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out node) && node >= 1 && node <= numLocations)
            {
                return node;
            }
            Console.WriteLine("Invalid input. Please enter a valid location number:");
        }
    }
}
