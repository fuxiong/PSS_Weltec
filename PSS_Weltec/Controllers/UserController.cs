﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return Json(null);
        }
    }
}
