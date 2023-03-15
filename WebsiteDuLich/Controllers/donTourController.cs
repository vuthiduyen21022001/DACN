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
    public class donTourController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: donTour
        public ActionResult Index()
        {       //Kiểm tra đang đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            Nguoidung kh = (Nguoidung)Session["use"];
            int maND = kh.MaNguoiDung;
            var donTours = db.DonTours.Include(d => d.Nguoidung).Where(d => d.MaNguoidung == maND);
            return View(donTours.ToList());
        }

        // GET: donTour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonTour donTour = db.DonTours.Find(id);
            var chitiet = db.CTDonTours.Include(d => d.Tour).Where(d => d.Madon == id).ToList();
            if (donTour == null)
            {
                return HttpNotFound();
            }
            return View(donTour);
        }

    
        // GET: donTour/Delete/5
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

        // POST: donTour/Delete/5
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
