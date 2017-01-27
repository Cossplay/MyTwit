using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwit.Interfaces;
using MyTwit.Models;

namespace MyTwit.Controllers
{
    public class RegistrationController : Controller
    {
        private IUserRepository rep;
        public RegistrationController(IUserRepository repo)
        {
            rep = repo;
        }
        // GET: Registration
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (rep.GetUser(user.Login) == null)
            {
                string hashPass = Hash.CreateMd5(user.Password);
                rep.SignUp(user.Login, hashPass);
                return Redirect("/Auth/Auth");
            }
            return View();
        }
        public JsonResult IsExist(string Login)
        {
            return Json(rep.GetUser(Login) == null, JsonRequestBehavior.AllowGet);
        }
    }
}