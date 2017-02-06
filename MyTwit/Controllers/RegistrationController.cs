
using System.Web.Mvc;
using MyTwit.Util;
using MyTwit.DAL.Entities;
using MyTwit.DAL.Interfaces;

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
        // Remote метод для поля Login
     /*   public JsonResult IsExist(string Login)
        {
            bool result = false;

            var route = ((Route)RouteTable.Routes["Default"]).Defaults;
            var defaultUrl = Url.RouteUrl("Default", route);
            var fullDefaultUrl = $"/{route["controller"]}/{route["action"]}";
            var referer = Request.UrlReferrer.AbsolutePath;

            if (defaultUrl.Equals(referer) || fullDefaultUrl.Equals(referer))
                result = true;
            else
                result = rep.GetUser(Login) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        } */  
    }
}