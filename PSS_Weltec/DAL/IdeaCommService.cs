using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;

namespace PSS_Weltec.DAL
{
    public class IdeaCommService
    {
        public static Idea_Comment GetModel(int id)
        {
            string sql = "select * from PSS_Idea_Comment where Idea_Comm_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Comment");
            Idea_Comment model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Idea_Comment();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Comm_Id"].ToString()))
                {
                    model.Idea_Comm_Id = int.Parse(ds.Tables[0].Rows[0]["Idea_Comm_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Comm_Idea_Id"].ToString()))
                {
                    model.Idea_Comm_Idea_Id = int.Parse(ds.Tables[0].Rows[0]["Idea_Comm_Idea_Id"].ToString());
                }
                model.Idea_Comm_Content = ds.Tables[0].Rows[0]["Idea_Comm_Content"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Idea_Comm_Time"].ToString()))
                {
                    model.Idea_Comm_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Idea_Comm_Time"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }
        public static void Save(Idea_Comment model)
        {
            string sql = "select * from PSS_Idea_Comment where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Comment");
            DataRow dr = ds.Tables["PSS_Idea_Comment"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(Idea_Comm_Id) from PSS_Idea_Comment");
            dr["Idea_Comm_Id"] = ++maxId;
            dr["Idea_Comm_Idea_Id"] = model.Idea_Comm_Idea_Id;
            dr["Idea_Comm_Time"] = model.Idea_Comm_Time;
            dr["Idea_Comm_Content"] = model.Idea_Comm_Content;

            ds.Tables["PSS_Idea_Comment"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea_Comment");
            if (ds != null)
                ds.Dispose();
        }
        public static void Update(Idea_Comment model)
        {
            string sql = "select * from PSS_Idea_Comment where Idea_Comm_Id='" + model.Idea_Comm_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Comment");
            DataRow dr = ds.Tables["PSS_Idea_Comment"].Rows[0];

            
            dr["Idea_Comm_Idea_Id"] = model.Idea_Comm_Idea_Id;
            dr["Idea_Comm_Time"] = model.Idea_Comm_Time;
            dr["Idea_Comm_Content"] = model.Idea_Comm_Content;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea_Comment");
            if (ds != null)
                ds.Dispose();
        }
        public static List<Idea_Comment> GetList(int idea_Id)
        {
            List<Idea_Comment> list = new List<Idea_Comment>();
            Idea_Comment model = null;
            string sql = "select * from PSS_Idea_Comment where Idea_Comm_Idea_Id = " + idea_Id + " order by Idea_Comm_Time asc";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Comment");
            foreach (DataRow dr in ds.Tables["PSS_Idea_Comment"].Rows)
            {
                model = new Idea_Comment();

                if (!string.IsNullOrEmpty(dr["Idea_Comm_Id"].ToString()))
                {
                    model.Idea_Comm_Id = int.Parse(dr["Idea_Comm_Id"].ToString());
                }
                model.Idea_Comm_Content = dr["Idea_Comm_Content"].ToString();

                if (!string.IsNullOrEmpty(dr["Idea_Comm_Time"].ToString()))
                {
                    model.Idea_Comm_Time = DateTime.Parse(dr["Idea_Comm_Time"].ToString());
                    model.Comm_Time = model.Idea_Comm_Time.ToString("dd/MM/yyyy HH:mm:ss");
                }
                list.Add(model);
            };
            return list;
        }
    }
}