using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using System.Data;
using PSS_Weltec.Shared_Class;

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
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Trimester_Id"].ToString()))
                {
                    model.user_Trimester_Id = int.Parse(ds.Tables[0].Rows[0]["user_Trimester_Id"].ToString());
                }

                model.user_Name = ds.Tables[0].Rows[0]["user_Name"].ToString();
                model.user_Password = ds.Tables[0].Rows[0]["user_Password"].ToString();
                model.user_Email = ds.Tables[0].Rows[0]["user_Email"].ToString();
                model.user_Telephone = ds.Tables[0].Rows[0]["user_Telephone"].ToString();
                model.user_StudentId = ds.Tables[0].Rows[0]["user_StudentId"].ToString();
                model.user_Skill = ds.Tables[0].Rows[0]["user_Skill"].ToString();
                model.user_Introduction = ds.Tables[0].Rows[0]["user_Introduction"].ToString();
                model.user_Statue = (bool)ds.Tables[0].Rows[0]["user_Statue"];
                model.User_Email_Visiable = (bool)ds.Tables[0].Rows[0]["User_Email_Visiable"];
                model.User_Telephone_Visiable = (bool)ds.Tables[0].Rows[0]["User_Telephone_Visiable"];

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Register_Time"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Log_Time"].ToString()))
                {
                    model.user_Log_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Log_Time"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Update_Time"].ToString()))
                {
                    model.user_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Update_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static User GetModel(int id)
        {
            string sql = "select * from PSS_User where user_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            User model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new User();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Id"].ToString()))
                {
                    model.user_Id = int.Parse(ds.Tables[0].Rows[0]["user_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Trimester_Id"].ToString()))
                {
                    model.user_Trimester_Id = int.Parse(ds.Tables[0].Rows[0]["user_Trimester_Id"].ToString());
                }


                model.user_Name = ds.Tables[0].Rows[0]["user_Name"].ToString();
                model.user_Password = ds.Tables[0].Rows[0]["user_Password"].ToString();
                model.user_Email = ds.Tables[0].Rows[0]["user_Email"].ToString();
                model.user_Telephone = ds.Tables[0].Rows[0]["user_Telephone"].ToString();
                model.user_StudentId = ds.Tables[0].Rows[0]["user_StudentId"].ToString();
                model.user_Skill = ds.Tables[0].Rows[0]["user_Skill"].ToString();
                model.user_Introduction = ds.Tables[0].Rows[0]["user_Introduction"].ToString();
                model.user_Statue = (bool)ds.Tables[0].Rows[0]["user_Statue"];
                model.User_Email_Visiable = (bool)ds.Tables[0].Rows[0]["User_Email_Visiable"];
                model.User_Telephone_Visiable = (bool)ds.Tables[0].Rows[0]["User_Telephone_Visiable"];

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Register_Time"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Log_Time"].ToString()))
                {
                    model.user_Log_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Log_Time"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["user_Update_Time"].ToString()))
                {
                    model.user_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["user_Update_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static bool IsExistName(string sName,int trimester_Id)
        {
            bool bExist = false;
            string sql = "select * from PSS_User where user_Name='" + sName + "' and user_Trimester_Id=" + trimester_Id;
            bExist = SqlHelper.ExecuteBySql(sql);
            return bExist;
        }
        public static void Save(User model)
        {
            string sql = "select * from PSS_User where 1<>1";
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
            dr["user_Skill"] = model.user_Skill;
            dr["user_Introduction"] = model.user_Introduction;
            dr["user_Register_Time"] = model.user_Register_Time;
            dr["user_Log_Time"] = model.user_Log_Time;
            dr["user_Update_Time"] = model.user_Update_Time;
            dr["user_Trimester_Id"] = model.user_Trimester_Id;
            dr["user_Statue"] = model.user_Statue;
            dr["User_Email_Visiable"] = model.User_Email_Visiable;
            dr["User_Telephone_Visiable"] = model.User_Telephone_Visiable;

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
            dr["user_Skill"] = model.user_Skill;
            dr["user_Introduction"] = model.user_Introduction;
            dr["user_Register_Time"] = model.user_Register_Time;
            dr["user_Log_Time"] = model.user_Log_Time;
            dr["user_Trimester_Id"] = model.user_Trimester_Id;
            dr["user_Statue"] = model.user_Statue;
            dr["User_Email_Visiable"] = model.User_Email_Visiable;
            dr["User_Telephone_Visiable"] = model.User_Telephone_Visiable;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_User");
            if (ds != null)
                ds.Dispose();
        }

        public static void UpdateList(List<User> list)
        {
            string idList = null;
            if (list != null && list.Count() > 0)
            {
                foreach (User user in list)
                {
                    if (!string.IsNullOrEmpty(idList))
                        idList += ",";
                    idList += user.user_Id;
                }
            }
            string sql = "select * from PSS_User where user_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            foreach (User user in list)
            {
                foreach (DataRow dr in ds.Tables["PSS_User"].Rows)
                {
                    if (user.user_Id.ToString() == dr["user_Id"].ToString())
                    {
                        dr["user_Name"] = user.user_Name;
                        dr["user_Password"] = user.user_Password;
                        dr["user_Email"] = user.user_Email;
                        dr["user_Telephone"] = user.user_Telephone;
                        dr["user_Is_Teacher"] = user.user_Is_Teacher;
                        dr["user_StudentId"] = user.user_StudentId;
                        dr["user_Skill"] = user.user_Skill;
                        dr["user_Introduction"] = user.user_Introduction;
                        dr["user_Register_Time"] = user.user_Register_Time;
                        dr["user_Log_Time"] = user.user_Log_Time;
                        dr["user_Trimester_Id"] = user.user_Trimester_Id;
                        dr["user_Statue"] = user.user_Statue;
                        dr["User_Email_Visiable"] = user.User_Email_Visiable;
                        dr["User_Telephone_Visiable"] = user.User_Telephone_Visiable;
                    }
                }
            }
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

        public static List<User> GetList()
        {
            List<User> list = new List<User>();
            User model = null;
            string sql = "select * from PSS_User";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            foreach(DataRow dr in ds.Tables["PSS_User"].Rows)
            {
                model = new User();

                if (!string.IsNullOrEmpty(dr["user_Id"].ToString()))
                {
                    model.user_Id = int.Parse(dr["user_Id"].ToString());
                }

                if (!string.IsNullOrEmpty(dr["user_Trimester_Id"].ToString()))
                {
                    model.user_Trimester_Id = int.Parse(dr["user_Trimester_Id"].ToString());
                }

                model.user_Name = dr["user_Name"].ToString();
                model.user_Password = dr["user_Password"].ToString();
                model.user_Email = dr["user_Email"].ToString();
                model.user_Telephone = dr["user_Telephone"].ToString();
                model.user_StudentId = dr["user_StudentId"].ToString();
                model.user_Introduction = dr["user_Introduction"].ToString();
                model.user_Statue = (bool)dr["user_Statue"];
                model.User_Email_Visiable = (bool)dr["User_Email_Visiable"];
                model.User_Telephone_Visiable = (bool)dr["User_Telephone_Visiable"];

                if (!string.IsNullOrEmpty(dr["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(dr["user_Register_Time"].ToString());
                    model.Register_Time = model.user_Register_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Log_Time"].ToString()))
                {
                    model.user_Log_Time = DateTime.Parse(dr["user_Log_Time"].ToString());
                    model.Log_Time = model.user_Log_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Update_Time"].ToString()))
                {
                    model.user_Update_Time = DateTime.Parse(dr["user_Update_Time"].ToString());
                    model.Update_Time = model.user_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<User> GetList(string idList)
        {
            List<User> list = new List<User>();
            User model = null;
            string sql = "select * from PSS_User where user_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_User");
            foreach (DataRow dr in ds.Tables["PSS_User"].Rows)
            {
                model = new User();

                if (!string.IsNullOrEmpty(dr["user_Id"].ToString()))
                {
                    model.user_Id = int.Parse(dr["user_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["user_Trimester_Id"].ToString()))
                {
                    model.user_Trimester_Id = int.Parse(dr["user_Trimester_Id"].ToString());
                }

                model.user_Name = dr["user_Name"].ToString();
                model.user_Password = dr["user_Password"].ToString();
                model.user_Email = dr["user_Email"].ToString();
                model.user_Telephone = dr["user_Telephone"].ToString();
                model.user_Introduction = dr["user_Introduction"].ToString();
                model.user_Statue = (bool)dr["user_Statue"];
                model.User_Email_Visiable = (bool)dr["User_Email_Visiable"];
                model.User_Telephone_Visiable = (bool)dr["User_Telephone_Visiable"];

                if (!string.IsNullOrEmpty(dr["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(dr["user_Register_Time"].ToString());
                    model.Register_Time = model.user_Register_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Log_Time"].ToString()))
                {
                    model.user_Log_Time = DateTime.Parse(dr["user_Log_Time"].ToString());
                    model.Log_Time = model.user_Log_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Update_Time"].ToString()))
                {
                    model.user_Update_Time = DateTime.Parse(dr["user_Update_Time"].ToString());
                    model.Update_Time = model.user_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }

        public static List<User> GetList(Paging paging,string order, string sort,int trimesterId,string queryWord)
        {
            List<User> list = new List<User>();
            User model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_User","user_Trimester_Id", trimesterId,paging, order, sort);
            foreach(DataRow dr in ds.Tables["PSS_User"].Rows)
            {
                model = new User();

                if (!string.IsNullOrEmpty(dr["user_Id"].ToString()))
                {
                    model.user_Id = int.Parse(dr["user_Id"].ToString());
                }

                model.user_Name = dr["user_Name"].ToString();
                model.user_Password = dr["user_Password"].ToString();
                model.user_Email = dr["user_Email"].ToString();
                model.user_Telephone = dr["user_Telephone"].ToString();
                model.user_StudentId = dr["user_StudentId"].ToString();
                model.user_Skill = dr["user_Skill"].ToString();
                model.user_Introduction = dr["user_Introduction"].ToString();
                model.user_Statue = (bool)dr["user_Statue"];
                model.User_Email_Visiable = (bool)dr["User_Email_Visiable"];
                model.User_Telephone_Visiable = (bool)dr["User_Telephone_Visiable"];

                if (!string.IsNullOrEmpty(dr["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(dr["user_Register_Time"].ToString());
                    model.Register_Time = model.user_Register_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Log_Time"].ToString()))
                {
                    model.user_Log_Time = DateTime.Parse(dr["user_Log_Time"].ToString());
                    model.Log_Time = model.user_Log_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Update_Time"].ToString()))
                {
                    model.user_Update_Time = DateTime.Parse(dr["user_Update_Time"].ToString());
                    model.Update_Time = model.user_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<User> GetList(Paging paging, string order, string sort, int trimesterId,string status, string queryWord)
        {
            List<User> list = new List<User>();
            User model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_User","user_Trimester_Id", trimesterId,status,paging, order, sort);
            foreach (DataRow dr in ds.Tables["PSS_User"].Rows)
            {
                model = new User();

                if (!string.IsNullOrEmpty(dr["user_Id"].ToString()))
                {
                    model.user_Id = int.Parse(dr["user_Id"].ToString());
                }

                model.user_Name = dr["user_Name"].ToString();
                model.user_Password = dr["user_Password"].ToString();
                model.user_Email = dr["user_Email"].ToString();
                model.user_Telephone = dr["user_Telephone"].ToString();
                model.user_StudentId = dr["user_StudentId"].ToString();
                model.user_Skill = dr["user_Skill"].ToString();
                model.user_Introduction = dr["user_Introduction"].ToString();
                model.user_Statue = (bool)dr["user_Statue"];
                model.User_Email_Visiable = (bool)dr["User_Email_Visiable"];
                model.User_Telephone_Visiable = (bool)dr["User_Telephone_Visiable"];

                if (!string.IsNullOrEmpty(dr["user_Register_Time"].ToString()))
                {
                    model.user_Register_Time = DateTime.Parse(dr["user_Register_Time"].ToString());
                    model.Register_Time = model.user_Register_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Log_Time"].ToString()))
                {
                    model.user_Log_Time = DateTime.Parse(dr["user_Log_Time"].ToString());
                    model.Log_Time = model.user_Log_Time.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["user_Update_Time"].ToString()))
                {
                    model.user_Update_Time = DateTime.Parse(dr["user_Update_Time"].ToString());
                    model.Update_Time = model.user_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
    }
}