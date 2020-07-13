using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using restaurante.Models;

namespace restaurante.Controllers
{
    public class reservaController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: reserva
        public ActionResult Index()
        {
            var reserva = db.reserva.Include(r => r.cliente1).Include(r => r.mesa1);
            return View(reserva.ToList());
        }

        // GET: reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: reserva/Create
        public ActionResult Create()
        {
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre");
            ViewBag.mesa = new SelectList(db.mesa, "id", "id");
            return View();
        }

        // POST: reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,finalizada,cliente,mesa")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre", reserva.cliente);
            ViewBag.mesa = new SelectList(db.mesa, "id", "id", reserva.mesa);
            return View(reserva);
        }

        // GET: reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre", reserva.cliente);
            ViewBag.mesa = new SelectList(db.mesa, "id", "id", reserva.mesa);
            return View(reserva);
        }

        // POST: reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,finalizada,cliente,mesa")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre", reserva.cliente);
            ViewBag.mesa = new SelectList(db.mesa, "id", "id", reserva.mesa);
            return View(reserva);
        }

        // GET: reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reserva reserva = db.reserva.Find(id);
            db.reserva.Remove(reserva);
            db.SaveChanges();
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
