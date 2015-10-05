using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;

namespace PSS_Weltec.DAL
{
    public class IdeaDiscussionService
    {
        public static void Save(Idea_Discussion model)
        {
            string sql = "select * from PSS_Idea_Discussion where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Discussion");
            DataRow dr = ds.Tables["PSS_Idea_Discussion"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(Idea_Disc_Id) from PSS_Idea_Discussion");
            dr["Idea_Disc_Id"] = ++maxId;
            dr["Idea_Disc_User_Id"] = model.Idea_Disc_User_Id;
            dr["Idea_Disc_Idea_Id"] = model.Idea_Disc_Idea_Id;
            dr["Idea_Disc_Time"] = model.Idea_Disc_Time;
            dr["Idea_Disc_Content"] = model.Idea_Disc_Content;

            ds.Tables["PSS_Idea_Discussion"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Idea_Discussion");
            if (ds != null)
                ds.Dispose();
        }
        public static List<Idea_Discussion> GetList()
        {
            List<Idea_Discussion> list = new List<Idea_Discussion>();
            Idea_Discussion model = null;
            string sql = "select * from PSS_Idea_Discussion";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Discussion");
            foreach (DataRow dr in ds.Tables["PSS_Idea_Discussion"].Rows)
            {
                model = new Idea_Discussion();

                if (!string.IsNullOrEmpty(dr["Idea_Disc_Id"].ToString()))
                {
                    model.Idea_Disc_Id = int.Parse(dr["Idea_Disc_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Disc_User_Id"].ToString()))
                {
                    model.Idea_Disc_User_Id = int.Parse(dr["Idea_Disc_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Disc_Idea_Id"].ToString()))
                {
                    model.Idea_Disc_Idea_Id = int.Parse(dr["Idea_Disc_Idea_Id"].ToString());
                }
                model.Idea_Disc_Content = dr["Idea_Disc_Content"].ToString();

                if (!string.IsNullOrEmpty(dr["Idea_Disc_Time"].ToString()))
                {
                    model.Idea_Disc_Time = DateTime.Parse(dr["Idea_Disc_Time"].ToString());
                    model.Disc_Time = model.Idea_Disc_Time.ToString("dd/MM/yyyy HH:mm:ss");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<Idea_Discussion> GetList(int idea_Id)
        {
            List<Idea_Discussion> list = new List<Idea_Discussion>();
            Idea_Discussion model = null;
            string sql = "select * from PSS_Idea_Discussion where Idea_Disc_Idea_Id = " + idea_Id + " order by Idea_Disc_Time asc";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Idea_Discussion");
            foreach (DataRow dr in ds.Tables["PSS_Idea_Discussion"].Rows)
            {
                model = new Idea_Discussion();

                if (!string.IsNullOrEmpty(dr["Idea_Disc_Id"].ToString()))
                {
                    model.Idea_Disc_Id = int.Parse(dr["Idea_Disc_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Disc_User_Id"].ToString()))
                {
                    model.Idea_Disc_User_Id = int.Parse(dr["Idea_Disc_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Idea_Disc_Idea_Id"].ToString()))
                {
                    model.Idea_Disc_Idea_Id = int.Parse(dr["Idea_Disc_Idea_Id"].ToString());
                }
                model.Idea_Disc_Content = dr["Idea_Disc_Content"].ToString();

                if (!string.IsNullOrEmpty(dr["Idea_Disc_Time"].ToString()))
                {
                    model.Idea_Disc_Time = DateTime.Parse(dr["Idea_Disc_Time"].ToString());
                    model.Disc_Time = model.Idea_Disc_Time.ToString("dd/MM/yyyy HH:mm:ss");
                }
                list.Add(model);
            };
            return list;
        }
    }
}