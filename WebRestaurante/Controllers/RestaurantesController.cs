﻿using System;
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
    public class RestaurantesController : ApiController
    {
        private ModelRestaurante db = new ModelRestaurante();

        // GET: api/Restaurantes
        public IQueryable<Restaurantes> GetRestaurantes()
        {
            return db.Restaurantes;
        }

        // GET: api/Restaurantes/5
        [ResponseType(typeof(Restaurantes))]
        public IHttpActionResult GetRestaurantes(int id)
        {
            Restaurantes restaurantes = db.Restaurantes.Find(id);
            if (restaurantes == null)
            {
                return NotFound();
            }

            return Ok(restaurantes);
        }

        // GET: api/Restaurantes/5
        [ResponseType(typeof(Restaurantes))]
        public IHttpActionResult GetRestaurantes(string nome)
        {
            var queyresult =  db.Restaurantes.Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            

            if (queyresult == null)
            {
                return NotFound();
            }

            return Ok(queyresult);
        }

        // PUT: api/Restaurantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurantes(int id, Restaurantes restaurantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantes.Id_restaurante)
            {
                return BadRequest();
            }

            db.Entry(restaurantes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantesExists(id))
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

        // POST: api/Restaurantes
        [ResponseType(typeof(Restaurantes))]
        public IHttpActionResult PostRestaurantes(Restaurantes restaurantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurantes.Add(restaurantes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurantes.Id_restaurante }, restaurantes);
        }

        // DELETE: api/Restaurantes/5
        [ResponseType(typeof(Restaurantes))]
        public IHttpActionResult DeleteRestaurantes(int id)
        {
            Restaurantes restaurantes = db.Restaurantes.Find(id);
            if (restaurantes == null)
            {
                return NotFound();
            }

            db.Restaurantes.Remove(restaurantes);
            db.SaveChanges();

            return Ok(restaurantes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantesExists(int id)
        {
            return db.Restaurantes.Count(e => e.Id_restaurante == id) > 0;
        }
    }
}