using PagedList;
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
    public class ToursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Tours
        //[CustomAuthorize(Roles = "Administrator")]

        public ActionResult Index(string searchString)
        {
            //Tìm kiếm
            var tours = db.Tours.Include(b => b.DanhMuc);
            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(s => s.TenTour.Contains(searchString)
                                       || s.LichTrinh.Contains(searchString));
                /*  || s.NgayDang.Contains(searchString))*/
            }

            return View(tours.ToList());
        }
        // GET: Admin/Tours/Details/5
        //[CustomAuthorize(Roles = "1")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Admin/Tours/Create
        public ActionResult Create()
        {
            ViewBag.DMuc = new SelectList(db.DanhMucs, "Id", "TenDM");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[CustomAuthorize(PhanQuyen = "admin")]
        public ActionResult Create([Bind(Include = "Id,TenTour,url,Giaban,GiaChuaKM,GiamGia,TinhTrang,NgayDang,LichTrinh,LichKhoiHanh,GiaBaoGom,GiaKBaoGom,PhuThu,HoanHuy,LuuY,HinhAnhTour,HinhAnhTour1,HinhAnhTour2,HinhAnhTour3,DMuc")] Tour tour, HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3)
        {
            var path = "";
            var path1 = "";
            var path2 = "";
            var path3 = "";
            var filename = "";
            var filename1 = "";
            var filename2 = "";
            var filename3 = "";
            if (ModelState.IsValid)
            {
                if (img != null && img1 != null && img2 != null && img3 != null)
                {

                    filename = img.FileName;
                    filename1 = img1.FileName;
                    filename2 = img2.FileName;
                    filename3 = img3.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/imgTourAd"), filename);
                    path1 = Path.Combine(Server.MapPath("~/Content/imgTourAd"), filename1);
                    path2 = Path.Combine(Server.MapPath("~/Content/imgTourAd"), filename2);
                    path3 = Path.Combine(Server.MapPath("~/Content/imgTourAd"), filename3);
                    img.SaveAs(path);
                    img1.SaveAs(path1);
                    img2.SaveAs(path2);
                    img3.SaveAs(path3);
                    tour.HinhAnhTour = "/Content/imgTourAd/" + filename; //Lưu ý
                    tour.HinhAnhTour1 = "/Content/imgTourAd/" + filename1;
                    tour.HinhAnhTour2 = "/Content/imgTourAd/" + filename2;
                    tour.HinhAnhTour3 = "/Content/imgTourAd/" + filename3;
                }
                else
                {
                    tour.HinhAnhTour = "a.jpg";
                    tour.HinhAnhTour1 = "a.jpg";
                    tour.HinhAnhTour2 = "a.jpg";
                    tour.HinhAnhTour3 = "a.jpg";
                }
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DMuc = new SelectList(db.DanhMucs, "Id", "TenDM", tour.DMuc);
            return View(tour);
        }

        // GET: Admin/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.DMuc = new SelectList(db.DanhMucs, "Id", "TenDM", tour.DMuc);
            return View(tour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[CustomAuthorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,TenTour,url,Giaban,GiaChuaKM,GiamGia,TinhTrang,NgayDang,LichTrinh,LichKhoiHanh,GiaBaoGom,GiaKBaoGom,PhuThu,HoanHuy,LuuY,HinhAnhTour,HinhAnhTour1,HinhAnhTour2,HinhAnhTour3,DMuc")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DMuc = new SelectList(db.DanhMucs, "Id", "TenDM", tour.DMuc);
            return View(tour);
        }

        // GET: Admin/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[CustomAuthorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
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
