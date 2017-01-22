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
                // хэш пасса должен приходить из базы
                string hash = Hash.CreateMd5(user.Password);
                bool res = Hash.VerifyMd5Hash(inputPass, hash);

                if (res)
                {
                    Session["IsAuth"] = true;
                    Session["Login"] = inputUser;
                    var jsonData = new { result = true, url = @Url.Action("Index", "Home")};
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                Session["IsAuth"] = false;
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

        public JsonResult Out()
        {
            Session.Clear();
            return Json(@Url.Action("Auth","Auth"), JsonRequestBehavior.AllowGet);
        }
    }
}