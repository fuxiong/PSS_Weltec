using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class NewsService
    {
        public static News GetModel(int id)
        {
            string sql = "select * from PSS_News where news_Id='" + id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_News");
            News model = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new News();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["news_Id"].ToString()))
                {
                    model.news_Id = int.Parse(ds.Tables[0].Rows[0]["news_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["news_User_Id"].ToString()))
                {
                    model.news_User_Id = int.Parse(ds.Tables[0].Rows[0]["news_User_Id"].ToString());
                }

                model.news_Content = ds.Tables[0].Rows[0]["news_Content"].ToString();
                model.news_Title = ds.Tables[0].Rows[0]["news_Title"].ToString();

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["news_Update_Time"].ToString()))
                {
                    model.news_Update_Time = DateTime.Parse(ds.Tables[0].Rows[0]["news_Update_Time"].ToString());
                    model.Update_Time = model.news_Update_Time.ToString("yyyy-MM-dd");
                }
            }
            if (ds != null)
                ds.Dispose();
            return model;
        }

        public static void Save(News model)
        {
            string sql = "select * from PSS_News where 1<>1";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_News");
            DataRow dr = ds.Tables["PSS_News"].NewRow();

            int maxId = SqlHelper.GetMaxId("select max(news_Id) from PSS_News");
            dr["news_Id"] = ++maxId;
            dr["news_User_Id"] = model.news_User_Id;
            dr["news_Content"] = model.news_Content;
            dr["news_Update_Time"] = model.news_Update_Time;
            dr["news_Title"] = model.news_Title;

            ds.Tables["PSS_News"].Rows.Add(dr);

            SqlHelper.UpdateDataSet(ds, sql, "PSS_News");
            if (ds != null)
                ds.Dispose();
        }

        public static void Update(News model)
        {
            string sql = "select * from PSS_News where news_Id='" + model.news_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_News");
            DataRow dr = ds.Tables["PSS_News"].Rows[0];

            dr["news_User_Id"] = model.news_User_Id;
            dr["news_Content"] = model.news_Content;
            dr["news_Update_Time"] = model.news_Update_Time;
            dr["news_Title"] = model.news_Title;

            SqlHelper.UpdateDataSet(ds, sql, "PSS_News");
            if (ds != null)
                ds.Dispose();
        }

        public static void Delete(News model)
        {
            string sql = "select * from PSS_News where news_Id='" + model.news_Id + "'";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_News");
            DataRow dr = ds.Tables["PSS_News"].Rows[0];
            dr.Delete();

            SqlHelper.UpdateDataSet(ds, sql, "PSS_News");
            if (ds != null)
                ds.Dispose();

        }

        public static List<News> GetList()
        {
            List<News> list = new List<News>();
            News model = null;
            string sql = "select * from PSS_News";
            DataSet ds = SqlHelper.GetDataSetBySql(sql, "PSS_News");
            foreach (DataRow dr in ds.Tables["PSS_News"].Rows)
            {
                model = new News();

                if (!string.IsNullOrEmpty(dr["news_Id"].ToString()))
                {
                    model.news_Id = int.Parse(dr["news_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["news_User_Id"].ToString()))
                {
                    model.news_User_Id = int.Parse(dr["news_User_Id"].ToString());
                }

                model.news_Content = dr["news_Content"].ToString();
                model.news_Title = dr["news_Title"].ToString();

                if (!string.IsNullOrEmpty(dr["news_Update_Time"].ToString()))
                {
                    model.news_Update_Time = DateTime.Parse(dr["news_Update_Time"].ToString());
                    model.Update_Time = model.news_Update_Time.ToString("yyyy-MM-dd");
                }
            };
            return list;
        }

        public static List<News> GetList(Paging paging, string order, string sort, string queryWord)
        {
            List<News> list = new List<News>();
            News model = null;
            DataSet ds = SqlHelper.GetListByPage("PSS_News", paging, order, sort);
            foreach (DataRow dr in ds.Tables["PSS_News"].Rows)
            {
                model = new News();

                if (!string.IsNullOrEmpty(dr["news_Id"].ToString()))
                {
                    model.news_Id = int.Parse(dr["news_Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["news_User_Id"].ToString()))
                {
                    model.news_User_Id = int.Parse(dr["news_User_Id"].ToString());
                }

                model.news_Content = dr["news_Content"].ToString();
                model.news_Title = dr["news_Title"].ToString();

                if (!string.IsNullOrEmpty(dr["news_Update_Time"].ToString()))
                {
                    model.news_Update_Time = DateTime.Parse(dr["news_Update_Time"].ToString());
                    model.Update_Time = model.news_Update_Time.ToString("yyyy-MM-dd");
                }
                list.Add(model);
            };
            return list;
        }
    }
}