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
    public class AnmodningerViewsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/AnmodningerViews
        public IQueryable<AnmodningerView> GetAnmodningerViews()
        {
            return db.AnmodningerViews;
        }

        // GET: api/AnmodningerViews/5
        [ResponseType(typeof(AnmodningerView))]
        public IHttpActionResult GetAnmodningerView(int id)
        {
            AnmodningerView anmodningerView = db.AnmodningerViews.Find(id);
            if (anmodningerView == null)
            {
                return NotFound();
            }

            return Ok(anmodningerView);
        }

        // PUT: api/AnmodningerViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnmodningerView(int id, AnmodningerView anmodningerView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anmodningerView.AnmodningId)
            {
                return BadRequest();
            }

            db.Entry(anmodningerView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnmodningerViewExists(id))
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

        // POST: api/AnmodningerViews
        [ResponseType(typeof(AnmodningerView))]
        public IHttpActionResult PostAnmodningerView(AnmodningerView anmodningerView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnmodningerViews.Add(anmodningerView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnmodningerViewExists(anmodningerView.AnmodningId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = anmodningerView.AnmodningId }, anmodningerView);
        }

        // DELETE: api/AnmodningerViews/5
        [ResponseType(typeof(AnmodningerView))]
        public IHttpActionResult DeleteAnmodningerView(int id)
        {
            AnmodningerView anmodningerView = db.AnmodningerViews.Find(id);
            if (anmodningerView == null)
            {
                return NotFound();
            }

            db.AnmodningerViews.Remove(anmodningerView);
            db.SaveChanges();

            return Ok(anmodningerView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnmodningerViewExists(int id)
        {
            return db.AnmodningerViews.Count(e => e.AnmodningId == id) > 0;
        }
    }
}