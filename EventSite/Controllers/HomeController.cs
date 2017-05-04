using EventSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EventSite.Controllers
{
    public class HomeController : Controller
    {
        private const string eventCacheKey = "event";

        public ActionResult Index()
        {
            //all events, with venue and genre down to the view
            var schedule = HttpRuntime.Cache["events"] as IEnumerable<EventModel>;
            if (schedule == null)
            {
                var data = new ApplicationDbContext().Events.Include(i => i.Genre).Include(i => i.Venue).ToList();
                HttpRuntime.Cache.Add(
                    "data",
                    data,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.Normal,
                    null
                    );
                schedule = data as IEnumerable<EventModel>;
            }
            return View(schedule);

        }

    }
}