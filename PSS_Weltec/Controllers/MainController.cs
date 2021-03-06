﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PSS_Weltec.DAL;
using PSS_Weltec.Models;
using PSS_Weltec.Shared_Class;

namespace PSS_Weltec.Controllers
{
    public class MainController : Controller
    {
        public ActionResult MainIndex()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MainIndex(Models.User model)
        {
            string sError = "";
            if (ModelState.IsValid)
            {
                try
                {
                    SqlHelper.Initialization();
                    if (UserService.IsValidation(model.user_Name_Model, model.user_Password_Model))
                    {
                        model = UserService.GetModel(model.user_Name_Model);

                        #region Save user session
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        model.user_Id.ToString()+","+model.user_Name,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        model.user_Id.ToString()
                        );
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                        #endregion

                        model.user_Log_Time = DateTime.Now;
                        UserService.Update(model);
                        SqlHelper.Dispose();
                        return RedirectToAction("FrameIndex", "Frame");
                    }
                    else
                    {
                        sError = "The UserName and Password is not matched!";
                    }
                }
                catch (Exception ex)
                {
                    sError = ex.Message;
                }
                if(!string.IsNullOrEmpty(sError))
                    ModelState.AddModelError("", sError);
            }
            SqlHelper.Dispose();
            return View(model);
        }

        public ActionResult RegisterIndex()
        {
            SqlHelper.Initialization();
            List<SelectListItem> listTrimester = new List<SelectListItem>();
            foreach (Trimester tri in  TrimesterService.GetList().Where(item=>item.tri_IsOpen==true))
            {
                listTrimester.Add(new SelectListItem { Text = tri.tri_Name, Value = tri.tri_Id.ToString()});
            }


            ViewData["listTrimester"] = listTrimester;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterIndex(User model)
        {
            string sError = "";
            if (ModelState.IsValid)
            {
                try
                {
                    SqlHelper.Initialization();
                    List<SelectListItem> listTrimester = new List<SelectListItem>();
                    foreach (Trimester tri in TrimesterService.GetList().Where(item => item.tri_IsOpen == true))
                    {
                        listTrimester.Add(new SelectListItem { Text = tri.tri_Name, Value = tri.tri_Id.ToString() });
                    }


                    ViewData["listTrimester"] = listTrimester;
                    if (!UserService.IsExistName(model.user_Name_Model,model.user_Trimester_Id))
                    {
                        if (model.user_Password_Model == model.user_confire_Password_Model)
                        {
                            model.user_Name = model.user_Name_Model;
                            model.user_Password = SqlHelper.Fun_Secret(model.user_Password_Model);
                            model.user_Is_Teacher = false;
                            model.user_Register_Time = DateTime.Now;
                            model.user_Log_Time = DateTime.Now;
                            model.user_Update_Time = DateTime.Now;
                            UserService.Save(model);
                            //Object _n = new Object { Title = "注册成功", Details = "您已经成功注册，用户为：" + _user.UserName + " ，请牢记您的密码！", DwellTime = 5, Navigation = Url.Action("FrameIndex", "Frame") };
                            return Content("<script>alert('添加成功！');window.location=''</script>");
                            //return RedirectToAction(("FrameIndex", "Frame");
                            //return RedirectToAction("FrameIndex", "Frame");
                        }
                        else
                        {
                            sError = "The PassWord and Comfirm Password is not same!";
                        }
                    }
                    else
                    {
                        sError = "There is already exist the name, please change a userName!";
                    }
                }
                catch (Exception ex)
                {
                    sError = ex.Message;
                }
                if (!string.IsNullOrEmpty(sError))
                    ModelState.AddModelError("", sError);
            }
            SqlHelper.Dispose();
            return View(model);
        }
    }
}
