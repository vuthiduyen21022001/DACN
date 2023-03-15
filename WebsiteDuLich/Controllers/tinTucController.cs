using PagedList;
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
    public class tinTucController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tinTuc
        private List<TinTuc> LaytinMoi(int count)
        {
            return db.TinTucs.OrderByDescending(a => a.TgDang).Take(count).ToList();
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var tours = db.Tours.Include(t => t.DanhMuc);
            //var tours = LaytinMoi(12);
            var tintucs = db.TinTucs.AsQueryable();
            int pageSize = 6;
            int pageNumber = (page ?? 1);


            if (!String.IsNullOrEmpty(searchString))
            {
                tintucs = tintucs.Where(s => s.TieuDe.Contains(searchString)
                                       || s.NguoiDang.Contains(searchString)
                                        /*|| s.TgDang.Contains(searchString)*/);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    tintucs = tintucs.OrderByDescending(s => s.TieuDe);
                    break;
                case "Date":
                    tintucs = tintucs.OrderBy(s => s.TgDang);
                    break;
                case "date_desc":
                    tintucs = tintucs.OrderByDescending(s => s.TgDang);
                    break;
                default:
                    tintucs = tintucs.OrderBy(s => s.TieuDe);
                    break;
            }
            return View(tintucs.ToPagedList(pageNumber, pageSize));
        }
        // GET: tinTuc/Details/5
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
