using System.Web.Mvc;
using MyTwit.Interfaces;
using MyTwit.Models;

namespace MyTwit.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository repo;
        // Constructor
        public AuthController(IUserRepository rep)
        {
            repo = rep;
        }
        // GET: SingIn при нажатии на кнопку входа
        public JsonResult SignIn(string inputUser, string inputPass)
        {
            User user = repo.GetUser(inputUser);
            if (user != null)
            {
                bool res = Hash.VerifyMd5Hash(inputPass, user.Password);
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
        //При обращении к Auth url
        public ActionResult Auth()
        {
            if (IsAuth())
            {
                return View("~/Views/Home/Index.cshtml");
            }
            return View();
        }
        //авторизован ли пользователь
        private bool IsAuth()
        {
            bool res = false;
            if (Session["IsAuth"] != null)
            {
                res = (bool) Session["IsAuth"];
            }
            return res;
        }
        // При нажатии на кнопку выход(выходит из аккаунта(очистка сессии))
        public JsonResult Out()
        {
            Session.Clear();
            return Json(@Url.Action("Auth","Auth"), JsonRequestBehavior.AllowGet);
        }
    }
}