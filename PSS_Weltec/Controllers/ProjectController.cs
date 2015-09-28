using System;
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
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult ProjectIndex()
        {
            SqlHelper.Initialization();
            List<SelectListItem> listTrimester = new List<SelectListItem>();
            foreach (Trimester tri in TrimesterService.GetList().Where(item => item.tri_IsOpen == true))
            {
                listTrimester.Add(new SelectListItem { Text = tri.tri_Name, Value = tri.tri_Id.ToString() });
            }
            ViewData["listTrimester"] = listTrimester;

            return View();
        }

        public ActionResult ProjectList(int? page, int? rows, int trimesterId, string sort, string order, string queryWord)
        {
            #region Get paging condition
            Paging paging = new Paging();
            paging.SetPageSize(rows.HasValue ? rows.Value : Paging.DEFAULT_PAGE_SIZE); //pageRows;
            paging.SetCurrentPage(page.HasValue ? page.Value : 1); //pageNumber;
            #endregion

            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            List<Project> list = null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.ProjectService.GetList(paging, sort, order, trimesterId, queryWord);
                if (list != null && list.Count() > 0)
                {
                    foreach (Project project in list)
                    {
                        jsonDataGridResult.rows.Add(project);
                    }
                    jsonDataGridResult.total = paging.GetRecordCount();
                }
            }
            catch (Exception ex)
            {
                jsonDataGridResult.result = false;
                jsonDataGridResult.message = ex.Message;
            }
            return Json(jsonDataGridResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProjectEdit(int? id)
        {
            Project model = null;
            try
            {
                if (id.HasValue)
                {
                    model = ProjectService.GetModel(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProjectEditLoad(int? Proj_Id, int trimesterId)
        {
            Project model = new Project();
            model.Proj_Trimester_Id = trimesterId;
            if (Proj_Id.HasValue)
            {
                model = ProjectService.GetModel(Proj_Id.Value);
                model.Context = base.Server.UrlEncode(model.Proj_Context).Replace("+", "%20");
                model.Description = base.Server.UrlEncode(model.Proj_Description).Replace("+", "%20");
                model.Skills_Required = base.Server.UrlEncode(model.Proj_Skills_Required).Replace("+", "%20");
                model.Goals = base.Server.UrlEncode(model.Proj_Goals).Replace("+", "%20");
                model.Features = base.Server.UrlEncode(model.Proj_Features).Replace("+", "%20");
                model.Challenges = base.Server.UrlEncode(model.Proj_Challenges).Replace("+", "%20");
                model.Opportunities = base.Server.UrlEncode(model.Proj_Opportunities).Replace("+", "%20");
            }

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Yes", Value = "True" });
            list.Add(new SelectListItem { Text = "No", Value = "False" });
            ViewData["list"] = list;

            return View(model);
        }

        [HttpPost]
        public ContentResult ProjectSave(Project model, int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                Project project = null;
                if (id.HasValue)
                {
                    project = ProjectService.GetModel(id.Value);
                }
                else
                {
                    project = new Project();
                    project.Proj_Presenter = User.Identity.Name.Split(',')[1];
                }

                project.Proj_Title = model.Proj_Title;
                project.Proj_Staff_Contact = model.Proj_Staff_Contact;
                project.Proj_Client_Contact = model.Proj_Client_Contact;
                project.Proj_Client_Company = model.Proj_Client_Company;
                project.Proj_Valid_Dates = model.Proj_Valid_Dates;
                project.Proj_Students_Num = model.Proj_Students_Num;
                project.Proj_Continuation = model.Proj_Continuation;
                project.Proj_Description = model.Proj_Description;
                project.Proj_Skills_Required = model.Proj_Skills_Required;
                project.Proj_Context = model.Proj_Context;
                project.Proj_Goals = model.Proj_Goals;

                project.Proj_Features = model.Proj_Features;
                project.Proj_Challenges = model.Proj_Challenges;
                project.Proj_Opportunities = model.Proj_Opportunities;
                project.Proj_Trimester_Id = model.Proj_Trimester_Id;
                project.Proj_Update_Time = DateTime.Now;

                if (id.HasValue)
                {
                    ProjectService.Update(project);
                }
                else
                {
                    ProjectService.Save(project);
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

        public ActionResult ProjectDelete(int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                if (id.HasValue)
                {
                    Project model = ProjectService.GetModel(id.Value);
                    ProjectService.Delete(model);
                    jsonResult.result = true;
                    jsonResult.message = "";
                }
                else
                {
                    jsonResult.message = "Id is null！";
                }
            }
            catch (Exception ex)
            {
                jsonResult.message = ex.Message;
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}
