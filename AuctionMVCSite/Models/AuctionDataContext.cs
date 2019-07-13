using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuctionMVCSite.Models
{
    public class AuctionDataContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }

        static AuctionDataContext()
        {
            //with this in place i can change the model and data base will regenerate new database everytime
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AuctionDataContext>());
        }
    }
}