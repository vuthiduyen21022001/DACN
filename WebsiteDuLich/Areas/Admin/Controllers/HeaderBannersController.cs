using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Areas.Admin.Controllers
{
    public class HeaderBannersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/HeaderBanners
        //[CustomAuthorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.headerBanners.ToList());
        }

        // GET: Admin/HeaderBanners/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            headerBanner headerBanner = db.headerBanners.Find(id);
            if (headerBanner == null)
            {
                return HttpNotFound();
            }
            return View(headerBanner);
        }

        // GET: Admin/HeaderBanners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HeaderBanners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Namebanner,Imgbanner")] headerBanner headerBanner)
        {
            if (ModelState.IsValid)
            {
                db.headerBanners.Add(headerBanner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headerBanner);
        }

        // GET: Admin/HeaderBanners/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            headerBanner headerBanner = db.headerBanners.Find(id);
            if (headerBanner == null)
            {
                return HttpNotFound();
            }
            return View(headerBanner);
        }

        // POST: Admin/HeaderBanners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[CustomAuthorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Namebanner,Imgbanner")] headerBanner headerBanner, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {

                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/ImgBannerAd"), filename);
                    img.SaveAs(path);
                    headerBanner.Imgbanner = "/Content/ImgBannerAd/" + filename; //Lưu ý

                }
                else
                {
                    headerBanner.Imgbanner = "a.jpg";
                }

                db.Entry(headerBanner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headerBanner);
        }

        // GET: Admin/HeaderBanners/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            headerBanner headerBanner = db.headerBanners.Find(id);
            if (headerBanner == null)
            {
                return HttpNotFound();
            }
            return View(headerBanner);
        }

        // POST: Admin/HeaderBanners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            headerBanner headerBanner = db.headerBanners.Find(id);
            db.headerBanners.Remove(headerBanner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
