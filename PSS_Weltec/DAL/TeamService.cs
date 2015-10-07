using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class TeamService
    {
        public static Team GetModel(int id)
        {
            string sql = "select * from PSS_Team where Team_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            Team model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Team();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Team_Id"].ToString()))
                {
                    model.Team_Id = int.Parse(ds.Tables[0].Rows[0]["Team_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Team_User_Id"].ToString()))
                {
                    model.Team_User_Id = int.Parse(ds.Tables[0].Rows[0]["Team_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Team_Proj_Id"].ToString()))
                {
                    model.Team_Proj_Id = int.Parse(ds.Tables[0].Rows[0]["Team_Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Team_Status"].ToString()))
                {
                    model.Team_Status = int.Parse(ds.Tables[0].Rows[0]["Team_Status"].ToString());
                }
                model.Team_Title = ds.Tables[0].Rows[0]["Team_Title"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Update_Time"].ToString()))
                {
                    model.Team_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Team_Update_Time"].ToString());
                    model.Update_Time = model.Team_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static void Save(Team model)
        {
            string sql = "select * from PSS_Team where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            DataRow dr = ds.Tables["PSS_Team"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(Team_Id) from PSS_Team");
            dr["Team_Id"] = ++maxId;
            dr["Team_User_Id"] = model.Team_User_Id;
            dr["Team_Proj_Id"] = model.Team_Proj_Id;
            dr["Team_Update_Time"] = model.Team_Update_Time;
            dr["Team_Title"] = model.Team_Title;
            dr["Team_Status"] = model.Team_Status;

            ds.Tables["PSS_Team"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Team");
            if (ds != null)
                ds.Dispose();
        }
        public static void Update(Team model)
        {
            string sql = "select * from PSS_Team where Team_Id='" + model.Team_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            DataRow dr = ds.Tables["PSS_Team"].Rows[0];

            dr["Team_User_Id"] = model.Team_User_Id;
            dr["Team_Proj_Id"] = model.Team_Proj_Id;
            dr["Team_Update_Time"] = model.Team_Update_Time;
            dr["Team_Title"] = model.Team_Title;
            dr["Team_Status"] = model.Team_Status;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Team");
            if (ds != null)
                ds.Dispose();
        }

        public static void SaveList(List<Team> list)
        {
            string sql = "select * from PSS_Team where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            DataRow dr = null;
            int maxId = SqlHelper.GetMaxId("select max(Team_Id) from PSS_Team");
            foreach (Team model in list)
            {
                dr = ds.Tables["PSS_Team"].NewRow();
                dr["Team_Id"] = ++maxId;
                dr["Team_User_Id"] = model.Team_User_Id;
                dr["Team_Proj_Id"] = model.Team_Proj_Id;
                dr["Team_Update_Time"] = model.Team_Update_Time;
                dr["Team_Title"] = model.Team_Title;
                dr["Team_Status"] = model.Team_Status;

                ds.Tables["PSS_Team"].Rows.Add(dr);
            }
            SqlHelper.UpdateDataSet(ds, sql, "PSS_Team");
            if (ds != null)
                ds.Dispose();
        }
        public static void UpdateList(List<Team> list)
        {
            string idList = null;
            if (list != null && list.Count() > 0)
            {
                foreach (Team user in list)
                {
                    if (!string.IsNullOrEmpty(idList))
                        idList += ",";
                    idList += user.Team_Id;
                }
            }
            string sql = "select * from PSS_Team where Team_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            foreach (Team model in list)
            {
                foreach (DataRow dr in ds.Tables["PSS_Team"].Rows)
                {
                    if (model.Team_Id.ToString() == dr["Team_Id"].ToString())
                    {
                        dr["Team_User_Id"] = model.Team_User_Id;
                        dr["Team_Proj_Id"] = model.Team_Proj_Id;
                        dr["Team_Update_Time"] = model.Team_Update_Time;
                        dr["Team_Title"] = model.Team_Title;
                        dr["Team_Status"] = model.Team_Status;
                    }
                }
            }
            SqlHelper.UpdateDataSet(ds, sql, "PSS_Team");
            if (ds != null)
                ds.Dispose();
        }
        public static void Delete(Team model)
        {
            string sql = "select * from PSS_Team where Team_Id='" + model.Team_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            DataRow dr = ds.Tables["PSS_Team"].Rows[0];
            dr.Delete();

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Team");
            if (ds != null)
                ds.Dispose();

        }

        public static List<Team> GetList()
        {
            List<Team> list = new List<Team>();
            Team model = null;
            string sql = "select * from PSS_Team";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            foreach (DataRow dr in ds.Tables["PSS_Team"].Rows)
            {
                model = new Team();

                if (!string.IsNullOrEmpty(dr["Team_Id"].ToString()))
                {
                    model.Team_Id = int.Parse(dr["Team_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_User_Id"].ToString()))
                {
                    model.Team_User_Id = int.Parse(dr["Team_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_Proj_Id"].ToString()))
                {
                    model.Team_Proj_Id = int.Parse(dr["Team_Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_Status"].ToString()))
                {
                    model.Team_Status = int.Parse(dr["Team_Status"].ToString());
                    if (model.Team_Status == 0)
                    {
                        model.Status = "UnAuthorized";
                    }
                    else if (model.Team_Status ==1)
                    {
                        model.Status = "Authorized";
                    }
                    else if (model.Team_Status == 2)
                    {
                        model.Status = "Bid";
                    }
                }
                model.Team_Title = dr["Team_Title"].ToString();

                if (!string.IsNullOrEmpty(dr["Team_Update_Time"].ToString()))
                {
                    model.Team_Update_Time = DateTime.Parse(dr["Team_Update_Time"].ToString());
                    model.Update_Time = model.Team_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<Team> GetList(string idList)
        {
            List<Team> list = new List<Team>();
            Team model = null;
            string sql = "select * from PSS_Team where Team_Id in (" + idList + ")";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Team");
            foreach (DataRow dr in ds.Tables["PSS_Team"].Rows)
            {
                model = new Team();

                if (!string.IsNullOrEmpty(dr["Team_Id"].ToString()))
                {
                    model.Team_Id = int.Parse(dr["Team_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_User_Id"].ToString()))
                {
                    model.Team_User_Id = int.Parse(dr["Team_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_Proj_Id"].ToString()))
                {
                    model.Team_Proj_Id = int.Parse(dr["Team_Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_Status"].ToString()))
                {
                    model.Team_Status = int.Parse(dr["Team_Status"].ToString());
                    if (model.Team_Status == 0)
                    {
                        model.Status = "UnAuthorized";
                    }
                    else if (model.Team_Status == 1)
                    {
                        model.Status = "Authorized";
                    }
                    else if (model.Team_Status == 2)
                    {
                        model.Status = "Bid";
                    }
                }
                model.Team_Title = dr["Team_Title"].ToString();

                if (!string.IsNullOrEmpty(dr["Team_Update_Time"].ToString()))
                {
                    model.Team_Update_Time = DateTime.Parse(dr["Team_Update_Time"].ToString());
                    model.Update_Time = model.Team_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
                list.Add(model);
            };
            return list;
        }

        public static List<Team> GetList(Paging paging, string order, string sort, string status, string queryWord)
        {
            List<Team> list = new List<Team>();
            Team model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_Team", "Team_Status", status, paging, order, sort);
            foreach (DataRow dr in ds.Tables["PSS_Team"].Rows)
            {
                model = new Team();

                if (!string.IsNullOrEmpty(dr["Team_Id"].ToString()))
                {
                    model.Team_Id = int.Parse(dr["Team_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_User_Id"].ToString()))
                {
                    model.Team_User_Id = int.Parse(dr["Team_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_Proj_Id"].ToString()))
                {
                    model.Team_Proj_Id = int.Parse(dr["Team_Proj_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Team_Status"].ToString()))
                {
                    model.Team_Status = int.Parse(dr["Team_Status"].ToString());
                    if (model.Team_Status == 0)
                    {
                        model.Status = "UnAuthorized";
                    }
                    else if (model.Team_Status == 1)
                    {
                        model.Status = "Authorized";
                    }
                    else if (model.Team_Status == 2)
                    {
                        model.Status = "Bid";
                    }
                }
                model.Team_Title = dr["Team_Title"].ToString();

                if (!string.IsNullOrEmpty(dr["Team_Update_Time"].ToString()))
                {
                    model.Team_Update_Time = DateTime.Parse(dr["Team_Update_Time"].ToString());
                    model.Update_Time = model.Team_Update_Time.ToString("dd/MM/yyyy HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
    }
}