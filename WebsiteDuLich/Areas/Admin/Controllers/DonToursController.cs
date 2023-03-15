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
    public class DonToursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DonTours
        public ActionResult Index()
        {
            var donTours = db.DonTours.Include(d => d.Nguoidung).Include(d => d.CTDonTours);
            return View(donTours.ToList());
        }

        // GET: Admin/DonTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonTour donTour = db.DonTours.Find(id);
            if (donTour == null)
            {
                return HttpNotFound();
            }
            return View(donTour);
        }

        // GET: Admin/DonTours/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FullName");
            ViewBag.MaNguoidung = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten");
            return View();
        }

        // POST: Admin/DonTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madon,Ngaydat,Tinhtrang,MaNguoidung,CustomerId")] DonTour donTour)
        {
            if (ModelState.IsValid)
            {
                db.DonTours.Add(donTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FullName", donTour.CustomerId);
            ViewBag.MaNguoidung = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten", donTour.MaNguoidung);
            return View(donTour);
        }

        // GET: Admin/DonTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonTour donTour = db.DonTours.Find(id);
            if (donTour == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FullName", donTour.CustomerId);
            ViewBag.MaNguoidung = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten", donTour.MaNguoidung);
            return View(donTour);
        }

        // POST: Admin/DonTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madon,Ngaydat,Tinhtrang,MaNguoidung,CustomerId")] DonTour donTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FullName", donTour.CustomerId);
            ViewBag.MaNguoidung = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten", donTour.MaNguoidung);
            return View(donTour);
        }

        // GET: Admin/DonTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonTour donTour = db.DonTours.Find(id);
            if (donTour == null)
            {
                return HttpNotFound();
            }
            return View(donTour);
        }

        // POST: Admin/DonTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonTour donTour = db.DonTours.Find(id);
            db.DonTours.Remove(donTour);
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
