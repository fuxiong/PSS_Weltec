using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Idea_Discussion
    {
        #region Attribute
        public int Idea_Disc_Id { get; set; }
        public int Idea_Disc_User_Id { get; set; }
        public int Idea_Disc_Idea_Id { get; set; }
        public DateTime Idea_Disc_Time { get; set; }
        public string Idea_Disc_Content { get; set; }
        #endregion

        #region Assistant Attribute
        public string Disc_Time { get; set; }
        public string UserName { get; set; }
        #endregion
    }
}