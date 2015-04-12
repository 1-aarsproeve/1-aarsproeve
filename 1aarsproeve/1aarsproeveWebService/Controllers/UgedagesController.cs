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
    public class UgedagesController : ApiController
    {
        private DataTableContext db = new DataTableContext();

        // GET: api/Ugedages
        public IQueryable<Ugedage> GetUgedages()
        {
            return db.Ugedages;
        }

        // GET: api/Ugedages/5
        [ResponseType(typeof(Ugedage))]
        public IHttpActionResult GetUgedage(int id)
        {
            Ugedage ugedage = db.Ugedages.Find(id);
            if (ugedage == null)
            {
                return NotFound();
            }

            return Ok(ugedage);
        }

        // PUT: api/Ugedages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUgedage(int id, Ugedage ugedage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ugedage.UgedagId)
            {
                return BadRequest();
            }

            db.Entry(ugedage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UgedageExists(id))
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

        // POST: api/Ugedages
        [ResponseType(typeof(Ugedage))]
        public IHttpActionResult PostUgedage(Ugedage ugedage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ugedages.Add(ugedage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ugedage.UgedagId }, ugedage);
        }

        // DELETE: api/Ugedages/5
        [ResponseType(typeof(Ugedage))]
        public IHttpActionResult DeleteUgedage(int id)
        {
            Ugedage ugedage = db.Ugedages.Find(id);
            if (ugedage == null)
            {
                return NotFound();
            }

            db.Ugedages.Remove(ugedage);
            db.SaveChanges();

            return Ok(ugedage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UgedageExists(int id)
        {
            return db.Ugedages.Count(e => e.UgedagId == id) > 0;
        }
    }
}