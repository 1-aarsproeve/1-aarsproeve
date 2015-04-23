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
    public class VagtplanViewsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/VagtplanViews
        public IQueryable<VagtplanView> GetVagtplanViews()
        {
            return db.VagtplanViews;
        }

        // GET: api/VagtplanViews/5
        [ResponseType(typeof(VagtplanView))]
        public IHttpActionResult GetVagtplanView(TimeSpan id)
        {
            VagtplanView vagtplanView = db.VagtplanViews.Find(id);
            if (vagtplanView == null)
            {
                return NotFound();
            }

            return Ok(vagtplanView);
        }

        // PUT: api/VagtplanViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVagtplanView(TimeSpan id, VagtplanView vagtplanView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vagtplanView.Starttidspunkt)
            {
                return BadRequest();
            }

            db.Entry(vagtplanView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagtplanViewExists(id))
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

        // POST: api/VagtplanViews
        [ResponseType(typeof(VagtplanView))]
        public IHttpActionResult PostVagtplanView(VagtplanView vagtplanView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VagtplanViews.Add(vagtplanView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VagtplanViewExists(vagtplanView.Starttidspunkt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vagtplanView.Starttidspunkt }, vagtplanView);
        }

        // DELETE: api/VagtplanViews/5
        [ResponseType(typeof(VagtplanView))]
        public IHttpActionResult DeleteVagtplanView(TimeSpan id)
        {
            VagtplanView vagtplanView = db.VagtplanViews.Find(id);
            if (vagtplanView == null)
            {
                return NotFound();
            }

            db.VagtplanViews.Remove(vagtplanView);
            db.SaveChanges();

            return Ok(vagtplanView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VagtplanViewExists(TimeSpan id)
        {
            return db.VagtplanViews.Count(e => e.Starttidspunkt == id) > 0;
        }
    }
}