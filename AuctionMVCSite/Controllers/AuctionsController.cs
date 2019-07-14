using AuctionMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionMVCSite.Controllers
{
    public class AuctionsController : Controller
    {
        //
        // GET: /Auctions/

        public ActionResult Index()
        {
            var db = new AuctionDataContext();
            var auctions = db.Auctions.ToArray();

            return View(auctions);
        }

        public ActionResult Auction(long id)
        {
            var db = new AuctionDataContext();
            var auction = db.Auctions.Find(id);

            return View(auction);
        }


        [HttpPost]
        public ActionResult Bid(Bid bid)
        {
            var db = new AuctionDataContext();
            var auction = db.Auctions.Find(bid.AuctionId);

            if (auction == null)
            {
                ModelState.AddModelError("AuctionId", "Auction not found!");
            }
            else if (auction.CurrentPrice >= bid.Amount)
            {
                ModelState.AddModelError("Amount", "Bid amount must exceed current bid");
            }
            else
            {
                bid.Username = User.Identity.Name;
                auction.Bids.Add(bid);
                auction.CurrentPrice = bid.Amount;
                db.SaveChanges();
            }

            if (!Request.IsAjaxRequest())
                return RedirectToAction("Auction", new { id = bid.AuctionId });
            return PartialView("_CurrentPrice", auction);

            //var httpStatus = ModelState.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            //return new HttpStatusCodeResult(httpStatus);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var categoryList = new SelectList(new[] { "Automotive", "Electronics", "Games", "Home" });
            ViewBag.CategoryList = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CurrentPrice")]Models.Auction auction)
        {
            if (ModelState.IsValid)
            {
                // Save to the database
                var db = new AuctionDataContext();
                db.Auctions.Add(auction);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return Create();
        }
    }
}