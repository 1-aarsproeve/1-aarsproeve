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
    public class AnmodningModelsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/AnmodningModels
        public IQueryable<AnmodningModel> GetAnmodningModels()
        {
            return db.AnmodningModels;
        }

        // GET: api/AnmodningModels/5
        [ResponseType(typeof(AnmodningModel))]
        public IHttpActionResult GetAnmodningModel(int id)
        {
            AnmodningModel anmodningModel = db.AnmodningModels.Find(id);
            if (anmodningModel == null)
            {
                return NotFound();
            }

            return Ok(anmodningModel);
        }

        // PUT: api/AnmodningModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnmodningModel(int id, AnmodningModel anmodningModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anmodningModel.AnmodningId)
            {
                return BadRequest();
            }

            db.Entry(anmodningModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnmodningModelExists(id))
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

        // POST: api/AnmodningModels
        [ResponseType(typeof(AnmodningModel))]
        public IHttpActionResult PostAnmodningModel(AnmodningModel anmodningModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnmodningModels.Add(anmodningModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnmodningModelExists(anmodningModel.AnmodningId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = anmodningModel.AnmodningId }, anmodningModel);
        }

        // DELETE: api/AnmodningModels/5
        [ResponseType(typeof(AnmodningModel))]
        public IHttpActionResult DeleteAnmodningModel(int id)
        {
            AnmodningModel anmodningModel = db.AnmodningModels.Find(id);
            if (anmodningModel == null)
            {
                return NotFound();
            }

            db.AnmodningModels.Remove(anmodningModel);
            db.SaveChanges();

            return Ok(anmodningModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnmodningModelExists(int id)
        {
            return db.AnmodningModels.Count(e => e.AnmodningId == id) > 0;
        }
    }
}