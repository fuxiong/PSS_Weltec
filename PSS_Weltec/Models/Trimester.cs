using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class Trimester
    {
        #region Attribute
        public int tri_Id{ get; set; }
        public string tri_Name{ get; set; }
        public DateTime tri_StartDate { get; set; }
        public DateTime tri_EndDate { get; set; }
        public bool tri_IsOpen{ get; set; }
        #endregion

        #region Assistant Attribute
        public string StartDate_Time { get; set; }
        public string EndDate_Time { get; set; }
        public string IsOpen { get; set; }
        #endregion
    }
}