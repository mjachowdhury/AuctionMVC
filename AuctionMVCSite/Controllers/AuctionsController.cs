using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionMVCSite.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        public ActionResult Index()
        {
            var auctions = new[]{
                new Models.Auction()
                {
                    Title = "Example Auction #1",
                    Description = "This is an example Auction",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = null,
                },
                new Models.Auction()
                {
                    Title = "Example Auction #2",
                    Description = "This is an example Auction",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = null,
                },
                new Models.Auction()
                {
                    Title = "Example Auction #3",
                    Description = "This is an example Auction",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = null,
                },
            };
            return View(auctions);
        }

        public ActionResult TempDataDemo()
        {
            TempData["SuccessMessage"] = "The action succeeded";
            return RedirectToAction("Index");
        }

        public ActionResult Auction()
        {
            var auction = new AuctionMVCSite.Models.Auction()
            {
                Title = "Example Auction",
                Description = "This is an example Auction",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7),
                StartPrice = 1.00m,
                CurrentPrice = null,
            };
            //view data dictionary 
            //ViewData["Auction"] = auction;
            //return View();
            //I can use to render view like this
            return View(auction);
        }
    }
}