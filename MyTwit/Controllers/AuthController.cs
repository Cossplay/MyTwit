using System.Web.Mvc;
using MyTwit.Util;
using MyTwit.DAL.Entities;
using MyTwit.DAL.Interfaces;

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
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            User getUser = null;

            getUser = repo.Get(user.Login);
            if (getUser != null)
            {
                var res = Hash.VerifyMd5Hash(user.Password, getUser.Password);
                if (res)
                {
                    Session["IsAuth"] = true;
                    Session["Login"] = getUser.Login;
                    return Redirect("/Home/Index");
                }
            }
            Session["IsAuth"] = false;

            return View("Auth", getUser);
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
        public RedirectResult Out()
        {
            Session.Clear();
            return Redirect("Auth");
        }
    }
}