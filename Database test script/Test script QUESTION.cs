using ExotischNederlandKaasus.DAL;
using ExotischNederlandKaasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Database_test_script
{
//    internal class Test_script_QUESTION
//    {
//        SQLDAL sqlDAL = SQLDAL.Instance;
//        bool continueProgram = true;

//        do
//        {
//            Console.WriteLine("What do you want to do?");
//            Console.WriteLine("1. Add Question");
//            Console.WriteLine("2. Delete Question");
//            Console.WriteLine("3. Read Questions");
//            Console.WriteLine("4. Update Question");
//            Console.WriteLine("5. Exit");

//            if (int.TryParse(Console.ReadLine(), out int choice))
//            {
//                continueProgram = HandleUserChoice(choice, sqlDAL);
//    }
//            else
//            {
//                Console.WriteLine("Invalid input. Please enter a number.");
//            }
//        } while (continueProgram) ;
//    }

//    static bool HandleUserChoice(int choice, SQLDAL sqlDAL)
//{
//    switch (choice)
//    {
//        case 1:
//            AddQuestion(sqlDAL);
//            return true;
//        case 2:
//            DeleteQuestion(sqlDAL);
//            return true;
//        case 3:
//            ReadQuestions(sqlDAL);
//            return true;
//        case 4:
//            UpdateQuestion(sqlDAL);
//            return true;
//        case 5:
//            return false;
//        default:
//            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
//            return true;
//    }
//}

//static void AddQuestion(SQLDAL sqlDAL)
//{
//    Console.WriteLine("Enter the text of the new question:");
//    string questionText = Console.ReadLine();
//    Console.WriteLine("Enter the GameId of the new question:");
//    if (int.TryParse(Console.ReadLine(), out int gameId))
//    {
//        QUESTION newQuestion = new QUESTION(questionText, gameId);
//        sqlDAL.AddQuestion(newQuestion);
//        Console.WriteLine("Question added successfully.");
//    }
//    else
//    {
//        Console.WriteLine("Invalid GameId entered.");
//    }
//}

//static void DeleteQuestion(SQLDAL sqlDAL)
//{
//    ReadQuestions(sqlDAL);
//    Console.WriteLine("Enter the QuestionId of the question you want to delete:");
//    if (int.TryParse(Console.ReadLine(), out int questionIdToDelete))
//    {
//        sqlDAL.DeleteQuestion(questionIdToDelete);
//        Console.WriteLine("Question deleted successfully.");
//    }
//    else
//    {
//        Console.WriteLine("Invalid QuestionId entered.");
//    }
//}

//static void ReadQuestions(SQLDAL sqlDAL)
//{
//    List<QUESTION> questions = sqlDAL.GetQuestions();
//    Console.WriteLine("All questions:");
//    foreach (QUESTION question in questions)
//    {
//        Console.WriteLine($"QuestionId: {question.QuestionId}, QuestionText: {question.QuestionText}, GameId: {question.GameId}");
//    }
//}

//static void UpdateQuestion(SQLDAL sqlDAL)
//{
//    ReadQuestions(sqlDAL);
//    Console.WriteLine("Enter the QuestionId of the question you want to update:");
//    if (int.TryParse(Console.ReadLine(), out int questionIdToUpdate))
//    {
//        QUESTION questionToUpdate = sqlDAL.GetQuestions().Find(q => q.QuestionId == questionIdToUpdate);
//        if (questionToUpdate != null)
//        {
//            Console.WriteLine("Enter the new text of the question:");
//            questionToUpdate.QuestionText = Console.ReadLine();
//            Console.WriteLine("Enter the new GameId of the question:");
//            if (int.TryParse(Console.ReadLine(), out int newGameId))
//            {
//                questionToUpdate.GameId = newGameId;
//                sqlDAL.UpdateQuestion(questionToUpdate);
//                Console.WriteLine("Question updated successfully.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid GameId entered.");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Question not found.");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Invalid QuestionId entered.");
//    }
}

