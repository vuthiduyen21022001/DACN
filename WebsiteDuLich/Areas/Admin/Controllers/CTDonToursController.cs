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
    public class CTDonToursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CTDonTours
        public ActionResult Index()
        {
            var cTDonTours = db.CTDonTours.Include(c => c.DonTour);
               cTDonTours = db.CTDonTours.Include(c => c.Tour);
            return View(cTDonTours.ToList());
        }

        // GET: Admin/CTDonTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonTour cTDonTour = db.CTDonTours.Find(id);
            if (cTDonTour == null)
            {
                return HttpNotFound();
            }
            return View(cTDonTour);
        }

        // GET: Admin/CTDonTours/Create
        public ActionResult Create()
        {
            ViewBag.Madon = new SelectList(db.DonTours, "Madon", "Masp");
            return View();
        }

        // POST: Admin/CTDonTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madon,Masp,Dongia,Thanhtien")] CTDonTour cTDonTour)
        {
            if (ModelState.IsValid)
            {
                db.CTDonTours.Add(cTDonTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Madon = new SelectList(db.DonTours, "Madon", "Masp", cTDonTour.Madon);
            return View(cTDonTour);
        }

        // GET: Admin/CTDonTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonTour cTDonTour = db.CTDonTours.Find(id);
            if (cTDonTour == null)
            {
                return HttpNotFound();
            }
            ViewBag.Madon = new SelectList(db.DonTours, "Madon", "Masp", cTDonTour.Madon);
            return View(cTDonTour);
        }

        // POST: Admin/CTDonTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madon,Masp,Dongia,Thanhtien")] CTDonTour cTDonTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDonTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Madon = new SelectList(db.DonTours, "Madon", "Masp", cTDonTour.Madon);
            return View(cTDonTour);
        }

        // GET: Admin/CTDonTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonTour cTDonTour = db.CTDonTours.Find(id);
            if (cTDonTour == null)
            {
                return HttpNotFound();
            }
            return View(cTDonTour);
        }

        // POST: Admin/CTDonTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTDonTour cTDonTour = db.CTDonTours.Find(id);
            db.CTDonTours.Remove(cTDonTour);
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
