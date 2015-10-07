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
    public class TeamController : Controller
    {
        //
        // GET: /Team/

        public ActionResult TeamIndex()
        {
            SqlHelper.Initialization();
            List<SelectListItem> listStatus = new List<SelectListItem>();

            listStatus.Add(new SelectListItem { Text = "UnAuthorized", Value = "0" });
            listStatus.Add(new SelectListItem { Text = "Authorized", Value = "1" });
            listStatus.Add(new SelectListItem { Text = "Bid", Value = "2" });

            ViewData["listStatus"] = listStatus;

            return View();
        }

        public ActionResult TeamList(int? page, int? rows, string status, string sort, string order, string queryWord)
        {
            #region Get paging condition
            Paging paging = new Paging();
            paging.SetPageSize(rows.HasValue ? rows.Value : Paging.DEFAULT_PAGE_SIZE); //pageRows;
            paging.SetCurrentPage(page.HasValue ? page.Value : 1); //pageNumber;
            #endregion

            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            List<Team> list = null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.TeamService.GetList(paging, sort, order, status, queryWord);
                if (list != null && list.Count() > 0)
                {
                    foreach (Team idea in list)
                    {
                        jsonDataGridResult.rows.Add(idea);
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

        public ActionResult TeamEdit(int? id)
        {
            Team model = null;
            try
            {
                if (id.HasValue)
                {
                    model = TeamService.GetModel(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult TeamSave(Team model, int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                Team team = null;
                if (id.HasValue)
                {
                    team = TeamService.GetModel(id.Value);
                }
                else
                {
                    team = new Team();
                }

                team.Team_User_Id = model.Team_User_Id;
                team.Team_Proj_Id = model.Team_Proj_Id;
                team.Team_Title = model.Team_Title;
                team.Team_Status = 0;
                team.Team_Update_Time = DateTime.Now;

                if (id.HasValue)
                {
                    TeamService.Update(team);
                }
                else
                {
                    TeamService.Save(team);
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

        public ActionResult TeamDelete(int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                if (id.HasValue)
                {
                    Team model = TeamService.GetModel(id.Value);
                    TeamService.Delete(model);
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
