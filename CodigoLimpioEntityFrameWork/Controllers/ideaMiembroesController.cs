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
    public class ideaMiembroesController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: ideaMiembroes
        public ActionResult Index()
        {
            var ideaMiembro = db.ideaMiembro.Include(i => i.Idea).Include(i => i.Miembro);
            return View(ideaMiembro.ToList());
        }

        // GET: ideaMiembroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaMiembro ideaMiembro = db.ideaMiembro.Find(id);
            if (ideaMiembro == null)
            {
                return HttpNotFound();
            }
            return View(ideaMiembro);
        }

        // GET: ideaMiembroes/Create
        public ActionResult Create()
        {
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea");
            ViewBag.idMiembro = new SelectList(db.Miembro, "idMiembro", "nombreMiembro");
            return View();
        }

        // POST: ideaMiembroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idIdea,idMiembro")] ideaMiembro ideaMiembro)
        {
            if (ModelState.IsValid)
            {
                db.ideaMiembro.Add(ideaMiembro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaMiembro.idIdea);
            ViewBag.idMiembro = new SelectList(db.Miembro, "idMiembro", "nombreMiembro", ideaMiembro.idMiembro);
            return View(ideaMiembro);
        }

        // GET: ideaMiembroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaMiembro ideaMiembro = db.ideaMiembro.Find(id);
            if (ideaMiembro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaMiembro.idIdea);
            ViewBag.idMiembro = new SelectList(db.Miembro, "idMiembro", "nombreMiembro", ideaMiembro.idMiembro);
            return View(ideaMiembro);
        }

        // POST: ideaMiembroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idIdea,idMiembro")] ideaMiembro ideaMiembro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaMiembro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaMiembro.idIdea);
            ViewBag.idMiembro = new SelectList(db.Miembro, "idMiembro", "nombreMiembro", ideaMiembro.idMiembro);
            return View(ideaMiembro);
        }

        // GET: ideaMiembroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaMiembro ideaMiembro = db.ideaMiembro.Find(id);
            if (ideaMiembro == null)
            {
                return HttpNotFound();
            }
            return View(ideaMiembro);
        }

        // POST: ideaMiembroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ideaMiembro ideaMiembro = db.ideaMiembro.Find(id);
            db.ideaMiembro.Remove(ideaMiembro);
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
