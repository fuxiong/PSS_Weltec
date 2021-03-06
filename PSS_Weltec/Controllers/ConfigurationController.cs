﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PSS_Weltec.DAL;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.Controllers
{
    public class ConfigurationController : Controller
    {
        //
        // GET: /Configuration/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrimesterIndex()
        {
            return View();
        }

        public ActionResult TrimesterList(int? page, int? rows, string sort, string order, string queryWord)
        {
            #region Get paging condition
            Paging paging = new Paging();
            paging.SetPageSize(rows.HasValue ? rows.Value : Paging.DEFAULT_PAGE_SIZE); //pageRows;
            paging.SetCurrentPage(page.HasValue ? page.Value : 1); //pageNumber;
            #endregion

            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            List<Trimester> list = null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.TrimesterService.GetList(paging, sort, order, queryWord);
                if (list != null && list.Count() > 0)
                {
                    foreach (Trimester model in list)
                    {
                        jsonDataGridResult.rows.Add(model);
                    }
                    jsonDataGridResult.total = paging.GetRecordCount();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonDataGridResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrimesterEdit(int? id)
        {
            Trimester model = null;
            try
            {
                if (id.HasValue)
                {
                    model = TrimesterService.GetModel(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult TrimesterSave(Trimester model, int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                Trimester trimester = null;
                if (id.HasValue)
                {
                    trimester = TrimesterService.GetModel(id.Value);
                }
                else
                {
                    trimester = new Trimester();
                }

                trimester.tri_Name = model.tri_Name;
                trimester.tri_IsOpen = model.tri_IsOpen;
                trimester.tri_StartDate = model.tri_StartDate;
                trimester.tri_EndDate = model.tri_EndDate;

                if (id.HasValue)
                {
                    TrimesterService.Update(trimester);
                }
                else
                {
                    TrimesterService.Save(trimester);
                }
                jsonResult.result = true;
                jsonResult.message = "";
            }
            catch (Exception ex)
            {
                jsonResult.result = false;
                jsonResult.message = ex.Message;
            }
            string result = JsonConvert.SerializeObject(jsonResult);
            return Content(result);
        }

        public ActionResult TrimesterDelete(int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                if (id.HasValue)
                {
                    Trimester model = TrimesterService.GetModel(id.Value);
                    TrimesterService.Delete(model);
                    jsonResult.result = true;
                    jsonResult.message = "";
                }
                else
                {
                    jsonResult.result = false;
                    jsonResult.message = "Id is null！";
                }
            }
            catch (Exception ex)
            {
                jsonResult.result = false;
                jsonResult.message = ex.Message;
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewsIndex()
        {
            return View();
        }

        public ActionResult NewsList(int? page, int? rows, string sort, string order, string queryWord)
        {
            #region Get paging condition
            Paging paging = new Paging();
            paging.SetPageSize(rows.HasValue ? rows.Value : Paging.DEFAULT_PAGE_SIZE); //pageRows;
            paging.SetCurrentPage(page.HasValue ? page.Value : 1); //pageNumber;
            #endregion

            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            List<News> list = null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.NewsService.GetList(paging, sort, order, queryWord);
                if (list != null && list.Count() > 0)
                {
                    foreach (News model in list)
                    {
                        jsonDataGridResult.rows.Add(model);
                    }
                    jsonDataGridResult.total = paging.GetRecordCount();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonDataGridResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNewsList()
        {
            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            List<News> list = null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.NewsService.GetList("select top(5) * from PSS_News order by news_Id desc");//desc
                if (list != null && list.Count() > 0)
                {
                    foreach (News model in list)
                    {
                        jsonDataGridResult.rows.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonDataGridResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewsEdit(int? news_Id)
        {
            ViewData["news_Id"] = null;
            if (news_Id.HasValue)
                ViewData["news_Id"] = news_Id.Value;
            return View();
        }

        public ActionResult NewsLoad(int? id)
        {
            News model = null;
            try
            {
                if (id.HasValue)
                {
                    model = NewsService.GetModel(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult NewsSave(News model, int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                News news = null;
                if (id.HasValue)
                {
                    news = NewsService.GetModel(id.Value);
                }
                else
                {
                    news = new News();
                }
                news.news_Title = model.news_Title;
                news.news_Content = base.Server.UrlDecode(model.news_Content);
                news.news_Update_Time = DateTime.Now;

                if (id.HasValue)
                {
                    NewsService.Update(news);
                }
                else
                {
                    NewsService.Save(news);
                }
                jsonResult.result = true;
                jsonResult.message = "";
            }
            catch (Exception ex)
            {
                jsonResult.result = false;
                jsonResult.message = ex.Message;
            }
            string result = JsonConvert.SerializeObject(jsonResult);
            return Content(result);
        }

        public ActionResult NewsDelete(int? news_Id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                if (news_Id.HasValue)
                {
                    News model = NewsService.GetModel(news_Id.Value);
                    NewsService.Delete(model);
                    jsonResult.result = true;
                    jsonResult.message = "";
                }
                else
                {
                    jsonResult.result = false;
                    jsonResult.message = "Id is null！";
                }
            }
            catch (Exception ex)
            {
                jsonResult.result = false;
                jsonResult.message = ex.Message;
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}
