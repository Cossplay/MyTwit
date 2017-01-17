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
        // GET: Auth
        public ActionResult Auth()
        {
            Repository rep = new Repository();
            User user = rep.GetUser("Cossplay");
            if (user != null)
            {
                string hash = user.CreateMd5(user.Password);
                bool res = user.VerifyMd5Hash("123456", hash);
            }
            return View();
        }
    }
}