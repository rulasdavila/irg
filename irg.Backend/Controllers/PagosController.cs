using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using irg.Backend.Models;
using irg.Common.Models;

namespace irg.Backend.Controllers
{
    public class PagosController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Pagos
        public async Task<ActionResult> Index()
        {
            return View(await db.Pagos.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = await db.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Clave_Instituto,Folio,Matricula,Clave_Concepto,CC,ME,CV,LI,NA,Detalles,Fecha,Costo,Recargos,Pagado,Total_Calculado,Usuario,Ano,No_Cuatrimestre,F_Bancario,Cancelado,H_Clase,Detalle_Descuento,Fecha_Bancos,Forma_Pago,Estatus,Factura")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                db.Pagos.Add(pagos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = await db.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Clave_Instituto,Folio,Matricula,Clave_Concepto,CC,ME,CV,LI,NA,Detalles,Fecha,Costo,Recargos,Pagado,Total_Calculado,Usuario,Ano,No_Cuatrimestre,F_Bancario,Cancelado,H_Clase,Detalle_Descuento,Fecha_Bancos,Forma_Pago,Estatus,Factura")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = await db.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pagos pagos = await db.Pagos.FindAsync(id);
            db.Pagos.Remove(pagos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
