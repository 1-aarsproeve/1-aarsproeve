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
    public class VagtModelsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/VagtModels
        public IQueryable<VagtModel> GetVagtModels()
        {
            return db.VagtModels;
        }

        // GET: api/VagtModels/5
        [ResponseType(typeof(VagtModel))]
        public IHttpActionResult GetVagtModel(TimeSpan id)
        {
            VagtModel vagtModel = db.VagtModels.Find(id);
            if (vagtModel == null)
            {
                return NotFound();
            }

            return Ok(vagtModel);
        }

        // PUT: api/VagtModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVagtModel(TimeSpan id, VagtModel vagtModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vagtModel.Starttidspunkt)
            {
                return BadRequest();
            }

            db.Entry(vagtModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagtModelExists(id))
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

        // POST: api/VagtModels
        [ResponseType(typeof(VagtModel))]
        public IHttpActionResult PostVagtModel(VagtModel vagtModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VagtModels.Add(vagtModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VagtModelExists(vagtModel.Starttidspunkt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vagtModel.Starttidspunkt }, vagtModel);
        }

        // DELETE: api/VagtModels/5
        [ResponseType(typeof(VagtModel))]
        public IHttpActionResult DeleteVagtModel(TimeSpan id)
        {
            VagtModel vagtModel = db.VagtModels.Find(id);
            if (vagtModel == null)
            {
                return NotFound();
            }

            db.VagtModels.Remove(vagtModel);
            db.SaveChanges();

            return Ok(vagtModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VagtModelExists(TimeSpan id)
        {
            return db.VagtModels.Count(e => e.Starttidspunkt == id) > 0;
        }
    }
}