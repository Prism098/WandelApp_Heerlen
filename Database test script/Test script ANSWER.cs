using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Database_test_script
{
    internal class Test_script_ANSWER
    {
        
        //    static void main(string[] args)
        //{
        //    sqldal sqldal = sqldal.instance;
        //    bool continueprogram = true;

        //    do
        //    {
        //        console.writeline("what do you want to do?");
        //        console.writeline("1. add answer");
        //        console.writeline("2. delete answer");
        //        console.writeline("3. read answers");
        //        console.writeline("4. update answer");
        //        console.writeline("5. exit");

        //        if (int.tryparse(console.readline(), out int choice))
        //        {
        //            continueprogram = handleuserchoice(choice, sqldal);
        //        }
        //        else
        //        {
        //            console.writeline("invalid input. please enter a number.");
        //        }
        //    } while (continueprogram);
        //}

        //static bool handleuserchoice(int choice, sqldal sqldal)
        //{
        //    switch (choice)
        //    {
        //        case 1:
        //            addanswer(sqldal);
        //            return true;
        //        case 2:
        //            deleteanswer(sqldal);
        //            return true;
        //        case 3:
        //            readanswers(sqldal);
        //            return true;
        //        case 4:
        //            updateanswer(sqldal);
        //            return true;
        //        case 5:
        //            return false;
        //        default:
        //            console.writeline("invalid input. please enter a number between 1 and 5.");
        //            return true;
        //    }
        //}

        //static void addanswer(sqldal sqldal)
        //{
        //    console.writeline("enter the text of the new answer:");
        //    string answertext = console.readline();
        //    console.writeline("enter the questionid of the new answer:");
        //    if (int.tryparse(console.readline(), out int questionid))
        //    {
        //        answer newanswer = new answer(answertext, questionid);
        //        sqldal.addanswer(newanswer);
        //        console.writeline("answer added successfully.");
        //    }
        //    else
        //    {
        //        console.writeline("invalid questionid entered.");
        //    }
        //}

        //static void deleteanswer(sqldal sqldal)
        //{
        //    readanswers(sqldal);
        //    console.writeline("enter the answerid of the answer you want to delete:");
        //    if (int.tryparse(console.readline(), out int answeridtodelete))
        //    {
        //        sqldal.deleteanswer(answeridtodelete);
        //        console.writeline("answer deleted successfully.");
        //    }
        //    else
        //    {
        //        console.writeline("invalid answerid entered.");
        //    }
        //}

        //static void readanswers(sqldal sqldal)
        //{
        //    list<answer> answers = sqldal.getanswers();
        //    console.writeline("all answers:");
        //    foreach (answer answer in answers)
        //    {
        //        console.writeline($"answerid: {answer.answerid}, answertext: {answer.answertext}, questionid: {answer.questionid}");
        //    }
        //}

        //static void updateanswer(sqldal sqldal)
        //{
        //    readanswers(sqldal);
        //    console.writeline("enter the answerid of the answer you want to update:");
        //    if (int.tryparse(console.readline(), out int answeridtoupdate))
        //    {
        //        answer answertoupdate = sqldal.getanswers().find(a => a.answerid == answeridtoupdate);
        //        if (answertoupdate != null)
        //        {
        //            console.writeline("enter the new text of the answer:");
        //            answertoupdate.answertext = console.readline();
        //            console.writeline("enter the new questionid of the answer:");
        //            if (int.tryparse(console.readline(), out int newquestionid))
        //            {
        //                answertoupdate.questionid = newquestionid;
        //                sqldal.updateanswer(answertoupdate);
        //                console.writeline("answer updated successfully.");
        //            }
        //            else
        //            {
        //                console.writeline("invalid questionid entered.");
        //            }
        //        }
        //        else
        //        {
        //            console.writeline("answer not found.");
        //        }
        //    }
        //    else
        //    {
        //        console.writeline("invalid answerid entered.");
        //    }
        }
    }
    


