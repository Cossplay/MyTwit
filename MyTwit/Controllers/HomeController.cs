using System.Web.Mvc;

namespace MyTwit.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["IsAuth"] != null && (bool)Session["IsAuth"] == true) 
            {
                return View();
            }
            return View("~/Views/Auth/Auth.cshtml");
        }
    }
}