using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class News
    {
        #region Attribute
        public int news_Id { get; set; }
        public int news_User_Id { get; set; }
        public DateTime news_Update_Time { get; set; }
        public string news_Content { get; set; }
        public string news_Title { get; set; }
        #endregion

        #region Assistant Attribute
        public string Update_Time { get; set; }
        #endregion
    }
}