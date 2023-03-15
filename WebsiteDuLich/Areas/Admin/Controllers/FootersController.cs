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
    public class FootersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Footers
        //[CustomAuthorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Footers.ToList());
        }

        // GET: Admin/Footers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // GET: Admin/Footers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Footers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Logo,NoiDung")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                db.Footers.Add(footer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footer);
        }

        // GET: Admin/Footers/Edit/5

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[CustomAuthorize(Roles = "Administrator")]

        public ActionResult Edit([Bind(Include = "Id,Logo,NoiDung")] Footer footer, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {

                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/imglogoAd"), filename);
                    img.SaveAs(path);
                    footer.Logo = "/Content/imglogoAd/" + filename; //Lưu ý

                }
                else
                {
                    footer.Logo = "a.jpg";
                }

                db.Entry(footer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footer);
        }

        // GET: Admin/Footers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Footer footer = db.Footers.Find(id);
            db.Footers.Remove(footer);
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
