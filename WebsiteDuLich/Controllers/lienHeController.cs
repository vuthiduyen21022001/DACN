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
    public class lienHeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: lienHe
        public ActionResult Index()
        {
            return View(db.LienHes.ToList());
        }

    
        // GET: lienHe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lienHe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HoTenLH,EmailLH,ChuDeLH,NoiDungLH")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                db.LienHes.Add(lienHe);
                db.SaveChanges();
                return RedirectToAction("Create", "lienHe");
            }

            return View(lienHe);
        }

  
    }
}
