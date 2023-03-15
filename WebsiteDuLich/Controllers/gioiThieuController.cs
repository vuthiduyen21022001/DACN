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
    public class gioiThieuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: gioiThieu
        public ActionResult Index()
        {
            return View(db.GioiThieus.ToList());
        }

    
    }
}
