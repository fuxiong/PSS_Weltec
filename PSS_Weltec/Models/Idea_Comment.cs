using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Idea_Comment
    {
        #region Attribute
        public int Idea_Comm_Id
        { get; set; }
        public int Idea_Comm_Idea_Id
        { get; set; }
        public DateTime Idea_Comm_Time
        { get; set; }
        public string Idea_Comm_Content
        { get; set; }
        #endregion

        #region Assistant Attribute
        public string Comm_Time { get; set; }
        #endregion
    }
}