using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwit.Models;

namespace MyTwit.Controllers
{
    public class AuthController : Controller
    {
        // GET: SingIn
        public JsonResult SignIn(string inputUser, string inputPass)
        {
            Repository rep = new Repository();
            User user = rep.GetUser(inputUser);
            if (user != null)
            {
                string hash = user.CreateMd5(user.Password);
                bool res = user.VerifyMd5Hash(inputPass, hash);

                if (res)
                {
                    Session["IsAuth"] = true;
                    Session["Login"] = inputUser;
                    return Json(true, JsonRequestBehavior.AllowGet);
                }else Session["IsAuth"] = false;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Auth()
        {
            if (IsAuth())
            {
                return View("~/Views/Home/Index.cshtml");
            }
            return View();
        }

        public bool IsAuth()
        {
            bool res = false;

            if (Session["IsAuth"] != null)
            {
                res = (bool) Session["IsAuth"];
            }
            return res;
        }
    }
}