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
    public class AnsatteViewsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/AnsatteViews
        public IQueryable<AnsatteView> GetAnsatteViews()
        {
            return db.AnsatteViews;
        }

        // GET: api/AnsatteViews/5
        [ResponseType(typeof(AnsatteView))]
        public IHttpActionResult GetAnsatteView(string id)
        {
            AnsatteView ansatteView = db.AnsatteViews.Find(id);
            if (ansatteView == null)
            {
                return NotFound();
            }

            return Ok(ansatteView);
        }

        // PUT: api/AnsatteViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnsatteView(string id, AnsatteView ansatteView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ansatteView.Brugernavn)
            {
                return BadRequest();
            }

            db.Entry(ansatteView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnsatteViewExists(id))
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

        // POST: api/AnsatteViews
        [ResponseType(typeof(AnsatteView))]
        public IHttpActionResult PostAnsatteView(AnsatteView ansatteView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnsatteViews.Add(ansatteView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnsatteViewExists(ansatteView.Brugernavn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ansatteView.Brugernavn }, ansatteView);
        }

        // DELETE: api/AnsatteViews/5
        [ResponseType(typeof(AnsatteView))]
        public IHttpActionResult DeleteAnsatteView(string id)
        {
            AnsatteView ansatteView = db.AnsatteViews.Find(id);
            if (ansatteView == null)
            {
                return NotFound();
            }

            db.AnsatteViews.Remove(ansatteView);
            db.SaveChanges();

            return Ok(ansatteView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnsatteViewExists(string id)
        {
            return db.AnsatteViews.Count(e => e.Brugernavn == id) > 0;
        }
    }
}