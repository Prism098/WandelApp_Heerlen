namespace ExotischNederlandKaasus.Models
{
    using global::ExotischNederlandKaasus.DAL;
    using System;
    using System.Collections.Generic;

    namespace ExotischNederlandKaasus.Models
    {
        internal class USRQUEST
        {
            private SQLDAL sqlDAL = SQLDAL.Instance;
            public int UsrQuestId { get; private set; }
            public string AnswerText { get; set; }
            public USER? User { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
            public int UserId { get; set; }
            public QUESTION? Question { get; set; } // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.
            public int QuestionId { get; set; }

            //Constructors that are being used to make database calls
            public USRQUEST(int usrQuestId, string answerText, int userId, int questionId)
            {
                UsrQuestId = usrQuestId;
                AnswerText = answerText;
                UserId = userId;
                QuestionId = questionId;
            }
            public USRQUEST(string answerText, int userId, int questionId)
            {
                AnswerText = answerText;
                UserId = userId;
                QuestionId = questionId;
            }

            public void SetUsrQuestId(int id)
            {
                UsrQuestId = id;
            } // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

            // Interaction with the database methods.
            public bool AddUsrQuest()
            {
                return sqlDAL.AddUsrQuest(this);
            }
            public bool UpdateUsrQuest(USRQUEST usrQuest)
            {
                return sqlDAL.UpdateUsrQuest(usrQuest);
            }
            public List<USRQUEST> GetUsrQuests()
            {
                return sqlDAL.GetUsrQuests();
            }
            public bool DeleteUsrQuest()
            {
                return sqlDAL.DeleteUsrQuest(this.UsrQuestId);
            }
        }
    }
}
