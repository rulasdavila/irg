using System;
using System.Collections.Generic;
using System.Linq;
namespace irg.Api.Controllers
{
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

    public class AsistenciaController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Pagos
        public IQueryable<Asistencia> GetAsistencias()
        {
            return db.Asistencias;
        }

        // GET: api/Pagos/5
        [ResponseType(typeof(Asistencia))]
        public async Task<IHttpActionResult> GetAsistencias(int id)
        {
            Asistencia asistencia = await db.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return Ok(asistencia);
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
