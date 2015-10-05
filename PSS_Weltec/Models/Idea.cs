using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Idea
    {
        #region Attribute
        public int Idea_Id { get; set; }
        public string Idea_Title { get; set; }
        public string Idea_Staff_Contact { get; set; }
        public string Idea_Client_Contact { get; set; }
        public string Idea_Client_Company { get; set; }
        public string Idea_Valid_Dates { get; set; }
        public string Idea_Students_Num { get; set; }
        public bool Idea_Continuation { get; set; }
        public string Idea_Description { get; set; }
        public string Idea_Skills_Required { get; set; }
        public string Idea_Context { get; set; }
        public string Idea_Goals { get; set; }
        public string Idea_Features { get; set; }
        public string Idea_Challenges { get; set; }
        public string Idea_Opportunities { get; set; }
        public int Idea_Trimester_Id { get; set; }
        public DateTime Idea_Update_Time { get; set; }
        public string Idea_Presenter { get; set; }
        public string Idea_Advisor_Contact { get; set; }
        public int Idea_Status{ get; set; }
        #endregion

        #region Assistant Attribute
        public string Update_Time { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public string Skills_Required { get; set; }
        public string Goals { get; set; }
        public string Features { get; set; }
        public string Challenges { get; set; }
        public string Opportunities { get; set; }
        public string Status { get; set; }
        #endregion
    }
}