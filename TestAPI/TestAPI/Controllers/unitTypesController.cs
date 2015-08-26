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
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class unitTypesController : ApiController
    {
        private TestDBContext db = new TestDBContext();

        // GET: api/unitTypes
        public IQueryable<unitType> GetunitType()
        {
            return db.unitType;
        }

        // GET: api/unitTypes/5
        [ResponseType(typeof(unitType))]
        public IHttpActionResult GetunitType(int id)
        {
            unitType unitType = db.unitType.Find(id);
            if (unitType == null)
            {
                return NotFound();
            }

            return Ok(unitType);
        }

        // PUT: api/unitTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutunitType(int id, unitType unitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitType.unitTypeID)
            {
                return BadRequest();
            }

            db.Entry(unitType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!unitTypeExists(id))
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

        // POST: api/unitTypes
        [ResponseType(typeof(unitType))]
        public IHttpActionResult PostunitType(unitType unitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.unitType.Add(unitType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unitType.unitTypeID }, unitType);
        }

        // DELETE: api/unitTypes/5
        [ResponseType(typeof(unitType))]
        public IHttpActionResult DeleteunitType(int id)
        {
            unitType unitType = db.unitType.Find(id);
            if (unitType == null)
            {
                return NotFound();
            }

            db.unitType.Remove(unitType);
            db.SaveChanges();

            return Ok(unitType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool unitTypeExists(int id)
        {
            return db.unitType.Count(e => e.unitTypeID == id) > 0;
        }
    }
}