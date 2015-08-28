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
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult UserIndex()
        {
            return View();
        }

        public ActionResult UserList(int? page, int? rows, string sort, string order, string queryWord)
        {
            #region Get paging condition
            Paging paging = new Paging();
            paging.SetPageSize(rows.HasValue ? rows.Value : Paging.DEFAULT_PAGE_SIZE); //pageRows;
            paging.SetCurrentPage(page.HasValue ? page.Value : 1); //pageNumber;
            #endregion

            JsonDataGridResult jsonDataGridResult=new JsonDataGridResult();
            List<User> list=null;
            try
            {
                SqlHelper.Initialization();
                list = DAL.UserService.GetList(paging,sort,order,queryWord);
                if (list != null && list.Count() > 0)
                {
                    foreach (User user in list)
                    {
                        jsonDataGridResult.rows.Add(user);
                    }
                    jsonDataGridResult.total = paging.GetRecordCount();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonDataGridResult,JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserEdit(int?id)
        {
            User user = null;
            try
            {
                if (id.HasValue)
                {
                    user = UserService.GetModel(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult UserSave(User userModel, int?id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                User user = null;
                if (id.HasValue)
                {
                    user = UserService.GetModel(id.Value);
                }
                else if(UserService.IsExistName(userModel.user_Name))
                {
                    jsonResult.result = false;
                    jsonResult.message = "There is already exist the name, please change a userName!";
                    return Content(JsonConvert.SerializeObject(jsonResult));
                }
                else
                {
                    user = new User();
                    user.user_Register_Time = DateTime.Now;
                    user.user_Log_Time = DateTime.Now;
                }

                user.user_Name = userModel.user_Name;
                user.user_Password =SqlHelper.Fun_Secret(userModel.user_Password);
                user.user_Email = userModel.user_Email;
                user.user_Telephone = userModel.user_Telephone;
                //user.user_Is_Teacher = userModel.user_Is_Teacher;
                user.user_Skill = userModel.user_Skill;
                user.user_Introduction = userModel.user_Introduction;
                user.user_Update_Time = DateTime.Now;

                if (id.HasValue)
                {
                    UserService.Update(user);
                }
                else
                {
                    UserService.Save(user);
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

        public ActionResult UserDelete(int? id)
        {
            JsonDataGridResult jsonResult = new JsonDataGridResult();
            try
            {
                if (id.HasValue)
                {
                    User user=UserService.GetModel(id.Value);
                    UserService.Delete(user);
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
