using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class ProjDiscussionService
    {
        public static void Save(Proj_Discussion model)
        {
            string sql = "select * from PSS_Proj_Discussion where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Proj_Discussion");
            DataRow dr = ds.Tables["PSS_Proj_Discussion"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(Proj_Disc_Id) from PSS_Proj_Discussion");
            dr["Proj_Disc_Id"] = ++maxId;
            dr["Proj_Disc_User_Id"] = model.Proj_Disc_User_Id;
            dr["Proj_Disc_Proj_Id"] = model.Proj_Disc_Proj_Id;
            dr["Proj_Disc_Time"] = model.Proj_Disc_Time;
            dr["Proj_Disc_Content"] = model.Proj_Disc_Content;

            ds.Tables["PSS_Proj_Discussion"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Proj_Discussion");
            if (ds != null)
                ds.Dispose();
        }
        public static List<Proj_Discussion> GetList()
        {
            List<Proj_Discussion> list = new List<Proj_Discussion>();
            Proj_Discussion model = null;
            string sql = "select * from PSS_Proj_Discussion";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Proj_Discussion");
            foreach (DataRow dr in ds.Tables["PSS_Proj_Discussion"].Rows)
            {
                model = new Proj_Discussion();

                if (!string.IsNullOrEmpty(dr["Proj_Disc_Id"].ToString()))
                {
                    model.Proj_Disc_Id = int.Parse(dr["Proj_Disc_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Disc_User_Id"].ToString()))
                {
                    model.Proj_Disc_User_Id = int.Parse(dr["Proj_Disc_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Disc_Proj_Id"].ToString()))
                {
                    model.Proj_Disc_Proj_Id = int.Parse(dr["Proj_Disc_Proj_Id"].ToString());
                }
                model.Proj_Disc_Content = dr["Proj_Disc_Content"].ToString();

                if (!string.IsNullOrEmpty(dr["Proj_Disc_Time"].ToString()))
                {
                    model.Proj_Disc_Time = DateTime.Parse(dr["Proj_Disc_Time"].ToString());
                    model.Disc_Time = model.Proj_Disc_Time.ToString("dd/MM/yyyy HH:mm:ss");
                }
                list.Add(model);
            };
            return list;
        }
        public static List<Proj_Discussion> GetList(int proj_Id)
        {
            List<Proj_Discussion> list = new List<Proj_Discussion>();
            Proj_Discussion model = null;
            string sql = "select * from PSS_Proj_Discussion where Proj_Disc_Proj_Id = " + proj_Id + " order by Proj_Disc_Time asc";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Proj_Discussion");
            foreach (DataRow dr in ds.Tables["PSS_Proj_Discussion"].Rows)
            {
                model = new Proj_Discussion();

                if (!string.IsNullOrEmpty(dr["Proj_Disc_Id"].ToString()))
                {
                    model.Proj_Disc_Id = int.Parse(dr["Proj_Disc_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Disc_User_Id"].ToString()))
                {
                    model.Proj_Disc_User_Id = int.Parse(dr["Proj_Disc_User_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Proj_Disc_Proj_Id"].ToString()))
                {
                    model.Proj_Disc_Proj_Id = int.Parse(dr["Proj_Disc_Proj_Id"].ToString());
                }
                model.Proj_Disc_Content = dr["Proj_Disc_Content"].ToString();

                if (!string.IsNullOrEmpty(dr["Proj_Disc_Time"].ToString()))
                {
                    model.Proj_Disc_Time = DateTime.Parse(dr["Proj_Disc_Time"].ToString());
                    model.Disc_Time = model.Proj_Disc_Time.ToString("dd/MM/yyyy HH:mm:ss");
                }
                list.Add(model);
            };
            return list;
        }
    }
}