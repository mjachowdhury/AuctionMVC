using AuctionMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AuctionMVCSite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3)]
        public ActionResult Index()
        {
           

            ViewBag.Message = "This page was rendered at " + DateTime.Now;
            return View();
        }

        [OutputCache(Duration =3600)]
        public ActionResult CategoryNavigation()
        {
            var db = new AuctionDataContext();
            var categories = db.Auctions.Select(x => x.Category).Distinct();
            ViewBag.Categories = categories.ToArray();

            return PartialView();
        }

        [OutputCache(Duration = 3)]
        public ActionResult About()
        {
            ViewBag.Message = "This page was rendered at " + DateTime.Now;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SwitchView(string returnUrl, bool mobile = false)
        {
            HttpContext.ClearOverriddenBrowser();
            HttpContext.SetOverriddenBrowser(
                    mobile ? BrowserOverride.Desktop : BrowserOverride.Desktop);

            return Redirect(returnUrl);

        }
    }
}