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

        public ActionResult Auction( long id )
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

        //here two actionresult create method one wil ldo get and other will do post 
        //other wise asp.net will get confuse as it will be called tewo time and which oine to call fist will get confuse then will show error result

        [HttpGet]
        public ActionResult Create()
        {
            var categoryList = new SelectList(new[] { "Automotive", "Electronics", "Games", "Homes" });
            ViewBag.CategoryList = categoryList;
            return View();
        }

        //here [Bind(Exclude ="CurrentPrice")] will ignore the current price from the post so the use ca not see the current price bid

        [HttpPost]
        public ActionResult Create([Bind(Exclude ="CurrentPrice")] Models.Auction auction)
        {
            /*
            if (string.IsNullOrWhiteSpace(auction.Title))
            {
                ModelState.AddModelError("Title", "Title is required");
            }
            else if(auction.Title.Length < 5 || auction.Title.Length > 200)
            {
                ModelState.AddModelError("Title", "Title must be between 5 and 200 characters long");
            }
            */
            if (ModelState.IsValid)
            {
                //save to the databse
                return RedirectToAction("Index");
            }

            return Create();

          
        }
    }
}