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
    public class TinTucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TinTucs
        public ActionResult Index(string searchString)
        {

            return View(db.TinTucs.ToList());
        }

        // GET: Admin/TinTucs/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,TieuDe,AnhTieuDe,MoTa,NguoiDang,TgDang,NoiDung")] TinTuc tinTuc, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {

                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/imgTinTucAd"), filename);
                    img.SaveAs(path);
                    tinTuc.AnhTieuDe = "/Content/imgTinTucAd/" + filename; //Lưu ý
                }
                else
                {
                    tinTuc.AnhTieuDe = "a.jpg";
                }

                db.TinTucs.Add(tinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TieuDe,AnhTieuDe,MoTa,NguoiDang,TgDang,NoiDung")] TinTuc tinTuc, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {

                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/imgTinTucAd"), filename);
                    img.SaveAs(path);
                    tinTuc.AnhTieuDe = "/Content/imgTinTucAd/" + filename; //Lưu ý
                }
                else
                {
                    tinTuc.AnhTieuDe = "a.jpg";
                }
                db.Entry(tinTuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
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
