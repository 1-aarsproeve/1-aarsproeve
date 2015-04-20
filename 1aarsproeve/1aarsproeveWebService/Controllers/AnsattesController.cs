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
    public class AnsattesController : ApiController
    {
        private DataTableContext db = new DataTableContext();

        // GET: api/Ansattes
        public IQueryable<Ansatte> GetAnsattes()
        {
            return db.Ansattes;
        }

        // GET: api/Ansattes/5
        [ResponseType(typeof(Ansatte))]
        public IHttpActionResult GetAnsatte(string id)
        {
            Ansatte ansatte = db.Ansattes.Find(id);
            if (ansatte == null)
            {
                return NotFound();
            }

            return Ok(ansatte);
        }

        // PUT: api/Ansattes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnsatte(string id, Ansatte ansatte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ansatte.Brugernavn)
            {
                return BadRequest();
            }

            db.Entry(ansatte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnsatteExists(id))
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

        // POST: api/Ansattes
        [ResponseType(typeof(Ansatte))]
        public IHttpActionResult PostAnsatte(Ansatte ansatte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ansattes.Add(ansatte);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnsatteExists(ansatte.Brugernavn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ansatte.Brugernavn }, ansatte);
        }

        // DELETE: api/Ansattes/5
        [ResponseType(typeof(Ansatte))]
        public IHttpActionResult DeleteAnsatte(string id)
        {
            Ansatte ansatte = db.Ansattes.Find(id);
            if (ansatte == null)
            {
                return NotFound();
            }

            db.Ansattes.Remove(ansatte);
            db.SaveChanges();

            return Ok(ansatte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnsatteExists(string id)
        {
            return db.Ansattes.Count(e => e.Brugernavn == id) > 0;
        }
    }
}