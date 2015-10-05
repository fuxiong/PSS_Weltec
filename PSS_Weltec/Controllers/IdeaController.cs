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
    public class IdeaController : Controller
    {
        //
        // GET: /Idea/

        public ActionResult IdeaIndex()
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

        public ActionResult IdeaList(int? page, int? rows, int trimesterId, string sort, string order, string queryWord)
        {
            #region Get paging condition
            Paging paging = new Paging();
            paging.SetPageSize(rows.HasValue ? rows.Value : Paging.DEFAULT_PAGE_SIZE); //pageRows;
            paging.SetCurrentPage(page.HasValue ? page.Value : 1); //pageNumber;
            #endregion

            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            List<Idea> list = null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.IdeaService.GetList(paging, sort, order, trimesterId, queryWord);
                if (list != null && list.Count() > 0)
                {
                    foreach (Idea idea in list)
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

        public ActionResult IdeaEdit(int? id)
        {
            Idea model = null;
            try
            {
                if (id.HasValue)
                {
                    model = IdeaService.GetModel(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IdeaEditLoad(int? Idea_Id, int trimesterId)
        {
            Idea model = new Idea();
            model.Idea_Trimester_Id = trimesterId;
            if (Idea_Id.HasValue)
            {
                model = IdeaService.GetModel(Idea_Id.Value);
                model.Context = base.Server.UrlEncode(model.Idea_Context).Replace("+", "%20");
                model.Description = base.Server.UrlEncode(model.Idea_Description).Replace("+", "%20");
                model.Skills_Required = base.Server.UrlEncode(model.Idea_Skills_Required).Replace("+", "%20");
                model.Goals = base.Server.UrlEncode(model.Idea_Goals).Replace("+", "%20");
                model.Features = base.Server.UrlEncode(model.Idea_Features).Replace("+", "%20");
                model.Challenges = base.Server.UrlEncode(model.Idea_Challenges).Replace("+", "%20");
                model.Opportunities = base.Server.UrlEncode(model.Idea_Opportunities).Replace("+", "%20");
            }

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Yes", Value = "True" });
            list.Add(new SelectListItem { Text = "No", Value = "False" });
            ViewData["list"] = list;

            return View(model);
        }

        [HttpPost]
        public ContentResult IdeaSave(Idea model, int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                Idea idea = null;
                if (id.HasValue)
                {
                    idea = IdeaService.GetModel(id.Value);
                }
                else
                {
                    idea = new Idea();
                    idea.Idea_Presenter = User.Identity.Name.Split(',')[1];
                }

                idea.Idea_Title = model.Idea_Title;
                idea.Idea_Staff_Contact = model.Idea_Staff_Contact;
                idea.Idea_Client_Contact = model.Idea_Client_Contact;
                idea.Idea_Client_Company = model.Idea_Client_Company;
                idea.Idea_Valid_Dates = model.Idea_Valid_Dates;
                idea.Idea_Students_Num = model.Idea_Students_Num;
                idea.Idea_Continuation = model.Idea_Continuation;
                idea.Idea_Description = model.Idea_Description;
                idea.Idea_Skills_Required = model.Idea_Skills_Required;
                idea.Idea_Context = model.Idea_Context;
                idea.Idea_Goals = model.Idea_Goals;

                idea.Idea_Features = model.Idea_Features;
                idea.Idea_Challenges = model.Idea_Challenges;
                idea.Idea_Opportunities = model.Idea_Opportunities;
                idea.Idea_Trimester_Id = model.Idea_Trimester_Id;
                idea.Idea_Update_Time = DateTime.Now;
                idea.Idea_Advisor_Contact = model.Idea_Advisor_Contact;
                idea.Idea_Status = model.Idea_Status;

                if (id.HasValue)
                {
                    IdeaService.Update(idea);
                }
                else
                {
                    IdeaService.Save(idea);
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

        public ActionResult IdeaDelete(int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                if (id.HasValue)
                {
                    Idea model = IdeaService.GetModel(id.Value);
                    IdeaService.Delete(model);
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

        public ActionResult IdeaDetail(int id)
        {
            Idea model = IdeaService.GetModel(id);
            model.Context = base.Server.UrlEncode(model.Idea_Context).Replace("+", "%20");
            model.Description = base.Server.UrlEncode(model.Idea_Description).Replace("+", "%20");
            model.Skills_Required = base.Server.UrlEncode(model.Idea_Skills_Required).Replace("+", "%20");
            model.Goals = base.Server.UrlEncode(model.Idea_Goals).Replace("+", "%20");
            model.Features = base.Server.UrlEncode(model.Idea_Features).Replace("+", "%20");
            model.Challenges = base.Server.UrlEncode(model.Idea_Challenges).Replace("+", "%20");
            model.Opportunities = base.Server.UrlEncode(model.Idea_Opportunities).Replace("+", "%20");
            return View(model);
        }

        [HttpPost]
        public ContentResult IdeaDiscSave(Idea_Discussion model, int ideaId)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                Idea_Discussion ideaDisc = new Idea_Discussion();
                ideaDisc.Idea_Disc_Idea_Id = ideaId;
                ideaDisc.Idea_Disc_Content = model.Idea_Disc_Content;
                ideaDisc.Idea_Disc_Time = DateTime.Now;
                ideaDisc.Idea_Disc_User_Id = Convert.ToInt32(User.Identity.Name.Split(',')[0]);
                IdeaDiscussionService.Save(ideaDisc);
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

        public ActionResult IdeaDiscLoad(int ideaId)
        {
            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            try
            {
                List<Idea_Discussion> list = IdeaDiscussionService.GetList(ideaId);
                List<User> listUser = UserService.GetList();
                if (list != null && list.Count() > 0)
                {
                    foreach (Idea_Discussion model in list)
                    {
                        User user = listUser.Find(item => item.user_Id == model.Idea_Disc_User_Id);
                        if (user != null)
                            model.UserName = user.user_Name;
                        jsonDataGridResult.rows.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                jsonDataGridResult.result = false;
                jsonDataGridResult.message = ex.Message;
            }
            return Json(jsonDataGridResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult IdeaCommSave(Idea_Comment model, int ideaId)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                //using()
                //{
                    Idea_Comment ideaComm = new Idea_Comment();
                    ideaComm.Idea_Comm_Idea_Id = ideaId;
                    ideaComm.Idea_Comm_Content = model.Idea_Comm_Content;
                    ideaComm.Idea_Comm_Time = DateTime.Now;
                    IdeaCommService.Save(ideaComm);

                    Idea idea = IdeaService.GetModel(ideaId);
                    idea.Idea_Status = 2;
                    IdeaService.Update(idea);


                    jsonResult.result = true;
                    jsonResult.message = "";
                //}
            }
            catch (Exception ex)
            {
                jsonResult.result = false;
                jsonResult.message = ex.Message;
            }
            string result = JsonConvert.SerializeObject(jsonResult);
            return Content(result);
        }

        public ActionResult IdeaApprove(int ideaId)
        {
            Idea model = null;
            try
            {
                model = IdeaService.GetModel(ideaId);
                model.Idea_Status = 1;
                IdeaService.Update(model);

                Project project = new Project();

                project.Proj_Presenter = model.Idea_Presenter;

                project.Proj_Title = model.Idea_Title;
                project.Proj_Staff_Contact = model.Idea_Staff_Contact;
                project.Proj_Client_Contact = model.Idea_Client_Contact;
                project.Proj_Client_Company = model.Idea_Client_Company;
                project.Proj_Valid_Dates = model.Idea_Valid_Dates;
                project.Proj_Students_Num = model.Idea_Students_Num;
                project.Proj_Continuation = model.Idea_Continuation;
                project.Proj_Description = model.Idea_Description;
                project.Proj_Skills_Required = model.Idea_Skills_Required;
                project.Proj_Context = model.Idea_Context;
                project.Proj_Goals = model.Idea_Goals;

                project.Proj_Features = model.Idea_Features;
                project.Proj_Challenges = model.Idea_Challenges;
                project.Proj_Opportunities = model.Idea_Opportunities;
                project.Proj_Trimester_Id = model.Idea_Trimester_Id;
                project.Proj_Update_Time = DateTime.Now;

                ProjectService.Save(project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IdeaCommLoad(int ideaId)
        {
            JsonDataGridResult jsonDataGridResult = new JsonDataGridResult();
            try
            {
                List<Idea_Comment> list = IdeaCommService.GetList(ideaId);
                if (list != null && list.Count() > 0)
                {
                    foreach (Idea_Comment model in list)
                    {
                        jsonDataGridResult.rows.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                jsonDataGridResult.result = false;
                jsonDataGridResult.message = ex.Message;
            }
            return Json(jsonDataGridResult, JsonRequestBehavior.AllowGet);
        }
    }
}
