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
    public class camareroController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: camarero
        public ActionResult Index()
        {
            return View(db.camarero.ToList());
        }

        // GET: camarero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camarero camarero = db.camarero.Find(id);
            if (camarero == null)
            {
                return HttpNotFound();
            }
            return View(camarero);
        }

        // GET: camarero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: camarero/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellido,foto")] camarero camarero)
        {
            if (ModelState.IsValid)
            {
                db.camarero.Add(camarero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camarero);
        }

        // GET: camarero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camarero camarero = db.camarero.Find(id);
            if (camarero == null)
            {
                return HttpNotFound();
            }
            return View(camarero);
        }

        // POST: camarero/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido,foto")] camarero camarero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camarero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camarero);
        }

        // GET: camarero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camarero camarero = db.camarero.Find(id);
            if (camarero == null)
            {
                return HttpNotFound();
            }
            return View(camarero);
        }

        // POST: camarero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            camarero camarero = db.camarero.Find(id);
            db.camarero.Remove(camarero);
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
