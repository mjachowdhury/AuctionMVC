using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AuctionMVCSite.Controllers
{
    public class SearchController : System.Web.Mvc.AsyncController
    {
        public async System.Threading.Tasks.Task<ActionResult> Auctions(string keyword)
        {
            var auctions = await Task.Run<IEnumerable<Models.Auction>>(
                () =>
                {
                    var db = new Models.AuctionDataContext();
                    return db.Auctions.Where(x => x.Title.Contains(keyword)).ToArray();
                });

            return Json(auctions, JsonRequestBehavior.AllowGet);
        }
    }
}