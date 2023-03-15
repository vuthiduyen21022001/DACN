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
    public class danhMucController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: danhMuc
        public ActionResult Index()
        {
            return View(db.DanhMucs.ToList());
        }

        // GET: danhMuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

   
    }
}
