using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.DAL
{
    public class SqlHelper
    {
        private static string con = @"server=.\MSSQL2012;database=PSS_Weltec;uid=sa;pwd=123";//Link Database;
        public static SqlConnection myConn = null;
        public static void Initialization()
        {
            try
            {
                myConn = new SqlConnection(con);
                myConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Dispose()
        {
            if (myConn != null)
                myConn.Close();
        }
        /// <summary>
        /// 根据sql语句获取DataReader是否有值；
        /// Check whether DataReader is null or not.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool HasRecord(string sql)
        {
            bool breturn = false;
            try
            {
                SqlCommand com = new SqlCommand(sql, myConn);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                    breturn = true;
                com.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return breturn;
        }
        /// <summary>
        /// 根据sql语句获取ds；
        /// Get ds by sql.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSetBySql(string sql, string tableName)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, myConn);
                da.Fill(ds, tableName);
                da.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }
        }
        /// <summary>
        /// 根据sql语句更新ds；
        /// Update ds 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static void UpdateDataSet(DataSet ds, string sql, string tableName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder();
            try
            {
                da.SelectCommand = new SqlCommand(sql, myConn);
                cb.DataAdapter = da;
                //da.InsertCommand = cb.GetInsertCommand();
                //da.UpdateCommand = cb.GetUpdateCommand();
                //da.DeleteCommand = cb.GetDeleteCommand();
                da.Update(ds.Tables[tableName]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.Dispose();
                cb.Dispose();
            }
        }
        /// <summary>
        /// 获取表中id最大值；
        /// Get max(id)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetMaxId(string sql)
        {
            try
            {
                SqlCommand com = new SqlCommand(sql, myConn);
                SqlDataReader reader = com.ExecuteReader();
                int idMax = 0;
                if (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader[0].ToString()))
                        idMax = (int)reader[0];
                }
                reader.Close();
                com.Dispose();
                return idMax;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取表中符合条件的行数；
        /// Get counts by sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetCount(string sql)
        {
            try
            {
                int count = 0;
                SqlCommand com = new SqlCommand(sql, myConn);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                    count = (int)reader[0];
                reader.Close();
                com.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 判断是否有重复值；
        /// Judge whether there is a repeat data.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteBySql(string sql)
        {
            bool bExist = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = myConn;
                cmd.CommandText = sql;
                if (cmd.ExecuteScalar() != null)
                    bExist = true;
                return bExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        /// <summary>
        /// encryption and deciphering
        /// </summary>
        /// <param name="Send_String"></param>
        /// <returns></returns>
        #region Encryption
        public static string Fun_Secret(string Send_String)
        {
            byte[] Secret_Byte = UTF8Encoding.UTF8.GetBytes(Send_String);
            string Secret_String = Convert.ToBase64String(Secret_Byte);
            return Secret_String;
        }
        #endregion

        #region Deciphering
        public static string Fun_UnSecret(string Get_String)
        {
            byte[] UnSecret_Byte = Convert.FromBase64String(Get_String);
            string UnSecret_String = UTF8Encoding.UTF8.GetString(UnSecret_Byte);
            return UnSecret_String;
        }
        #endregion

        /// <summary>
        /// Paging
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet GetListByPage(String tableName,Paging paging,string order, string sort)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                string sql="select * from (select *, ROW_NUMBER() OVER(Order by"+" "+ order+" "+sort+ ") as RowNumber from"+" "+tableName+" as a) as b where RowNumber between" +" "+((paging.GetCurrentPage()-1)*paging.GetPageSize()+1)+" AND"+" "+ paging.GetCurrentPage()*paging.GetPageSize() +" "+"ORDER BY"+" "+order+" "+ sort+"";
                int count = GetCount("select count(*) from "+tableName);
                paging.SetRecordCount(count);
                SqlDataAdapter da = new SqlDataAdapter(sql, myConn);
                da.Fill(ds, tableName);
                da.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }
            return ds;
        }

        /// <summary>
        /// Paging Trimester
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet GetListByPage(String tableName,int trimesterId, Paging paging, string order, string sort)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                string sql = "select * from (select *, ROW_NUMBER() OVER(Order by" + " " + order + " " + sort + ") as RowNumber from" + " " + tableName + " as a where user_Trimester_Id=" + trimesterId + ") as b where RowNumber between" + " " + ((paging.GetCurrentPage() - 1) * paging.GetPageSize() + 1) + " AND" + " " + paging.GetCurrentPage() * paging.GetPageSize() + " " + "ORDER BY" + " " + order + " " + sort + "";
                int count = GetCount("select count(*) from " + tableName+" where user_Trimester_Id=" + trimesterId);
                paging.SetRecordCount(count);
                SqlDataAdapter da = new SqlDataAdapter(sql, myConn);
                da.Fill(ds, tableName);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }
            return ds;
        }

        /// <summary>
        /// Paging Trimester,Status
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet GetListByPage(String tableName, int trimesterId,string status, Paging paging, string order, string sort)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                string sql = "select * from (select *, ROW_NUMBER() OVER(Order by" + " " + order + " " + sort + ") as RowNumber from" + " " + tableName + " as a where user_Trimester_Id=" + trimesterId + " and user_Statue="+status+") as b where RowNumber between" + " " + ((paging.GetCurrentPage() - 1) * paging.GetPageSize() + 1) + " AND" + " " + paging.GetCurrentPage() * paging.GetPageSize() + " " + "ORDER BY" + " " + order + " " + sort + "";
                int count = GetCount("select count(*) from " + tableName + " where user_Trimester_Id=" + trimesterId + " and user_Statue="+status);
                paging.SetRecordCount(count);
                SqlDataAdapter da = new SqlDataAdapter(sql, myConn);
                da.Fill(ds, tableName);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }
            return ds;
        }
    }
}