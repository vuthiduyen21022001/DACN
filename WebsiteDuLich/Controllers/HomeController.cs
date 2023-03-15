using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View("Index");
        }
        private List<Tour> LaytourMoi(int count)
        {
            return db.Tours.OrderByDescending(a => a.NgayDang).Take(count).ToList();
        }
        private List<TinTuc> LaytintucMoi(int count)
        {
            return db.TinTucs.OrderByDescending(b => b.TgDang).Take(count).ToList();
        }

        [ChildActionOnly]
        public ActionResult dstour()
        {
            var tours = LaytourMoi(6);
            return View(tours.ToList());
        }

        [ChildActionOnly]
        public ActionResult dstour1()
        {
           
            var tours = LaytourMoi(6);
            return View(tours.ToList());
        }

        [ChildActionOnly]
        public ActionResult dstintuc()
        {
            var tintucs = LaytintucMoi(3);
            return View(tintucs.ToList());         
        }

        [ChildActionOnly]
        public ActionResult dstintuc1()
        {
            var tintucs = LaytintucMoi(4);
            return View(tintucs.ToList());
        }
        //Liên hệ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dslienhe([Bind(Include = "Id,HoTenLH,EmailLH,ChuDeLH,NoiDungLH")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                db.LienHes.Add(lienHe);
                db.SaveChanges();
                return RedirectToAction("Create", "lienHe");
            }

            return View(lienHe);
        }

        //[CustomAuthorize(Roles = "Administrator,member")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     

    }
}