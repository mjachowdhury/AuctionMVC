using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace AuctionMVCSite.App_Start
{
    public class DisplayMode
    {
        public static void ConfigureDisplayModes()
        {
            //register iPhone-specific views
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (ctx => ctx.Request.UserAgent.IndexOf(
                "iPhone", StringComparison.OrdinalIgnoreCase) >=0)
            });

            // register iPad-specific views

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPad")
            {
                ContextCondition = (ctx => ctx.Request.UserAgent.IndexOf(
                "iPad", StringComparison.OrdinalIgnoreCase) >= 0)
            });

        }
    }
}