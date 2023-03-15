using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.api
{
    
    public class apiToursController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/apiTours
        public IQueryable<Tour> GetTours()
        {
            return db.Tours;
        }

        // GET: api/apiTours/5
        [ResponseType(typeof(Tour))]
        public IHttpActionResult GetTour(int id)
        {
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }

        // PUT: api/apiTours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTour(int id, Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tour.Id)
            {
                return BadRequest();
            }

            db.Entry(tour).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/apiTours
        [ResponseType(typeof(Tour))]
        public IHttpActionResult PostTour(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tours.Add(tour);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tour.Id }, tour);
        }

        // DELETE: api/apiTours/5
        [ResponseType(typeof(Tour))]
        public IHttpActionResult DeleteTour(int id)
        {
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            db.Tours.Remove(tour);
            db.SaveChanges();

            return Ok(tour);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourExists(int id)
        {
            return db.Tours.Count(e => e.Id == id) > 0;
        }
    }
}