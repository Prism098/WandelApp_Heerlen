using ExotischNederlandKaasus.DAL;
using ExotischNederlandKaasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Database_test_script
{
    internal class Test_script_AREA
    {
        //static void Main(string[] args)
        //{
        //    SQLDAL sqlDAL = SQLDAL.Instance;
        //    bool continueProgram = true;

        //    do
        //    {
        //        Console.WriteLine("What do you want to do?");
        //        Console.WriteLine("1. Add Area");
        //        Console.WriteLine("2. Delete Area");
        //        Console.WriteLine("3. Read Areas");
        //        Console.WriteLine("4. Update Area");
        //        Console.WriteLine("5. Exit");

        //        if (int.TryParse(Console.ReadLine(), out int choice))
        //        {
        //            continueProgram = HandleUserChoice(choice, sqlDAL);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid input. Please enter a number.");
        //        }
        //    } while (continueProgram);
        //}

        //static bool HandleUserChoice(int choice, SQLDAL sqlDAL)
        //{
        //    switch (choice)
        //    {
        //        case 1:
        //            AddArea(sqlDAL);
        //            return true;
        //        case 2:
        //            DeleteArea(sqlDAL);
        //            return true;
        //        case 3:
        //            ReadAreas(sqlDAL);
        //            return true;
        //        case 4:
        //            UpdateArea(sqlDAL);
        //            return true;
        //        case 5:
        //            return false;
        //        default:
        //            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        //            return true;
        //    }
        //}

        //static void AddArea(SQLDAL sqlDAL)
        //{
        //    Console.WriteLine("Enter the owner of the new area:");
        //    string owner = Console.ReadLine();
        //    Console.WriteLine("Enter the name of the new area:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter the region of the new area:");
        //    string region = Console.ReadLine();
        //    Console.WriteLine("Enter the type of the new area:");
        //    string type = Console.ReadLine();

        //    AREA newArea = new AREA(owner, name, region, type);
        //    sqlDAL.AddArea(newArea);
        //    Console.WriteLine("Area added successfully.");
        //}

        //static void DeleteArea(SQLDAL sqlDAL)
        //{
        //    ReadAreas(sqlDAL);
        //    Console.WriteLine("Enter the AreaId of the area you want to delete:");
        //    if (int.TryParse(Console.ReadLine(), out int areaIdToDelete))
        //    {
        //        sqlDAL.DeleteArea(areaIdToDelete);
        //        Console.WriteLine("Area deleted successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid AreaId entered.");
        //    }
        //}

        //static void ReadAreas(SQLDAL sqlDAL)
        //{
        //    List<AREA> areas = sqlDAL.GetAreas();
        //    Console.WriteLine("All areas:");
        //    foreach (AREA area in areas)
        //    {
        //        Console.WriteLine($"AreaId: {area.AreaId}, Owner: {area.Owner}, Name: {area.Name}, Region: {area.Region}, Type: {area.Type}");
        //    }
        //}

        //static void UpdateArea(SQLDAL sqlDAL)
        //{
        //    ReadAreas(sqlDAL);
        //    Console.WriteLine("Enter the AreaId of the area you want to update:");
        //    if (int.TryParse(Console.ReadLine(), out int areaIdToUpdate))
        //    {
        //        AREA areaToUpdate = sqlDAL.GetAreas().Find(a => a.AreaId == areaIdToUpdate);
        //        if (areaToUpdate != null)
        //        {
        //            Console.WriteLine("Enter the new owner of the area:");
        //            areaToUpdate.Owner = Console.ReadLine();
        //            Console.WriteLine("Enter the new name of the area:");
        //            areaToUpdate.Name = Console.ReadLine();
        //            Console.WriteLine("Enter the new region of the area:");
        //            areaToUpdate.Region = Console.ReadLine();
        //            Console.WriteLine("Enter the new type of the area:");
        //            areaToUpdate.Type = Console.ReadLine();

        //            sqlDAL.UpdateArea(areaToUpdate);
        //            Console.WriteLine("Area updated successfully.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Area not found.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid AreaId entered.");
        //    }
        //}
    }
}
