using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodigoLimpioEntityFrameWork.Models;

namespace CodigoLimpioEntityFrameWork.Controllers
{
    public class HerramientasController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: Herramientas
        public ActionResult Index()
        {
            return View(db.Herramienta.ToList());
        }

        // GET: Herramientas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta herramienta = db.Herramienta.Find(id);
            if (herramienta == null)
            {
                return HttpNotFound();
            }
            return View(herramienta);
        }

        // GET: Herramientas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herramientas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHerramienta,nombreHerramienta")] Herramienta herramienta)
        {
            if (ModelState.IsValid)
            {
                db.Herramienta.Add(herramienta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herramienta);
        }

        // GET: Herramientas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta herramienta = db.Herramienta.Find(id);
            if (herramienta == null)
            {
                return HttpNotFound();
            }
            return View(herramienta);
        }

        // POST: Herramientas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHerramienta,nombreHerramienta")] Herramienta herramienta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herramienta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herramienta);
        }

        // GET: Herramientas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta herramienta = db.Herramienta.Find(id);
            if (herramienta == null)
            {
                return HttpNotFound();
            }
            return View(herramienta);
        }

        // POST: Herramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herramienta herramienta = db.Herramienta.Find(id);

            // Eliminar los registros relacionados en ideaHerramienta
            foreach (var ideaHerramienta in herramienta.ideaHerramienta.ToList())
            {
                db.ideaHerramienta.Remove(ideaHerramienta);
            }

            // Ahora puedes eliminar la Herramienta
            db.Herramienta.Remove(herramienta);

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
