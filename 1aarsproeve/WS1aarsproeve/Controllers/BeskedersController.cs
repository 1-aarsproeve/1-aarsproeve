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
using WS1aarsproeve;

namespace WS1aarsproeve.Controllers
{
    public class BeskedersController : ApiController
    {
        private TableContext db = new TableContext();

        // GET: api/Beskeders
        public IQueryable<Beskeder> GetBeskeders()
        {
            return db.Beskeders;
        }

        // GET: api/Beskeders/5
        [ResponseType(typeof(Beskeder))]
        public IHttpActionResult GetBeskeder(int id)
        {
            Beskeder beskeder = db.Beskeders.Find(id);
            if (beskeder == null)
            {
                return NotFound();
            }

            return Ok(beskeder);
        }

        // PUT: api/Beskeders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeskeder(int id, Beskeder beskeder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beskeder.BeskedId)
            {
                return BadRequest();
            }

            db.Entry(beskeder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeskederExists(id))
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

        // POST: api/Beskeders
        [ResponseType(typeof(Beskeder))]
        public IHttpActionResult PostBeskeder(Beskeder beskeder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Beskeders.Add(beskeder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = beskeder.BeskedId }, beskeder);
        }

        // DELETE: api/Beskeders/5
        [ResponseType(typeof(Beskeder))]
        public IHttpActionResult DeleteBeskeder(int id)
        {
            Beskeder beskeder = db.Beskeders.Find(id);
            if (beskeder == null)
            {
                return NotFound();
            }

            db.Beskeders.Remove(beskeder);
            db.SaveChanges();

            return Ok(beskeder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeskederExists(int id)
        {
            return db.Beskeders.Count(e => e.BeskedId == id) > 0;
        }
    }
}