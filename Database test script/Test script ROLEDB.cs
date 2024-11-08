using ExotischNederlandKaasus.DAL;
using ExotischNederlandKaasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Database_test_script
{
    // Copy this script in Program.cs to test the databse input for ROLE
    internal class Role_DB_Test
    {
        //static void Main(string[] args)
        //{
        //    SQLDAL sqlDAL = SQLDAL.Instance;
        //    bool continueProgram = true;

        //    do
        //    {
        //        Console.WriteLine("What do you want to do?");
        //        Console.WriteLine("1. Add Role");
        //        Console.WriteLine("2. Delete Role");
        //        Console.WriteLine("3. Read Roles");
        //        Console.WriteLine("4. Update Role");
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
        //            AddRole(sqlDAL);
        //            return true;
        //        case 2:
        //            DeleteRole(sqlDAL);
        //            return true;
        //        case 3:
        //            ReadRoles(sqlDAL);
        //            return true;
        //        case 4:
        //            UpdateRole(sqlDAL);
        //            return true;
        //        case 5:
        //            return false;
        //        default:
        //            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        //            return true;
        //    }
        //}

        //static void AddRole(SQLDAL sqlDAL)
        //{
        //    Console.WriteLine("Enter the name of the new role:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter the description of the new role:");
        //    string description = Console.ReadLine();

        //    ROLE newRole = new ROLE(name, description);
        //    sqlDAL.AddRole(newRole);
        //    Console.WriteLine("Role added successfully.");
        //}

        //static void DeleteRole(SQLDAL sqlDAL)
        //{
        //    ReadRoles(sqlDAL);
        //    Console.WriteLine("Enter the RoleId of the role you want to delete:");
        //    if (int.TryParse(Console.ReadLine(), out int roleIdToDelete))
        //    {
        //        sqlDAL.DeleteRole(roleIdToDelete);
        //        Console.WriteLine("Role deleted successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid RoleId entered.");
        //    }
        //}

        //static void ReadRoles(SQLDAL sqlDAL)
        //{
        //    List<ROLE> roles = sqlDAL.GetRoles();
        //    Console.WriteLine("All roles:");
        //    foreach (ROLE role in roles)
        //    {
        //        Console.WriteLine($"RoleId: {role.RoleId}, Name: {role.Name}, Description: {role.Description}");
        //    }
        //}

        //static void UpdateRole(SQLDAL sqlDAL)
        //{
        //    ReadRoles(sqlDAL);
        //    Console.WriteLine("Enter the RoleId of the role you want to update:");
        //    if (int.TryParse(Console.ReadLine(), out int roleIdToUpdate))
        //    {
        //        ROLE roleToUpdate = sqlDAL.GetRoles().Find(r => r.RoleId == roleIdToUpdate);
        //        if (roleToUpdate != null)
        //        {
        //            Console.WriteLine("Enter the new name of the role:");
        //            roleToUpdate.Name = Console.ReadLine();
        //            Console.WriteLine("Enter the new description of the role:");
        //            roleToUpdate.Description = Console.ReadLine();

        //            sqlDAL.UpdateRole(roleToUpdate);
        //            Console.WriteLine("Role updated successfully.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Role not found.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid RoleId entered.");
        //    }
        //}
    }
}
