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
    public class pedidoController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: pedido
        public ActionResult Index()
        {
            var pedido = db.pedido.Include(p => p.camarero1).Include(p => p.cliente1).Include(p => p.mesa1);
            return View(pedido.ToList());
        }

        // GET: pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: pedido/Create
        public ActionResult Create()
        {
            ViewBag.camarero = new SelectList(db.camarero, "id", "nombre");
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre");
            ViewBag.mesa = new SelectList(db.mesa, "id", "id");
            return View();
        }

        // POST: pedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,precio,pagado,confirmado,servido,activo,cliente,mesa,camarero")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.camarero = new SelectList(db.camarero, "id", "nombre", pedido.camarero);
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre", pedido.cliente);
            ViewBag.mesa = new SelectList(db.mesa, "id", "id", pedido.mesa);
            return View(pedido);
        }

        // GET: pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.camarero = new SelectList(db.camarero, "id", "nombre", pedido.camarero);
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre", pedido.cliente);
            ViewBag.mesa = new SelectList(db.mesa, "id", "id", pedido.mesa);
            return View(pedido);
        }

        // POST: pedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,precio,pagado,confirmado,servido,activo,cliente,mesa,camarero")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.camarero = new SelectList(db.camarero, "id", "nombre", pedido.camarero);
            ViewBag.cliente = new SelectList(db.cliente, "id", "nombre", pedido.cliente);
            ViewBag.mesa = new SelectList(db.mesa, "id", "id", pedido.mesa);
            return View(pedido);
        }

        // GET: pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedido pedido = db.pedido.Find(id);
            db.pedido.Remove(pedido);
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
