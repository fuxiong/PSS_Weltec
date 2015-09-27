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
                list = DAL.ProjectService.GetList(paging, sort, order, trimesterId,queryWord);
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

        [HttpPost]
        public ContentResult ProjectSave(Project model, int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                Project project = null;
                //if (id.HasValue)
                //{
                //    project = ProjectService.GetModel(id.Value);
                //}
                //else if (ProjectService.IsExistName(model.user_Name, model.user_Trimester_Id))
                //{
                //    jsonResult.result = false;
                //    jsonResult.message = "There is already exist the title, please change a title!";
                //    return Content(JsonConvert.SerializeObject(jsonResult));
                //}
                //else
                //{
                //    project = new Project();
                //    project.user_Register_Time = DateTime.Now;
                //    project.user_Log_Time = DateTime.Now;
                //}

                //project.user_Name = model.user_Name;
                //project.user_Password = SqlHelper.Fun_Secret(model.user_Password);
                //project.user_Email = model.user_Email;
                //project.user_Telephone = model.user_Telephone;
                ////project.user_Is_Teacher = model.user_Is_Teacher;
                //project.user_Skill = model.user_Skill;
                //project.user_Introduction = model.user_Introduction;
                //project.user_Update_Time = DateTime.Now;
                //project.user_Trimester_Id = model.user_Trimester_Id;
                //project.user_Statue = true;


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
                    Project project = ProjectService.GetModel(id.Value);
                    ProjectService.Delete(project);
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
