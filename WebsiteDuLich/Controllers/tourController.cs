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
    public class tourController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tour
        private List<Tour> LaytourMoi(int count)
        {
            return db.Tours.OrderByDescending(a => a.NgayDang).Take(count).ToList();
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
            var tours = db.Tours.AsQueryable().Include(t => t.DanhMuc);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            //var tours = LaytourMoi(12);

            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(s => s.TenTour.Contains(searchString)
                                       || s.LichTrinh.Contains(searchString));
                /*  || s.NgayDang.Contains(searchString))*/
            }
            switch (sortOrder)
            {
                case "name_desc":
                    tours = tours.OrderByDescending(s => s.TenTour);
                    break;
                case "Date":
                    tours = tours.OrderBy(s => s.NgayDang);
                    break;
                case "date_desc":
                    tours = tours.OrderByDescending(s => s.NgayDang);
                    break;
                default:
                    tours = tours.OrderBy(s => s.TenTour);
                    break;
            }

            return View(tours.ToPagedList(pageNumber, pageSize));



            //var tours = db.Tours.Include(t => t.DanhMuc);
            //return View(tours.ToList());
        }

        //lấy tour mới
        [ChildActionOnly]
        public ActionResult dstourmoi()
        {
            var tours = LaytourMoi(5);
            return View(tours.ToList());
        }

        // GET: tour/Details/5
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
        public ActionResult TourTheoDanhMuc(int? id)
        {

            var tours = from t in db.Tours where t.DMuc == id select t;
            return View(tours);
        }

    }
}
