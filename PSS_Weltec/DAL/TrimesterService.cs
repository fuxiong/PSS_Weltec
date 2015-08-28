using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class TrimesterService
    {
        public static Trimester GetModel(int id)
        {
            string sql = "select * from PSS_Trimester where tri_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Trimester");
            Trimester model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Trimester();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["tri_Id"].ToString()))
                {
                    model.tri_Id = int.Parse(ds.Tables[0].Rows[0]["tri_Id"].ToString());
                }

                model.tri_Name = ds.Tables[0].Rows[0]["tri_Name"].ToString();
                model.tri_IsOpen =(bool)ds.Tables[0].Rows[0]["tri_IsOpen"];

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["tri_StartDate"].ToString()))
                {
                    model.tri_StartDate = DateTime.Parse(ds.Tables[0].Rows[0]["tri_StartDate"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["tri_EndDate"].ToString()))
                {
                    model.tri_EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["tri_EndDate"].ToString());
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }

        public static void Save(Trimester model)
        {
            string sql = "select * from PSS_Trimester where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Trimester");
            DataRow dr = ds.Tables["PSS_Trimester"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(tri_Id) from PSS_Trimester");
            dr["tri_Id"] = ++maxId;
            dr["tri_Name"] = model.tri_Name;
            dr["tri_IsOpen"] = model.tri_IsOpen;
            dr["tri_StartDate"] = model.tri_StartDate;
            dr["tri_EndDate"] = model.tri_EndDate;

            ds.Tables["PSS_Trimester"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Trimester");
            if (ds != null)
                ds.Dispose();
        }

        public static void Update(Trimester model)
        {
            string sql = "select * from PSS_Trimester where tri_Id='" + model.tri_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Trimester");
            DataRow dr = ds.Tables["PSS_Trimester"].Rows[0];

            dr["tri_Name"] = model.tri_Name;
            dr["tri_IsOpen"] = model.tri_IsOpen;
            dr["tri_StartDate"] = model.tri_StartDate;
            dr["tri_EndDate"] = model.tri_EndDate;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Trimester");
            if (ds != null)
                ds.Dispose();
        }

        public static void Delete(Trimester model)
        {
            string sql = "select * from PSS_Trimester where tri_Id='" + model.tri_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Trimester");
            DataRow dr = ds.Tables["PSS_Trimester"].Rows[0];
            dr.Delete();

            SqlHelper.UpdateDataSet(ds, sql, "PSS_Trimester");
            if (ds != null)
                ds.Dispose();

        }

        public static List<Trimester> GetList()
        {
            List<Trimester> list = new List<Trimester>();
            Trimester model = null;
            string sql = "select * from PSS_Trimester";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_Trimester");
            foreach (DataRow dr in ds.Tables["PSS_Trimester"].Rows)
            {
                model = new Trimester();

                if (!string.IsNullOrEmpty(dr["tri_Id"].ToString()))
                {
                    model.tri_Id = int.Parse(dr["tri_Id"].ToString());
                }

                model.tri_Name = dr["tri_Name"].ToString();
                model.tri_IsOpen = (bool)dr["tri_IsOpen"];

                if (!string.IsNullOrEmpty(dr["tri_StartDate"].ToString()))
                {
                    model.tri_StartDate = DateTime.Parse(dr["tri_StartDate"].ToString());
                    model.StartDate_Time = model.tri_StartDate.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["tri_EndDate"].ToString()))
                {
                    model.tri_EndDate = DateTime.Parse(dr["tri_EndDate"].ToString());
                    model.EndDate_Time = model.tri_EndDate.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }

        public static List<Trimester> GetList(Paging paging, string order, string sort, string queryWord)
        {
            List<Trimester> list = new List<Trimester>();
            Trimester model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_Trimester", paging, order, sort);
            foreach (DataRow dr in ds.Tables["PSS_Trimester"].Rows)
            {
                model = new Trimester();

                if (!string.IsNullOrEmpty(dr["tri_Id"].ToString()))
                {
                    model.tri_Id = int.Parse(dr["tri_Id"].ToString());
                }

                model.tri_Name = dr["tri_Name"].ToString();
                model.tri_IsOpen = (bool)dr["tri_IsOpen"];

                if (!string.IsNullOrEmpty(dr["tri_StartDate"].ToString()))
                {
                    model.tri_StartDate = DateTime.Parse(dr["tri_StartDate"].ToString());
                    model.StartDate_Time = model.tri_StartDate.ToString("yyyy-MM-dd HH:mm");
                }
                if (!string.IsNullOrEmpty(dr["tri_EndDate"].ToString()))
                {
                    model.tri_EndDate = DateTime.Parse(dr["tri_EndDate"].ToString());
                    model.EndDate_Time = model.tri_EndDate.ToString("yyyy-MM-dd HH:mm");
                }
                list.Add(model);
            };
            return list;
        }
    }
}