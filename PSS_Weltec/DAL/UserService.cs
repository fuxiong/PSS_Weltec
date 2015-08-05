using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using System.Data;

namespace PSS_Weltec.DAL
{
    public class UserService
    {
        public static bool IsValidation(string userName, string password)
        {
            bool bLogIn=false;
            string sql = "select * from PSS_User where user_Name='" + userName + "' and user_Password='" +SqlHelper.Fun_Secret(password)+"'";
            bLogIn=SqlHelper.HasRecord(sql);
            return bLogIn;
        }

        public static User GetModel(string sName)
        {
            string sql = "select * from PSS_User where user_Name='" + sName + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            User model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new User();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Id"].ToString()))
                {
                    model.user_Id = int.Parse(ds.Tables[0].Rows[0]["user_Id"].ToString());
                }

                model.user_Name = ds.Tables[0].Rows[0]["user_Name"].ToString();
                model.user_Password = ds.Tables[0].Rows[0]["user_Password"].ToString();
                model.user_Email = ds.Tables[0].Rows[0]["user_Email"].ToString();
                model.user_Telephone = ds.Tables[0].Rows[0]["user_Telephone"].ToString();
                //model.user_Is_Teacher = ds.Tables[0].Rows[0]["user_Is_Teacher"];
                model.user_StudentId = ds.Tables[0].Rows[0]["user_StudentId"].ToString();
                //model.user_Project = ds.Tables[0].Rows[0]["user_Project"].ToString();
                //model.user_skill = ds.Tables[0].Rows[0]["user_skill"].ToString();
                model.user_Introduction = ds.Tables[0].Rows[0]["user_Introduction"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Register_Time"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Log_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Log_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static bool IsExistName(string sName)
        {
            bool bExist = false;
            string sql = "select * from PSS_User where user_Name='" + sName + "'";
            bExist = SqlHelper.ExecuteBySql(sql);
            return bExist;
        }
        public static void Add(User model)
        {
            string sql = "select * from PSS_User";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            DataRow dr = ds.Tables["PSS_User"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(user_Id) from PSS_User");
            dr["user_Id"] = ++maxId;
            dr["user_Name"] = model.user_Name;
            dr["user_Password"] = model.user_Password;
            dr["user_Email"] = model.user_Email;
            dr["user_Telephone"] = model.user_Telephone;
            dr["user_Is_Teacher"] = model.user_Is_Teacher;
            dr["user_StudentId"] = model.user_StudentId;
            dr["user_Project"] = model.user_Project;
            dr["user_skill"] = model.user_Skill;
            dr["user_Introduction"] = model.user_Introduction;
            dr["user_Register_Time"] = model.user_Register_Time;
            dr["user_Log_Time"] = model.user_Log_Time;
            dr["user_Update_Time"] = model.user_Update_Time;

            ds.Tables["PSS_User"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_User");
            if (ds != null)
                ds.Dispose();
        }
        public static void Update(User model)
        {
            string sql = "select * from PSS_User where user_Id='" + model.user_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            DataRow dr = ds.Tables["PSS_User"].Rows[0];

            dr["user_Name"] = model.user_Name;
            dr["user_Password"] = model.user_Password;
            dr["user_Email"] = model.user_Email;
            dr["user_Telephone"] = model.user_Telephone;
            dr["user_Is_Teacher"] = model.user_Is_Teacher;
            dr["user_StudentId"] = model.user_StudentId;
            dr["user_Project"] = model.user_Project;
            dr["user_skill"] = model.user_Skill;
            dr["user_Introduction"] = model.user_Introduction;
            dr["user_Register_Time"] = model.user_Register_Time;
            dr["user_Log_Time"] = model.user_Log_Time;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_User");
            if (ds != null)
                ds.Dispose();
        }
        public static void Delete(User model)
        {
            string sql = "select * from PSS_User where user_Id='" + model.user_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            DataRow dr = ds.Tables["PSS_User"].Rows[0];
            dr.Delete();

            SqlHelper.UpdateDataSet(ds, sql, "PSS_User");
            if (ds != null)
                ds.Dispose();
            
        }
    }
}