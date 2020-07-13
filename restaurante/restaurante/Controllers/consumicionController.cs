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
    public class consumicionController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: consumicion
        public ActionResult Index()
        {
            var consumicion = db.consumicion.Include(c => c.itemconsumicion1).Include(c => c.pedido1);
            return View(consumicion.ToList());
        }

        // GET: consumicion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumicion consumicion = db.consumicion.Find(id);
            if (consumicion == null)
            {
                return HttpNotFound();
            }
            return View(consumicion);
        }

        // GET: consumicion/Create
        public ActionResult Create()
        {
            ViewBag.itemconsumicion = new SelectList(db.itemconsumicion, "id", "tipo");
            ViewBag.pedido = new SelectList(db.pedido, "id", "id");
            return View();
        }

        // POST: consumicion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,precio,servida,pedido,itemconsumicion")] consumicion consumicion)
        {
            if (ModelState.IsValid)
            {
                db.consumicion.Add(consumicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemconsumicion = new SelectList(db.itemconsumicion, "id", "tipo", consumicion.itemconsumicion);
            ViewBag.pedido = new SelectList(db.pedido, "id", "id", consumicion.pedido);
            return View(consumicion);
        }

        // GET: consumicion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumicion consumicion = db.consumicion.Find(id);
            if (consumicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemconsumicion = new SelectList(db.itemconsumicion, "id", "tipo", consumicion.itemconsumicion);
            ViewBag.pedido = new SelectList(db.pedido, "id", "id", consumicion.pedido);
            return View(consumicion);
        }

        // POST: consumicion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,precio,servida,pedido,itemconsumicion")] consumicion consumicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemconsumicion = new SelectList(db.itemconsumicion, "id", "tipo", consumicion.itemconsumicion);
            ViewBag.pedido = new SelectList(db.pedido, "id", "id", consumicion.pedido);
            return View(consumicion);
        }

        // GET: consumicion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumicion consumicion = db.consumicion.Find(id);
            if (consumicion == null)
            {
                return HttpNotFound();
            }
            return View(consumicion);
        }

        // POST: consumicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consumicion consumicion = db.consumicion.Find(id);
            db.consumicion.Remove(consumicion);
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
