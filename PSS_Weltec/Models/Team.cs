using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Team
    {
        #region Attribute
        public int Team_Id
        { get; set; }
        public int Team_User_Id
        { get; set; }
        public int Team_Proj_Id
        { get; set; }
        public DateTime Team_Update_Time
        { get; set; }
        public string Team_Title
        { get; set; }
        public int Team_Status
        { get; set; }
        #endregion

        #region Assistant Attribute
        public string Update_Time { get; set; }
        public string Status { get; set; }
        #endregion
    }
}