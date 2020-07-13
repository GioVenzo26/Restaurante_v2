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
    public class productosmenuController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: productosmenu
        public ActionResult Index()
        {
            var productosmenu = db.productosmenu.Include(p => p.menu1).Include(p => p.producto1);
            return View(productosmenu.ToList());
        }

        // GET: productosmenu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productosmenu productosmenu = db.productosmenu.Find(id);
            if (productosmenu == null)
            {
                return HttpNotFound();
            }
            return View(productosmenu);
        }

        // GET: productosmenu/Create
        public ActionResult Create()
        {
            ViewBag.menu = new SelectList(db.menu, "id", "id");
            ViewBag.producto = new SelectList(db.producto, "id", "id");
            return View();
        }

        // POST: productosmenu/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,producto,menu")] productosmenu productosmenu)
        {
            if (ModelState.IsValid)
            {
                db.productosmenu.Add(productosmenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.menu = new SelectList(db.menu, "id", "id", productosmenu.menu);
            ViewBag.producto = new SelectList(db.producto, "id", "id", productosmenu.producto);
            return View(productosmenu);
        }

        // GET: productosmenu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productosmenu productosmenu = db.productosmenu.Find(id);
            if (productosmenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.menu = new SelectList(db.menu, "id", "id", productosmenu.menu);
            ViewBag.producto = new SelectList(db.producto, "id", "id", productosmenu.producto);
            return View(productosmenu);
        }

        // POST: productosmenu/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,producto,menu")] productosmenu productosmenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosmenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.menu = new SelectList(db.menu, "id", "id", productosmenu.menu);
            ViewBag.producto = new SelectList(db.producto, "id", "id", productosmenu.producto);
            return View(productosmenu);
        }

        // GET: productosmenu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productosmenu productosmenu = db.productosmenu.Find(id);
            if (productosmenu == null)
            {
                return HttpNotFound();
            }
            return View(productosmenu);
        }

        // POST: productosmenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productosmenu productosmenu = db.productosmenu.Find(id);
            db.productosmenu.Remove(productosmenu);
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
