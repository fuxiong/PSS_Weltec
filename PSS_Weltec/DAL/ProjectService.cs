using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class ProjectService
    {
        public static Project GetModel(string sName)
        {
            string sql = "select * from PSS_Project where Proj_Title='" + sName + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            Project model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Project();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Proj_Id"].ToString()))
                {
                    model.Proj_Id = int.Parse(ds.Tables[0].Rows[0]["Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Proj_Trimester_Id"].ToString()))
                {
                    model.Proj_Trimester_Id = int.Parse(ds.Tables[0].Rows[0]["Proj_Trimester_Id"].ToString());
                }

                model.Proj_Students_Num = ds.Tables[0].Rows[0]["Proj_Students_Num"].ToString();
                model.Proj_Title = ds.Tables[0].Rows[0]["Proj_Title"].ToString();
                model.Proj_Staff_Contact = ds.Tables[0].Rows[0]["Proj_Staff_Contact"].ToString();
                model.Proj_Client_Contact = ds.Tables[0].Rows[0]["Proj_Client_Contact"].ToString();
                model.Proj_Client_Company = ds.Tables[0].Rows[0]["Proj_Client_Company"].ToString();
                model.Proj_Continuation = (bool)ds.Tables[0].Rows[0]["Proj_Continuation"];
                model.Proj_Description = ds.Tables[0].Rows[0]["Proj_Description"].ToString();
                model.Proj_Skills_Required = ds.Tables[0].Rows[0]["Proj_Skills_Required"].ToString();
                model.Proj_Context = ds.Tables[0].Rows[0]["Proj_Context"].ToString();
                model.Proj_Goals = ds.Tables[0].Rows[0]["Proj_Goals"].ToString();
                model.Proj_Features = ds.Tables[0].Rows[0]["Proj_Features"].ToString();
                model.Proj_Challenges = ds.Tables[0].Rows[0]["Proj_Challenges"].ToString();
                model.Proj_Opportunities = ds.Tables[0].Rows[0]["Proj_Opportunities"].ToString();
                model.Proj_Presenter = ds.Tables[0].Rows[0]["Proj_Presenter"].ToString();

                model.Proj_Valid_Dates = ds.Tables[0].Rows[0]["Proj_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Proj_Update_Time"].ToString()))
                {
                    model.Proj_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Proj_Update_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static Project GetModel(int id)
        {
            string sql = "select * from PSS_Project where Proj_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            Project model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Project();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Proj_Id"].ToString()))
                {
                    model.Proj_Id = int.Parse(ds.Tables[0].Rows[0]["Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Proj_Trimester_Id"].ToString()))
                {
                    model.Proj_Trimester_Id = int.Parse(ds.Tables[0].Rows[0]["Proj_Trimester_Id"].ToString());
                }

                model.Proj_Students_Num = ds.Tables[0].Rows[0]["Proj_Students_Num"].ToString();
                model.Proj_Title = ds.Tables[0].Rows[0]["Proj_Title"].ToString();
                model.Proj_Staff_Contact = ds.Tables[0].Rows[0]["Proj_Staff_Contact"].ToString();
                model.Proj_Client_Contact = ds.Tables[0].Rows[0]["Proj_Client_Contact"].ToString();
                model.Proj_Client_Company = ds.Tables[0].Rows[0]["Proj_Client_Company"].ToString();
                model.Proj_Continuation = (bool)ds.Tables[0].Rows[0]["Proj_Continuation"];
                model.Proj_Description = ds.Tables[0].Rows[0]["Proj_Description"].ToString();
                model.Proj_Skills_Required = ds.Tables[0].Rows[0]["Proj_Skills_Required"].ToString();
                model.Proj_Context = ds.Tables[0].Rows[0]["Proj_Context"].ToString();
                model.Proj_Goals = ds.Tables[0].Rows[0]["Proj_Goals"].ToString();
                model.Proj_Features = ds.Tables[0].Rows[0]["Proj_Features"].ToString();
                model.Proj_Challenges = ds.Tables[0].Rows[0]["Proj_Challenges"].ToString();
                model.Proj_Opportunities = ds.Tables[0].Rows[0]["Proj_Opportunities"].ToString();
                model.Proj_Presenter = ds.Tables[0].Rows[0]["Proj_Presenter"].ToString();

                model.Proj_Valid_Dates = ds.Tables[0].Rows[0]["Proj_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Proj_Update_Time"].ToString()))
                {
                    model.Proj_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Proj_Update_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static bool IsExistName(string sName, int trimester_Id)
        {
            bool bExist = false;
            string sql = "select * from PSS_Project where Proj_Title='" + sName + "' and Proj_Trimester_Id=" + trimester_Id;
            bExist = SqlHelper.ExecuteBySql(sql);
            return bExist;
        }
        public static void Save(Project model)
        {
            string sql = "select * from PSS_Project where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            DataRow dr = ds.Tables["PSS_Project"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(Proj_Id) from PSS_Project");
            dr["Proj_Id"] = ++maxId;
            dr["Proj_Title"] = model.Proj_Title;
            dr["Proj_Staff_Contact"] = model.Proj_Staff_Contact;
            dr["Proj_Client_Contact"] = model.Proj_Client_Contact;
            dr["Proj_Client_Company"] = model.Proj_Client_Company;
            dr["Proj_Valid_Dates"] = model.Proj_Valid_Dates;
            dr["Proj_Students_Num"] = model.Proj_Students_Num;
            dr["Proj_Continuation"] = model.Proj_Continuation;
            dr["Proj_Description"] = model.Proj_Description;
            dr["Proj_Skills_Required"] = model.Proj_Skills_Required;
            dr["Proj_Context"] = model.Proj_Context;
            dr["Proj_Goals"] = model.Proj_Goals;
            dr["Proj_Features"] = model.Proj_Features;
            dr["Proj_Challenges"] = model.Proj_Challenges;
            dr["Proj_Opportunities"] = model.Proj_Opportunities;
            dr["Proj_Trimester_Id"] = model.Proj_Trimester_Id;
            dr["Proj_Update_Time"] = model.Proj_Update_Time;
            dr["Proj_Presenter"] = model.Proj_Presenter;

            ds.Tables["PSS_Project"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Project");
            if (ds != null)
                ds.Dispose();
        }
        public static void Update(Project model)
        {
            string sql = "select * from PSS_Project where Proj_Id='" + model.Proj_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            DataRow dr = ds.Tables["PSS_Project"].Rows[0];

            dr["Proj_Title"] = model.Proj_Title;
            dr["Proj_Staff_Contact"] = model.Proj_Staff_Contact;
            dr["Proj_Client_Contact"] = model.Proj_Client_Contact;
            dr["Proj_Client_Company"] = model.Proj_Client_Company;
            dr["Proj_Valid_Dates"] = model.Proj_Valid_Dates;
            dr["Proj_Students_Num"] = model.Proj_Students_Num;
            dr["Proj_Continuation"] = model.Proj_Continuation;
            dr["Proj_Description"] = model.Proj_Description;
            dr["Proj_Skills_Required"] = model.Proj_Skills_Required;
            dr["Proj_Context"] = model.Proj_Context;
            dr["Proj_Goals"] = model.Proj_Goals;
            dr["Proj_Features"] = model.Proj_Features;
            dr["Proj_Challenges"] = model.Proj_Challenges;
            dr["Proj_Opportunities"] = model.Proj_Opportunities;
            dr["Proj_Trimester_Id"] = model.Proj_Trimester_Id;
            dr["Proj_Update_Time"] = model.Proj_Update_Time;
            dr["Proj_Presenter"] = model.Proj_Presenter;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Project");
            if (ds != null)
                ds.Dispose();
        }

        public static void SaveList(List<Project> list)
        {
            string sql = "select * from PSS_Project where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            DataRow dr =null;
            int maxId = SqlHelper.GetMaxId("select max(Proj_Id) from PSS_Project");
            foreach (Project model in list)
            {
                dr = ds.Tables["PSS_Project"].NewRow();
                dr["Proj_Id"] = ++maxId;
                dr["Proj_Title"] = model.Proj_Title;
                dr["Proj_Staff_Contact"] = model.Proj_Staff_Contact;
                dr["Proj_Client_Contact"] = model.Proj_Client_Contact;
                dr["Proj_Client_Company"] = model.Proj_Client_Company;
                dr["Proj_Valid_Dates"] = model.Proj_Valid_Dates;
                dr["Proj_Students_Num"] = model.Proj_Students_Num;
                dr["Proj_Continuation"] = model.Proj_Continuation;
                dr["Proj_Description"] = model.Proj_Description;
                dr["Proj_Skills_Required"] = model.Proj_Skills_Required;
                dr["Proj_Context"] = model.Proj_Context;
                dr["Proj_Goals"] = model.Proj_Goals;
                dr["Proj_Features"] = model.Proj_Features;
                dr["Proj_Challenges"] = model.Proj_Challenges;
                dr["Proj_Opportunities"] = model.Proj_Opportunities;
                dr["Proj_Trimester_Id"] = model.Proj_Trimester_Id;
                dr["Proj_Update_Time"] = model.Proj_Update_Time;
                dr["Proj_Presenter"] = model.Proj_Presenter;

                ds.Tables["PSS_Project"].Rows.Add(dr);
            }
            SqlHelper.UpdateDataSet(ds, sql, "PSS_Project");
            if (ds != null)
                ds.Dispose();
        }
        public static void UpdateList(List<Project> list)
        {
            string idList = null;
            if (list != null && list.Count() > 0)
            {
                foreach (Project user in list)
                {
                    if (!string.IsNullOrEmpty(idList))
                        idList += ",";
                    idList += user.Proj_Id;
                }
            }
            string sql = "select * from PSS_Project where Proj_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            foreach (Project model in list)
            {
                foreach (DataRow dr in ds.Tables["PSS_Project"].Rows)
                {
                    if (model.Proj_Id.ToString() == dr["Proj_Id"].ToString())
                    {
                        dr["Proj_Title"] = model.Proj_Title;
                        dr["Proj_Staff_Contact"] = model.Proj_Staff_Contact;
                        dr["Proj_Client_Contact"] = model.Proj_Client_Contact;
                        dr["Proj_Client_Company"] = model.Proj_Client_Company;
                        dr["Proj_Valid_Dates"] = model.Proj_Valid_Dates;
                        dr["Proj_Students_Num"] = model.Proj_Students_Num;
                        dr["Proj_Continuation"] = model.Proj_Continuation;
                        dr["Proj_Description"] = model.Proj_Description;
                        dr["Proj_Skills_Required"] = model.Proj_Skills_Required;
                        dr["Proj_Context"] = model.Proj_Context;
                        dr["Proj_Goals"] = model.Proj_Goals;
                        dr["Proj_Features"] = model.Proj_Features;
                        dr["Proj_Challenges"] = model.Proj_Challenges;
                        dr["Proj_Opportunities"] = model.Proj_Opportunities;
                        dr["Proj_Trimester_Id"] = model.Proj_Trimester_Id;
                        dr["Proj_Update_Time"] = model.Proj_Update_Time;
                        dr["Proj_Presenter"] = model.Proj_Presenter;
                    }
                }
            }
            SqlHelper.UpdateDataSet(ds, sql, "PSS_Project");
            if (ds != null)
                ds.Dispose();
        }
        public static void Delete(Project model)
        {
            string sql = "select * from PSS_Project where Proj_Id='" + model.Proj_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            DataRow dr = ds.Tables["PSS_Project"].Rows[0];
            dr.Delete();

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Project");
            if (ds != null)
                ds.Dispose();

        }

        public static List<Project> GetList()
        {
            List<Project> list = new List<Project>();
            Project model = null;
            string sql = "select * from PSS_Project";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            foreach (DataRow dr in ds.Tables["PSS_Project"].Rows)
            {
                model = new Project();

                if (!string.IsNullOrEmpty(dr["Proj_Id"].ToString()))
                {
                    model.Proj_Id = int.Parse(dr["Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Trimester_Id"].ToString()))
                {
                    model.Proj_Trimester_Id = int.Parse(dr["Proj_Trimester_Id"].ToString());
                }
                model.Proj_Students_Num = dr["Proj_Students_Num"].ToString();

                model.Proj_Title = dr["Proj_Title"].ToString();
                model.Proj_Staff_Contact = dr["Proj_Staff_Contact"].ToString();
                model.Proj_Client_Contact = dr["Proj_Client_Contact"].ToString();
                model.Proj_Client_Company = dr["Proj_Client_Company"].ToString();
                model.Proj_Continuation = (bool)dr["Proj_Continuation"];
                model.Proj_Description = dr["Proj_Description"].ToString();
                model.Proj_Skills_Required = dr["Proj_Skills_Required"].ToString();
                model.Proj_Context = dr["Proj_Context"].ToString();
                model.Proj_Goals = dr["Proj_Goals"].ToString();
                model.Proj_Features = dr["Proj_Features"].ToString();
                model.Proj_Challenges = dr["Proj_Challenges"].ToString();
                model.Proj_Opportunities = dr["Proj_Opportunities"].ToString();
                model.Proj_Presenter = dr["Proj_Presenter"].ToString();

                model.Proj_Valid_Dates = dr["Proj_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(dr["Proj_Update_Time"].ToString()))
                {
                    model.Proj_Update_Time = DateTime.Parse(dr["Proj_Update_Time"].ToString());
                    model.Update_Time = model.Proj_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<Project> GetList(string idList)
        {
            List<Project> list = new List<Project>();
            Project model = null;
            string sql = "select * from PSS_Project where Proj_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Project");
            foreach (DataRow dr in ds.Tables["PSS_Project"].Rows)
            {
                model = new Project();

                if (!string.IsNullOrEmpty(dr["Proj_Id"].ToString()))
                {
                    model.Proj_Id = int.Parse(dr["Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Trimester_Id"].ToString()))
                {
                    model.Proj_Trimester_Id = int.Parse(dr["Proj_Trimester_Id"].ToString());
                }
                model.Proj_Students_Num = dr["Proj_Students_Num"].ToString();

                model.Proj_Title = dr["Proj_Title"].ToString();
                model.Proj_Staff_Contact = dr["Proj_Staff_Contact"].ToString();
                model.Proj_Client_Contact = dr["Proj_Client_Contact"].ToString();
                model.Proj_Client_Company = dr["Proj_Client_Company"].ToString();
                model.Proj_Continuation = (bool)dr["Proj_Continuation"];
                model.Proj_Description = dr["Proj_Description"].ToString();
                model.Proj_Skills_Required = dr["Proj_Skills_Required"].ToString();
                model.Proj_Context = dr["Proj_Context"].ToString();
                model.Proj_Goals = dr["Proj_Goals"].ToString();
                model.Proj_Features = dr["Proj_Features"].ToString();
                model.Proj_Challenges = dr["Proj_Challenges"].ToString();
                model.Proj_Opportunities = dr["Proj_Opportunities"].ToString();
                model.Proj_Presenter = dr["Proj_Presenter"].ToString();

                model.Proj_Valid_Dates = dr["Proj_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(dr["Proj_Update_Time"].ToString()))
                {
                    model.Proj_Update_Time = DateTime.Parse(dr["Proj_Update_Time"].ToString());
                    model.Update_Time = model.Proj_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }

        public static List<Project> GetList(Paging paging, string order, string sort, int trimesterId, string queryWord)
        {
            List<Project> list = new List<Project>();
            Project model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_Project","Proj_Trimester_Id",trimesterId, paging, order, sort);
            foreach (DataRow dr in ds.Tables["PSS_Project"].Rows)
            {
                model = new Project();

                if (!string.IsNullOrEmpty(dr["Proj_Id"].ToString()))
                {
                    model.Proj_Id = int.Parse(dr["Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Trimester_Id"].ToString()))
                {
                    model.Proj_Trimester_Id = int.Parse(dr["Proj_Trimester_Id"].ToString());
                }
                model.Proj_Students_Num = dr["Proj_Students_Num"].ToString();

                model.Proj_Title = dr["Proj_Title"].ToString();
                model.Proj_Staff_Contact = dr["Proj_Staff_Contact"].ToString();
                model.Proj_Client_Contact = dr["Proj_Client_Contact"].ToString();
                model.Proj_Client_Company = dr["Proj_Client_Company"].ToString();
                model.Proj_Continuation = (bool)dr["Proj_Continuation"];
                model.Proj_Description = dr["Proj_Description"].ToString();
                model.Proj_Skills_Required = dr["Proj_Skills_Required"].ToString();
                model.Proj_Context = dr["Proj_Context"].ToString();
                model.Proj_Goals = dr["Proj_Goals"].ToString();
                model.Proj_Features = dr["Proj_Features"].ToString();
                model.Proj_Challenges = dr["Proj_Challenges"].ToString();
                model.Proj_Opportunities = dr["Proj_Opportunities"].ToString();
                model.Proj_Presenter = dr["Proj_Presenter"].ToString();

                model.Proj_Valid_Dates = dr["Proj_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(dr["Proj_Update_Time"].ToString()))
                {
                    model.Proj_Update_Time = DateTime.Parse(dr["Proj_Update_Time"].ToString());
                    model.Update_Time = model.Proj_Update_Time.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
    }
}