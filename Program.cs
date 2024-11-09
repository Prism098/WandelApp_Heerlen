using ExotischNederlandKaasus.DAL;
using ExotischNederlandKaasus.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SQLDAL sqlDAL = SQLDAL.Instance;
        bool continueProgram = true;

        do
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. Delete Game");
            Console.WriteLine("3. Read Games");
            Console.WriteLine("4. Update Game");
            Console.WriteLine("5. Exit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                continueProgram = HandleUserChoice(choice, sqlDAL);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (continueProgram);
    }

    static bool HandleUserChoice(int choice, SQLDAL sqlDAL)
    {
        switch (choice)
        {
            case 1:
                AddGame(sqlDAL);
                return true;
            case 2:
                DeleteGame(sqlDAL);
                return true;
            case 3:
                ReadGames(sqlDAL);
                return true;
            case 4:
                UpdateGame(sqlDAL);
                return true;
            case 5:
                return false;
            default:
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                return true;
        }
    }

    static void AddGame(SQLDAL sqlDAL)
    {
        Console.WriteLine("Enter the name of the new game:");
        string name = Console.ReadLine();
        DateTime startTime = DateTime.Now;
        Console.WriteLine("Enter the route ID of the new game:");
        int routeId = int.Parse(Console.ReadLine());

        GAME newGame = new GAME(name, startTime, routeId);
        sqlDAL.AddGame(newGame);
        Console.WriteLine("Game added successfully.");
    }

    static void DeleteGame(SQLDAL sqlDAL)
    {
        ReadGames(sqlDAL);
        Console.WriteLine("Enter the GameId of the game you want to delete:");
        if (int.TryParse(Console.ReadLine(), out int gameIdToDelete))
        {
            sqlDAL.DeleteGame(gameIdToDelete);
            Console.WriteLine("Game deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid GameId entered.");
        }
    }

    static void ReadGames(SQLDAL sqlDAL)
    {
        List<GAME> games = sqlDAL.GetGames();
        Console.WriteLine("All games:");
        foreach (GAME game in games)
        {
            Console.WriteLine($"GameId: {game.GameId}, Name: {game.Name}, StartTime: {game.StartTime}, RouteId: {game.RouteId}, Points: {game.Points}");
        }
    }

    static void UpdateGame(SQLDAL sqlDAL)
    {
        ReadGames(sqlDAL);
        Console.WriteLine("Enter the GameId of the game you want to update:");
        if (int.TryParse(Console.ReadLine(), out int gameIdToUpdate))
        {
            GAME gameToUpdate = sqlDAL.GetGames().Find(g => g.GameId == gameIdToUpdate);
            if (gameToUpdate != null)
            {
                Console.WriteLine("Enter the new name of the game:");
                gameToUpdate.Name = Console.ReadLine();
                Console.WriteLine("Enter the new start time of the game (yyyy-MM-dd HH:mm:ss):");
                gameToUpdate.StartTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new route ID of the game:");
                gameToUpdate.RouteId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new points of the game:");
                gameToUpdate.Points = int.Parse(Console.ReadLine());

                sqlDAL.UpdateGame(gameToUpdate);
                Console.WriteLine("Game updated successfully.");
            }
            else
            {
                Console.WriteLine("Game not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid GameId entered.");
        }
    }
}