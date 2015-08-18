using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult UserList()
        {
            JsonDataGridResult jsonDataGridResult=new JsonDataGridResult();
            List<User> list=null;
            try
            {
                list = DAL.UserService.GetList();
                if (list != null && list.Count() > 0)
                {
                    foreach (User user in list)
                    {
                        jsonDataGridResult.rows.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonDataGridResult,JsonRequestBehavior.AllowGet);
        }
    }
}
