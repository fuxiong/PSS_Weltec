using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class IdeaService
    {
        public static Idea GetModel(string sName)
        {
            string sql = "select * from PSS_Idea where Idea_Title='" + sName + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            Idea model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Idea();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Id"].ToString()))
                {
                    model.Idea_Id = int.Parse(ds.Tables[0].Rows[0]["Idea_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Trimester_Id"].ToString()))
                {
                    model.Idea_Trimester_Id = int.Parse(ds.Tables[0].Rows[0]["Idea_Trimester_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Status"].ToString()))
                {
                    model.Idea_Status = int.Parse(ds.Tables[0].Rows[0]["Idea_Status"].ToString());
                }

                model.Idea_Students_Num = ds.Tables[0].Rows[0]["Idea_Students_Num"].ToString();
                model.Idea_Title = ds.Tables[0].Rows[0]["Idea_Title"].ToString();
                model.Idea_Staff_Contact = ds.Tables[0].Rows[0]["Idea_Staff_Contact"].ToString();
                model.Idea_Client_Contact = ds.Tables[0].Rows[0]["Idea_Client_Contact"].ToString();
                model.Idea_Client_Company = ds.Tables[0].Rows[0]["Idea_Client_Company"].ToString();
                model.Idea_Continuation = (bool)ds.Tables[0].Rows[0]["Idea_Continuation"];
                model.Idea_Description = ds.Tables[0].Rows[0]["Idea_Description"].ToString();
                model.Idea_Skills_Required = ds.Tables[0].Rows[0]["Idea_Skills_Required"].ToString();
                model.Idea_Context = ds.Tables[0].Rows[0]["Idea_Context"].ToString();
                model.Idea_Goals = ds.Tables[0].Rows[0]["Idea_Goals"].ToString();
                model.Idea_Features = ds.Tables[0].Rows[0]["Idea_Features"].ToString();
                model.Idea_Challenges = ds.Tables[0].Rows[0]["Idea_Challenges"].ToString();
                model.Idea_Opportunities = ds.Tables[0].Rows[0]["Idea_Opportunities"].ToString();
                model.Idea_Presenter = ds.Tables[0].Rows[0]["Idea_Presenter"].ToString();
                model.Idea_Advisor_Contact = ds.Tables[0].Rows[0]["Idea_Advisor_Contact"].ToString();

                model.Idea_Valid_Dates = ds.Tables[0].Rows[0]["Idea_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Update_Time"].ToString()))
                {
                    model.Idea_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Idea_Update_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static Idea GetModel(int id)
        {
            string sql = "select * from PSS_Idea where Idea_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            Idea model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Idea();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Id"].ToString()))
                {
                    model.Idea_Id = int.Parse(ds.Tables[0].Rows[0]["Idea_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Trimester_Id"].ToString()))
                {
                    model.Idea_Trimester_Id = int.Parse(ds.Tables[0].Rows[0]["Idea_Trimester_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Status"].ToString()))
                {
                    model.Idea_Status = int.Parse(ds.Tables[0].Rows[0]["Idea_Status"].ToString());
                }
                model.Idea_Students_Num = ds.Tables[0].Rows[0]["Idea_Students_Num"].ToString();
                model.Idea_Title = ds.Tables[0].Rows[0]["Idea_Title"].ToString();
                model.Idea_Staff_Contact = ds.Tables[0].Rows[0]["Idea_Staff_Contact"].ToString();
                model.Idea_Client_Contact = ds.Tables[0].Rows[0]["Idea_Client_Contact"].ToString();
                model.Idea_Client_Company = ds.Tables[0].Rows[0]["Idea_Client_Company"].ToString();
                model.Idea_Continuation = (bool)ds.Tables[0].Rows[0]["Idea_Continuation"];
                model.Idea_Description = ds.Tables[0].Rows[0]["Idea_Description"].ToString();
                model.Idea_Skills_Required = ds.Tables[0].Rows[0]["Idea_Skills_Required"].ToString();
                model.Idea_Context = ds.Tables[0].Rows[0]["Idea_Context"].ToString();
                model.Idea_Goals = ds.Tables[0].Rows[0]["Idea_Goals"].ToString();
                model.Idea_Features = ds.Tables[0].Rows[0]["Idea_Features"].ToString();
                model.Idea_Challenges = ds.Tables[0].Rows[0]["Idea_Challenges"].ToString();
                model.Idea_Opportunities = ds.Tables[0].Rows[0]["Idea_Opportunities"].ToString();
                model.Idea_Presenter = ds.Tables[0].Rows[0]["Idea_Presenter"].ToString();
                model.Idea_Advisor_Contact = ds.Tables[0].Rows[0]["Idea_Advisor_Contact"].ToString();

                model.Idea_Valid_Dates = ds.Tables[0].Rows[0]["Idea_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Update_Time"].ToString()))
                {
                    model.Idea_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Idea_Update_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static bool IsExistName(string sName, int trimester_Id)
        {
            bool bExist = false;
            string sql = "select * from PSS_Idea where Idea_Title='" + sName + "' and Idea_Trimester_Id=" + trimester_Id;
            bExist = SqlHelper.ExecuteBySql(sql);
            return bExist;
        }
        public static void Save(Idea model)
        {
            string sql = "select * from PSS_Idea where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            DataRow dr = ds.Tables["PSS_Idea"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(Idea_Id) from PSS_Idea");
            dr["Idea_Id"] = ++maxId;
            dr["Idea_Title"] = model.Idea_Title;
            dr["Idea_Staff_Contact"] = model.Idea_Staff_Contact;
            dr["Idea_Client_Contact"] = model.Idea_Client_Contact;
            dr["Idea_Client_Company"] = model.Idea_Client_Company;
            dr["Idea_Valid_Dates"] = model.Idea_Valid_Dates;
            dr["Idea_Students_Num"] = model.Idea_Students_Num;
            dr["Idea_Continuation"] = model.Idea_Continuation;
            dr["Idea_Description"] = model.Idea_Description;
            dr["Idea_Skills_Required"] = model.Idea_Skills_Required;
            dr["Idea_Context"] = model.Idea_Context;
            dr["Idea_Goals"] = model.Idea_Goals;
            dr["Idea_Features"] = model.Idea_Features;
            dr["Idea_Challenges"] = model.Idea_Challenges;
            dr["Idea_Opportunities"] = model.Idea_Opportunities;
            dr["Idea_Trimester_Id"] = model.Idea_Trimester_Id;
            dr["Idea_Update_Time"] = model.Idea_Update_Time;
            dr["Idea_Presenter"] = model.Idea_Presenter;
            dr["Idea_Advisor_Contact"] = model.Idea_Advisor_Contact;
            dr["Idea_Status"] = model.Idea_Status;

            ds.Tables["PSS_Idea"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea");
            if (ds != null)
                ds.Dispose();
        }
        public static void Update(Idea model)
        {
            string sql = "select * from PSS_Idea where Idea_Id='" + model.Idea_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            DataRow dr = ds.Tables["PSS_Idea"].Rows[0];

            dr["Idea_Title"] = model.Idea_Title;
            dr["Idea_Staff_Contact"] = model.Idea_Staff_Contact;
            dr["Idea_Client_Contact"] = model.Idea_Client_Contact;
            dr["Idea_Client_Company"] = model.Idea_Client_Company;
            dr["Idea_Valid_Dates"] = model.Idea_Valid_Dates;
            dr["Idea_Students_Num"] = model.Idea_Students_Num;
            dr["Idea_Continuation"] = model.Idea_Continuation;
            dr["Idea_Description"] = model.Idea_Description;
            dr["Idea_Skills_Required"] = model.Idea_Skills_Required;
            dr["Idea_Context"] = model.Idea_Context;
            dr["Idea_Goals"] = model.Idea_Goals;
            dr["Idea_Features"] = model.Idea_Features;
            dr["Idea_Challenges"] = model.Idea_Challenges;
            dr["Idea_Opportunities"] = model.Idea_Opportunities;
            dr["Idea_Trimester_Id"] = model.Idea_Trimester_Id;
            dr["Idea_Update_Time"] = model.Idea_Update_Time;
            dr["Idea_Presenter"] = model.Idea_Presenter;
            dr["Idea_Advisor_Contact"] = model.Idea_Advisor_Contact;
            dr["Idea_Status"] = model.Idea_Status;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea");
            if (ds != null)
                ds.Dispose();
        }

        public static void SaveList(List<Idea> list)
        {
            string sql = "select * from PSS_Idea where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            DataRow dr = null;
            int maxId = SqlHelper.GetMaxId("select max(Idea_Id) from PSS_Idea");
            foreach (Idea model in list)
            {
                dr = ds.Tables["PSS_Idea"].NewRow();
                dr["Idea_Id"] = ++maxId;
                dr["Idea_Title"] = model.Idea_Title;
                dr["Idea_Staff_Contact"] = model.Idea_Staff_Contact;
                dr["Idea_Client_Contact"] = model.Idea_Client_Contact;
                dr["Idea_Client_Company"] = model.Idea_Client_Company;
                dr["Idea_Valid_Dates"] = model.Idea_Valid_Dates;
                dr["Idea_Students_Num"] = model.Idea_Students_Num;
                dr["Idea_Continuation"] = model.Idea_Continuation;
                dr["Idea_Description"] = model.Idea_Description;
                dr["Idea_Skills_Required"] = model.Idea_Skills_Required;
                dr["Idea_Context"] = model.Idea_Context;
                dr["Idea_Goals"] = model.Idea_Goals;
                dr["Idea_Features"] = model.Idea_Features;
                dr["Idea_Challenges"] = model.Idea_Challenges;
                dr["Idea_Opportunities"] = model.Idea_Opportunities;
                dr["Idea_Trimester_Id"] = model.Idea_Trimester_Id;
                dr["Idea_Update_Time"] = model.Idea_Update_Time;
                dr["Idea_Presenter"] = model.Idea_Presenter;
                dr["Idea_Advisor_Contact"] = model.Idea_Advisor_Contact;
                dr["Idea_Status"] = model.Idea_Status;

                ds.Tables["PSS_Idea"].Rows.Add(dr);
            }
            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea");
            if (ds != null)
                ds.Dispose();
        }
        public static void UpdateList(List<Idea> list)
        {
            string idList = null;
            if (list != null && list.Count() > 0)
            {
                foreach (Idea user in list)
                {
                    if (!string.IsNullOrEmpty(idList))
                        idList += ",";
                    idList += user.Idea_Id;
                }
            }
            string sql = "select * from PSS_Idea where Idea_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            foreach (Idea model in list)
            {
                foreach (DataRow dr in ds.Tables["PSS_Idea"].Rows)
                {
                    if (model.Idea_Id.ToString() == dr["Idea_Id"].ToString())
                    {
                        dr["Idea_Title"] = model.Idea_Title;
                        dr["Idea_Staff_Contact"] = model.Idea_Staff_Contact;
                        dr["Idea_Client_Contact"] = model.Idea_Client_Contact;
                        dr["Idea_Client_Company"] = model.Idea_Client_Company;
                        dr["Idea_Valid_Dates"] = model.Idea_Valid_Dates;
                        dr["Idea_Students_Num"] = model.Idea_Students_Num;
                        dr["Idea_Continuation"] = model.Idea_Continuation;
                        dr["Idea_Description"] = model.Idea_Description;
                        dr["Idea_Skills_Required"] = model.Idea_Skills_Required;
                        dr["Idea_Context"] = model.Idea_Context;
                        dr["Idea_Goals"] = model.Idea_Goals;
                        dr["Idea_Features"] = model.Idea_Features;
                        dr["Idea_Challenges"] = model.Idea_Challenges;
                        dr["Idea_Opportunities"] = model.Idea_Opportunities;
                        dr["Idea_Trimester_Id"] = model.Idea_Trimester_Id;
                        dr["Idea_Update_Time"] = model.Idea_Update_Time;
                        dr["Idea_Presenter"] = model.Idea_Presenter;
                        dr["Idea_Advisor_Contact"] = model.Idea_Advisor_Contact;
                        dr["Idea_Status"] = model.Idea_Status;
                    }
                }
            }
            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea");
            if (ds != null)
                ds.Dispose();
        }
        public static void Delete(Idea model)
        {
            string sql = "select * from PSS_Idea where Idea_Id='" + model.Idea_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            DataRow dr = ds.Tables["PSS_Idea"].Rows[0];
            dr.Delete();

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea");
            if (ds != null)
                ds.Dispose();

        }

        public static List<Idea> GetList()
        {
            List<Idea> list = new List<Idea>();
            Idea model = null;
            string sql = "select * from PSS_Idea";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            foreach (DataRow dr in ds.Tables["PSS_Idea"].Rows)
            {
                model = new Idea();

                if (!string.IsNullOrEmpty(dr["Idea_Id"].ToString()))
                {
                    model.Idea_Id = int.Parse(dr["Idea_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Trimester_Id"].ToString()))
                {
                    model.Idea_Trimester_Id = int.Parse(dr["Idea_Trimester_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Status"].ToString()))
                {
                    model.Idea_Status = int.Parse(dr["Idea_Status"].ToString());
                    if (model.Idea_Status == 0)
                    {
                        model.Status = "UnAuthorized";
                    }
                    else if (model.Idea_Status == 1)
                    {
                        model.Status = "Authorized";
                    }
                    else if (model.Idea_Status == 2)
                    {
                        model.Status = "Revise";
                    }
                }
                model.Idea_Students_Num = dr["Idea_Students_Num"].ToString();

                model.Idea_Title = dr["Idea_Title"].ToString();
                model.Idea_Staff_Contact = dr["Idea_Staff_Contact"].ToString();
                model.Idea_Client_Contact = dr["Idea_Client_Contact"].ToString();
                model.Idea_Client_Company = dr["Idea_Client_Company"].ToString();
                model.Idea_Continuation = (bool)dr["Idea_Continuation"];
                model.Idea_Description = dr["Idea_Description"].ToString();
                model.Idea_Skills_Required = dr["Idea_Skills_Required"].ToString();
                model.Idea_Context = dr["Idea_Context"].ToString();
                model.Idea_Goals = dr["Idea_Goals"].ToString();
                model.Idea_Features = dr["Idea_Features"].ToString();
                model.Idea_Challenges = dr["Idea_Challenges"].ToString();
                model.Idea_Opportunities = dr["Idea_Opportunities"].ToString();
                model.Idea_Presenter = dr["Idea_Presenter"].ToString();
                model.Idea_Advisor_Contact = dr["Idea_Advisor_Contact"].ToString();

                model.Idea_Valid_Dates = dr["Idea_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(dr["Idea_Update_Time"].ToString()))
                {
                    model.Idea_Update_Time = DateTime.Parse(dr["Idea_Update_Time"].ToString());
                    model.Update_Time = model.Idea_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<Idea> GetList(string idList)
        {
            List<Idea> list = new List<Idea>();
            Idea model = null;
            string sql = "select * from PSS_Idea where Idea_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea");
            foreach (DataRow dr in ds.Tables["PSS_Idea"].Rows)
            {
                model = new Idea();

                if (!string.IsNullOrEmpty(dr["Idea_Id"].ToString()))
                {
                    model.Idea_Id = int.Parse(dr["Idea_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Trimester_Id"].ToString()))
                {
                    model.Idea_Trimester_Id = int.Parse(dr["Idea_Trimester_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Status"].ToString()))
                {
                    model.Idea_Status = int.Parse(dr["Idea_Status"].ToString());
                    if (model.Idea_Status == 0)
                    {
                        model.Status = "UnAuthorized";
                    }
                    else if (model.Idea_Status == 1)
                    {
                        model.Status = "Authorized";
                    }
                    else if (model.Idea_Status == 2)
                    {
                        model.Status = "Revise";
                    }
                }
                model.Idea_Students_Num = dr["Idea_Students_Num"].ToString();

                model.Idea_Title = dr["Idea_Title"].ToString();
                model.Idea_Staff_Contact = dr["Idea_Staff_Contact"].ToString();
                model.Idea_Client_Contact = dr["Idea_Client_Contact"].ToString();
                model.Idea_Client_Company = dr["Idea_Client_Company"].ToString();
                model.Idea_Continuation = (bool)dr["Idea_Continuation"];
                model.Idea_Description = dr["Idea_Description"].ToString();
                model.Idea_Skills_Required = dr["Idea_Skills_Required"].ToString();
                model.Idea_Context = dr["Idea_Context"].ToString();
                model.Idea_Goals = dr["Idea_Goals"].ToString();
                model.Idea_Features = dr["Idea_Features"].ToString();
                model.Idea_Challenges = dr["Idea_Challenges"].ToString();
                model.Idea_Opportunities = dr["Idea_Opportunities"].ToString();
                model.Idea_Presenter = dr["Idea_Presenter"].ToString();
                model.Idea_Advisor_Contact = dr["Idea_Advisor_Contact"].ToString();

                model.Idea_Valid_Dates = dr["Idea_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(dr["Idea_Update_Time"].ToString()))
                {
                    model.Idea_Update_Time = DateTime.Parse(dr["Idea_Update_Time"].ToString());
                    model.Update_Time = model.Idea_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
                list.Add(model);
            };
            return list;
        }

        public static List<Idea> GetList(Paging paging, string order, string sort, int trimesterId, string queryWord)
        {
            List<Idea> list = new List<Idea>();
            Idea model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_Idea", "Idea_Trimester_Id", trimesterId, paging, order, sort);
            foreach (DataRow dr in ds.Tables["PSS_Idea"].Rows)
            {
                model = new Idea();

                if (!string.IsNullOrEmpty(dr["Idea_Id"].ToString()))
                {
                    model.Idea_Id = int.Parse(dr["Idea_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Trimester_Id"].ToString()))
                {
                    model.Idea_Trimester_Id = int.Parse(dr["Idea_Trimester_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Status"].ToString()))
                {
                    model.Idea_Status = int.Parse(dr["Idea_Status"].ToString());
                    if (model.Idea_Status == 0)
                    {
                        model.Status = "UnAuthorized";
                    }
                    else if (model.Idea_Status == 1)
                    {
                        model.Status = "Authorized";
                    }
                    else if (model.Idea_Status == 2)
                    {
                        model.Status = "Revise";
                    }
                }
                model.Idea_Students_Num = dr["Idea_Students_Num"].ToString();

                model.Idea_Title = dr["Idea_Title"].ToString();
                model.Idea_Staff_Contact = dr["Idea_Staff_Contact"].ToString();
                model.Idea_Client_Contact = dr["Idea_Client_Contact"].ToString();
                model.Idea_Client_Company = dr["Idea_Client_Company"].ToString();
                model.Idea_Continuation = (bool)dr["Idea_Continuation"];
                model.Idea_Description = dr["Idea_Description"].ToString();
                model.Idea_Skills_Required = dr["Idea_Skills_Required"].ToString();
                model.Idea_Context = dr["Idea_Context"].ToString();
                model.Idea_Goals = dr["Idea_Goals"].ToString();
                model.Idea_Features = dr["Idea_Features"].ToString();
                model.Idea_Challenges = dr["Idea_Challenges"].ToString();
                model.Idea_Opportunities = dr["Idea_Opportunities"].ToString();
                model.Idea_Presenter = dr["Idea_Presenter"].ToString();
                model.Idea_Advisor_Contact = dr["Idea_Advisor_Contact"].ToString();

                model.Idea_Valid_Dates = dr["Idea_Valid_Dates"].ToString();

                if (!string.IsNullOrEmpty(dr["Idea_Update_Time"].ToString()))
                {
                    model.Idea_Update_Time = DateTime.Parse(dr["Idea_Update_Time"].ToString());
                    model.Update_Time = model.Idea_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
    }
}