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
using WebRestaurante.Models;

namespace WebRestaurante.Controllers
{
    public class PratosController : ApiController
    {
        private ModelRestaurante db = new ModelRestaurante();

        // GET: api/Pratos
        public IQueryable<Pratos> GetPratos()
        {
            return db.Pratos;
        }

        // GET: api/Pratos/5
        [ResponseType(typeof(Pratos))]
        public IHttpActionResult GetPratos(int id)
        {
            Pratos pratos = db.Pratos.Find(id);
            if (pratos == null)
            {
                return NotFound();
            }

            return Ok(pratos);
        }

        // PUT: api/Pratos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPratos(int id, Pratos pratos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pratos.Id_Prato)
            {
                return BadRequest();
            }

            db.Entry(pratos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PratosExists(id))
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

        // POST: api/Pratos
        [ResponseType(typeof(Pratos))]
        public IHttpActionResult PostPratos(Pratos pratos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pratos.Add(pratos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pratos.Id_Prato }, pratos);
        }

        // DELETE: api/Pratos/5
        [ResponseType(typeof(Pratos))]
        public IHttpActionResult DeletePratos(int id)
        {
            Pratos pratos = db.Pratos.Find(id);
            if (pratos == null)
            {
                return NotFound();
            }

            db.Pratos.Remove(pratos);
            db.SaveChanges();

            return Ok(pratos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PratosExists(int id)
        {
            return db.Pratos.Count(e => e.Id_Prato == id) > 0;
        }
    }
}