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
    public class tipoproductoController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: tipoproducto
        public ActionResult Index()
        {
            return View(db.tipoproducto.ToList());
        }

        // GET: tipoproducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoproducto tipoproducto = db.tipoproducto.Find(id);
            if (tipoproducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoproducto);
        }

        // GET: tipoproducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoproducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tipoproducto tipoproducto)
        {
            if (ModelState.IsValid)
            {
                db.tipoproducto.Add(tipoproducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoproducto);
        }

        // GET: tipoproducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoproducto tipoproducto = db.tipoproducto.Find(id);
            if (tipoproducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoproducto);
        }

        // POST: tipoproducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tipoproducto tipoproducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoproducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoproducto);
        }

        // GET: tipoproducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoproducto tipoproducto = db.tipoproducto.Find(id);
            if (tipoproducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoproducto);
        }

        // POST: tipoproducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoproducto tipoproducto = db.tipoproducto.Find(id);
            db.tipoproducto.Remove(tipoproducto);
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
