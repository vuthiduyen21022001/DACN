using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Controllers
{
    public class footerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        [ChildActionOnly]
        [OutputCache(Duration =3600,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult footer()
        {
            return PartialView(db.Footers.ToList());
        }
    }
}