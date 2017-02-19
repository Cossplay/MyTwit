using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using MyTwit.Hubs;
using DAL.Entities;
using DAL.Interfaces;

namespace MyTwit.Controllers
{
    public class HomeController : Controller
    {
        ITwitRepository twitRepos;
        public HomeController(ITwitRepository repos)
        {
            twitRepos = repos;
        }
        // GET: Home
        public ActionResult Index()
        {
            if (Session["IsAuth"] != null && (bool)Session["IsAuth"] == true) 
            {
                return View(twitRepos.GetAll());
            }
            return View("~/Views/Auth/Auth.cshtml");
        }
        [HttpPost]
        public JsonResult AddNewTwit(string message)
        {
            OnTwitCreated(message);
            return  Json(null);
        }
        public JsonResult LikeTwit(int twitId, int cntLikes)
        {
            twitRepos.Like(twitId, cntLikes);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UnlikeTwit(int twitId, int cntLikes)
        {
            twitRepos.Unlike(twitId, cntLikes);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        private void OnTwitCreated(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
            context.Clients.All.addNewTwit(message);
        }
    }
}