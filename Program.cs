using ExotischNederlandKaasus.DAL;
using ExotischNederlandKaasus.Models;
using System;
using System.Collections.Generic;

namespace ExotischNederlandKaasus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLDAL sqlDAL = SQLDAL.Instance;
            bool continueProgram = true;

            do
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Add Answer");
                Console.WriteLine("2. Delete Answer");
                Console.WriteLine("3. Read Answers");
                Console.WriteLine("4. Update Answer");
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
                    AddAnswer(sqlDAL);
                    return true;
                case 2:
                    DeleteAnswer(sqlDAL);
                    return true;
                case 3:
                    ReadAnswers(sqlDAL);
                    return true;
                case 4:
                    UpdateAnswer(sqlDAL);
                    return true;
                case 5:
                    return false;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    return true;
            }
        }

        static void AddAnswer(SQLDAL sqlDAL)
        {
            Console.WriteLine("Enter the text of the new answer:");
            string answerText = Console.ReadLine();
            Console.WriteLine("Enter the QuestionId of the new answer:");
            if (int.TryParse(Console.ReadLine(), out int questionId))
            {
                ANSWER newAnswer = new ANSWER(answerText, questionId);
                sqlDAL.AddAnswer(newAnswer);
                Console.WriteLine("Answer added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid QuestionId entered.");
            }
        }

        static void DeleteAnswer(SQLDAL sqlDAL)
        {
            ReadAnswers(sqlDAL);
            Console.WriteLine("Enter the AnswerId of the answer you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int answerIdToDelete))
            {
                sqlDAL.DeleteAnswer(answerIdToDelete);
                Console.WriteLine("Answer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid AnswerId entered.");
            }
        }

        static void ReadAnswers(SQLDAL sqlDAL)
        {
            List<ANSWER> answers = sqlDAL.GetAnswers();
            Console.WriteLine("All answers:");
            foreach (ANSWER answer in answers)
            {
                Console.WriteLine($"AnswerId: {answer.AnswerId}, AnswerText: {answer.AnswerText}, QuestionId: {answer.QuestionId}");
            }
        }

        static void UpdateAnswer(SQLDAL sqlDAL)
        {
            ReadAnswers(sqlDAL);
            Console.WriteLine("Enter the AnswerId of the answer you want to update:");
            if (int.TryParse(Console.ReadLine(), out int answerIdToUpdate))
            {
                ANSWER answerToUpdate = sqlDAL.GetAnswers().Find(a => a.AnswerId == answerIdToUpdate);
                if (answerToUpdate != null)
                {
                    Console.WriteLine("Enter the new text of the answer:");
                    answerToUpdate.AnswerText = Console.ReadLine();
                    Console.WriteLine("Enter the new QuestionId of the answer:");
                    if (int.TryParse(Console.ReadLine(), out int newQuestionId))
                    {
                        answerToUpdate.QuestionId = newQuestionId;
                        sqlDAL.UpdateAnswer(answerToUpdate);
                        Console.WriteLine("Answer updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid QuestionId entered.");
                    }
                }
                else
                {
                    Console.WriteLine("Answer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid AnswerId entered.");
            }
        }
    }
}