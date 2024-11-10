using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public USER User { get; set; }
            public int UserId { get; set; }
            public QUESTION Question { get; set; }
            public int QuestionId { get; set; }

            public USRQUEST(int usrQuestId, string answerText, int userId, int questionId)
            {
                UsrQuestId = usrQuestId;
                AnswerText = answerText;
                UserId = userId;
                QuestionId = questionId;
            }

            public USRQUEST()
            {
                
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
            }

            // Interaction with the database methods.
            public void AddUsrQuest()
            {
                sqlDAL.AddUsrQuest(this);
            }

            public void UpdateUsrQuest(USRQUEST usrQuest)
            {
                sqlDAL.UpdateUsrQuest(usrQuest);
            }

            public List<USRQUEST> GetUsrQuests()
            {
                return sqlDAL.GetUsrQuests();
            }

            public void DeleteUsrQuest()
            {
                sqlDAL.DeleteUsrQuest(this.UsrQuestId);
            }
        }
    }
}
