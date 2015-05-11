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
    public class StillingersController : ApiController
    {
        private TableContext db = new TableContext();

        // GET: api/Stillingers
        public IQueryable<Stillinger> GetStillingers()
        {
            return db.Stillingers;
        }

        // GET: api/Stillingers/5
        [ResponseType(typeof(Stillinger))]
        public IHttpActionResult GetStillinger(int id)
        {
            Stillinger stillinger = db.Stillingers.Find(id);
            if (stillinger == null)
            {
                return NotFound();
            }

            return Ok(stillinger);
        }

        // PUT: api/Stillingers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStillinger(int id, Stillinger stillinger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stillinger.StillingId)
            {
                return BadRequest();
            }

            db.Entry(stillinger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StillingerExists(id))
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

        // POST: api/Stillingers
        [ResponseType(typeof(Stillinger))]
        public IHttpActionResult PostStillinger(Stillinger stillinger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stillingers.Add(stillinger);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stillinger.StillingId }, stillinger);
        }

        // DELETE: api/Stillingers/5
        [ResponseType(typeof(Stillinger))]
        public IHttpActionResult DeleteStillinger(int id)
        {
            Stillinger stillinger = db.Stillingers.Find(id);
            if (stillinger == null)
            {
                return NotFound();
            }

            db.Stillingers.Remove(stillinger);
            db.SaveChanges();

            return Ok(stillinger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StillingerExists(int id)
        {
            return db.Stillingers.Count(e => e.StillingId == id) > 0;
        }
    }
}