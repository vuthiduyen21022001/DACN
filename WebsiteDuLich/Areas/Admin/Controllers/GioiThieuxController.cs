using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Areas.Admin.Controllers
{
    public class GioiThieuxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/GioiThieux
        public ActionResult Index()
        {
            return View(db.GioiThieus.ToList());
        }

        // GET: Admin/GioiThieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieus.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // GET: Admin/GioiThieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GioiThieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NgayDang,NoiDunggt")] GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                db.GioiThieus.Add(gioiThieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gioiThieu);
        }

        // GET: Admin/GioiThieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieus.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // POST: Admin/GioiThieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NgayDang,NoiDunggt")] GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioiThieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gioiThieu);
        }

        // GET: Admin/GioiThieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieus.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // POST: Admin/GioiThieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GioiThieu gioiThieu = db.GioiThieus.Find(id);
            db.GioiThieus.Remove(gioiThieu);
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
