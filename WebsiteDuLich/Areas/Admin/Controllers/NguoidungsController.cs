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
    public class NguoidungsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Nguoidungs
        public ActionResult Index()
        {
            var nguoidungs = db.Nguoidungs.Include(n => n.PhanQuyen);
            return View(nguoidungs.ToList());
        }

        // GET: Admin/Nguoidungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // GET: Admin/Nguoidungs/Create
        public ActionResult Create()
        {
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/Nguoidungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiDung,Hoten,Email,Dienthoai,Matkhau,IDQuyen,Diachi")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.Nguoidungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }

        // POST: Admin/Nguoidungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiDung,Hoten,Email,Dienthoai,Matkhau,IDQuyen,Diachi")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoidung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: Admin/Nguoidungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            db.Nguoidungs.Remove(nguoidung);
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
