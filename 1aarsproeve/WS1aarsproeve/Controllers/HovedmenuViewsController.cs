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
    public class HovedmenuViewsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/HovedmenuViews
        public IQueryable<HovedmenuView> GetHovedmenuViews()
        {
            return db.HovedmenuViews;
        }

        // GET: api/HovedmenuViews/5
        [ResponseType(typeof(HovedmenuView))]
        public IHttpActionResult GetHovedmenuView(int id)
        {
            HovedmenuView hovedmenuView = db.HovedmenuViews.Find(id);
            if (hovedmenuView == null)
            {
                return NotFound();
            }

            return Ok(hovedmenuView);
        }

        // PUT: api/HovedmenuViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHovedmenuView(int id, HovedmenuView hovedmenuView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hovedmenuView.BeskedId)
            {
                return BadRequest();
            }

            db.Entry(hovedmenuView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HovedmenuViewExists(id))
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

        // POST: api/HovedmenuViews
        [ResponseType(typeof(HovedmenuView))]
        public IHttpActionResult PostHovedmenuView(HovedmenuView hovedmenuView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HovedmenuViews.Add(hovedmenuView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HovedmenuViewExists(hovedmenuView.BeskedId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hovedmenuView.BeskedId }, hovedmenuView);
        }

        // DELETE: api/HovedmenuViews/5
        [ResponseType(typeof(HovedmenuView))]
        public IHttpActionResult DeleteHovedmenuView(int id)
        {
            HovedmenuView hovedmenuView = db.HovedmenuViews.Find(id);
            if (hovedmenuView == null)
            {
                return NotFound();
            }

            db.HovedmenuViews.Remove(hovedmenuView);
            db.SaveChanges();

            return Ok(hovedmenuView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HovedmenuViewExists(int id)
        {
            return db.HovedmenuViews.Count(e => e.BeskedId == id) > 0;
        }
    }
}