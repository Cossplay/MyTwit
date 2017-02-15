using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using MyTwit.Hubs;

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
        [HttpPost]
        public JsonResult AddNewTwit(string message)
        {
            OnTwitCreated(message);
            return  Json(null);
        }
        private void OnTwitCreated(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
            context.Clients.All.addNewTwit(message);
        }
    }
}