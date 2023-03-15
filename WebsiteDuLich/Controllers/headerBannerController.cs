using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Controllers
{
    public class headerBannerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        [ChildActionOnly]
        public ActionResult banner()
        {
            return PartialView(db.headerBanners.ToList());
        }
    }
}
