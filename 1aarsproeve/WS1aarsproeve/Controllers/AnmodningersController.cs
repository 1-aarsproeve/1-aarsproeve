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
    public class AnmodningersController : ApiController
    {
        private TableContext db = new TableContext();

        // GET: api/Anmodningers
        public IQueryable<Anmodninger> GetAnmodningers()
        {
            return db.Anmodningers;
        }

        // GET: api/Anmodningers/5
        [ResponseType(typeof(Anmodninger))]
        public IHttpActionResult GetAnmodninger(int id)
        {
            Anmodninger anmodninger = db.Anmodningers.Find(id);
            if (anmodninger == null)
            {
                return NotFound();
            }

            return Ok(anmodninger);
        }

        // PUT: api/Anmodningers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnmodninger(int id, Anmodninger anmodninger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anmodninger.AnmodningId)
            {
                return BadRequest();
            }

            db.Entry(anmodninger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnmodningerExists(id))
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

        // POST: api/Anmodningers
        [ResponseType(typeof(Anmodninger))]
        public IHttpActionResult PostAnmodninger(Anmodninger anmodninger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anmodningers.Add(anmodninger);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anmodninger.AnmodningId }, anmodninger);
        }

        // DELETE: api/Anmodningers/5
        [ResponseType(typeof(Anmodninger))]
        public IHttpActionResult DeleteAnmodninger(int id)
        {
            Anmodninger anmodninger = db.Anmodningers.Find(id);
            if (anmodninger == null)
            {
                return NotFound();
            }

            db.Anmodningers.Remove(anmodninger);
            db.SaveChanges();

            return Ok(anmodninger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnmodningerExists(int id)
        {
            return db.Anmodningers.Count(e => e.AnmodningId == id) > 0;
        }
    }
}