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
    public class BeskedModelsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/BeskedModels
        public IQueryable<BeskedModel> GetBeskedModels()
        {
            return db.BeskedModels;
        }

        // GET: api/BeskedModels/5
        [ResponseType(typeof(BeskedModel))]
        public IHttpActionResult GetBeskedModel(int id)
        {
            BeskedModel beskedModel = db.BeskedModels.Find(id);
            if (beskedModel == null)
            {
                return NotFound();
            }

            return Ok(beskedModel);
        }

        // PUT: api/BeskedModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeskedModel(int id, BeskedModel beskedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beskedModel.BeskedId)
            {
                return BadRequest();
            }

            db.Entry(beskedModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeskedModelExists(id))
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

        // POST: api/BeskedModels
        [ResponseType(typeof(BeskedModel))]
        public IHttpActionResult PostBeskedModel(BeskedModel beskedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BeskedModels.Add(beskedModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BeskedModelExists(beskedModel.BeskedId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = beskedModel.BeskedId }, beskedModel);
        }

        // DELETE: api/BeskedModels/5
        [ResponseType(typeof(BeskedModel))]
        public IHttpActionResult DeleteBeskedModel(int id)
        {
            BeskedModel beskedModel = db.BeskedModels.Find(id);
            if (beskedModel == null)
            {
                return NotFound();
            }

            db.BeskedModels.Remove(beskedModel);
            db.SaveChanges();

            return Ok(beskedModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeskedModelExists(int id)
        {
            return db.BeskedModels.Count(e => e.BeskedId == id) > 0;
        }
    }
}