using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using irg.Common.Models;
using irg.Domain.Models;

namespace irg.Api.Controllers
{
    public class PagosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Pagos
        public IQueryable<Pagos> GetPagos()
        {
            return db.Pagos;
        }

        // GET: api/Pagos/5
        [ResponseType(typeof(Pagos))]
        public async Task<IHttpActionResult> GetPagos(int id)
        {
            Pagos pagos = await db.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            return Ok(pagos);
        }

        // PUT: api/Pagos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPagos(int id, Pagos pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagos.id)
            {
                return BadRequest();
            }

            db.Entry(pagos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagosExists(id))
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

        // POST: api/Pagos
        [ResponseType(typeof(Pagos))]
        public async Task<IHttpActionResult> PostPagos(Pagos pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pagos.Add(pagos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pagos.id }, pagos);
        }

        // DELETE: api/Pagos/5
        [ResponseType(typeof(Pagos))]
        public async Task<IHttpActionResult> DeletePagos(int id)
        {
            Pagos pagos = await db.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            db.Pagos.Remove(pagos);
            await db.SaveChangesAsync();

            return Ok(pagos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PagosExists(int id)
        {
            return db.Pagos.Count(e => e.id == id) > 0;
        }
    }
}