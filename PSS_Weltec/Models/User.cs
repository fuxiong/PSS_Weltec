using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Models
{
    public class User
    {
        #region Attribute
        public int user_Id { get; set; }
        public string user_Name { get; set; }
        public string user_Password { get; set; }
        public string user_Email { get; set; }
        public string user_Telephone { get; set; }
        public bool user_Is_Teacher { get; set; }
        public string user_StudentId { get; set; }
        public string user_Project { get; set; }
        public string user_Skill { get; set; }
        public string user_Introduction { get; set; }
        public DateTime user_Register_Time { get; set; }
        public DateTime user_Log_Time { get; set; }
        public DateTime user_Update_Time { get; set; }
        #endregion


        #region Assistant Attribute
        [Required]
        [Display(Name = "UserName")]
        public string user_Name_Model
        { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string user_Password_Model
        { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confire Password")]
        public string user_confire_Password_Model { get; set; }

        [Display(Name = "RememberMe?")]
        public bool RememberMe_Model { get; set; }
        #endregion


        #region Assistant Attribute
        public string Register_Time { get; set; }
        public string Log_Time { get; set; }
        public string Update_Time { get; set; }
        #endregion
    }
}