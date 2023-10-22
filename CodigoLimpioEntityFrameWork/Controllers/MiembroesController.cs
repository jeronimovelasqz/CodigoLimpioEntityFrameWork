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
    public class MiembroesController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: Miembroes
        public ActionResult Index()
        {
            return View(db.Miembro.ToList());
        }

        // GET: Miembroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembro.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // GET: Miembroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Miembroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMiembro,nombreMiembro,apellidoMiembro,cedulaMiembro,correoMiembro")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                db.Miembro.Add(miembro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miembro);
        }

        // GET: Miembroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembro.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // POST: Miembroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMiembro,nombreMiembro,apellidoMiembro,cedulaMiembro,correoMiembro")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miembro);
        }

        // GET: Miembroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembro.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // POST: Miembroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembro miembro = db.Miembro.Find(id);
            db.Miembro.Remove(miembro);
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
