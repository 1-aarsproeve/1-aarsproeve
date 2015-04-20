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
using _1aarsproeveWebService;

namespace _1aarsproeveWebService.Controllers
{
    public class VagtersViewController : ApiController
    {
        private DataViewContext db = new DataViewContext();

        // GET: api/VagtersView
        public IQueryable<Vagter> GetVagters()
        {
            return db.Vagters;
        }

        // GET: api/VagtersView/5
        [ResponseType(typeof(Vagter))]
        public IHttpActionResult GetVagter(int id)
        {
            Vagter vagter = db.Vagters.Find(id);
            if (vagter == null)
            {
                return NotFound();
            }

            return Ok(vagter);
        }

        // PUT: api/VagtersView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVagter(int id, Vagter vagter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vagter.VagtId)
            {
                return BadRequest();
            }

            db.Entry(vagter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagterExists(id))
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

        // POST: api/VagtersView
        [ResponseType(typeof(Vagter))]
        public IHttpActionResult PostVagter(Vagter vagter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vagters.Add(vagter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vagter.VagtId }, vagter);
        }

        // DELETE: api/VagtersView/5
        [ResponseType(typeof(Vagter))]
        public IHttpActionResult DeleteVagter(int id)
        {
            Vagter vagter = db.Vagters.Find(id);
            if (vagter == null)
            {
                return NotFound();
            }

            db.Vagters.Remove(vagter);
            db.SaveChanges();

            return Ok(vagter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VagterExists(int id)
        {
            return db.Vagters.Count(e => e.VagtId == id) > 0;
        }
    }
}