using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Project
    {
        #region Attribute
        public int Proj_Id { get; set; }
        public string Proj_Title { get; set; }
        public string Proj_Staff_Contact { get; set; }
        public string Proj_Client_Contact { get; set; }
        public string Proj_Client_Company{ get; set; }
        public string Proj_Valid_Dates{ get; set; }
        public string Proj_Students_Num{ get; set; }
        public bool Proj_Continuation{ get; set; }
        public string Proj_Description { get; set; }
        public string Proj_Skills_Required{ get; set; }
        public string Proj_Context { get; set; }
        public string Proj_Goals{ get; set; }
        public string Proj_Features{ get; set; }
        public string Proj_Challenges{ get; set; }
        public string Proj_Opportunities{ get; set; }
        public int Proj_Trimester_Id{ get; set; }
        public DateTime Proj_Update_Time { get; set; }
        public string Proj_Presenter { get; set; }
        #endregion

        #region Assistant Attribute
        //public string Valid_Dates { get; set; }
        public string Update_Time { get; set; }
        public string Context{ get; set; }
        public string Description { get; set; }
        public string Skills_Required { get; set; }
        public string Goals { get; set; }
        public string Features { get; set; }
        public string Challenges { get; set; }
        public string Opportunities { get; set; }
        #endregion
    }
}