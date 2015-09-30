using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Proj_Discussion
    {
        #region Attribute
        public int Proj_Disc_Id { get; set; }
        public int Proj_Disc_User_Id{ get; set; }
        public int Proj_Disc_Proj_Id{ get; set; }
        public DateTime Proj_Disc_Time{ get; set; }
        public string Proj_Disc_Content{ get; set; }
        #endregion

        #region Assistant Attribute
        public string Disc_Time { get; set; }
        public string UserName { get; set; }
        #endregion
    }
}