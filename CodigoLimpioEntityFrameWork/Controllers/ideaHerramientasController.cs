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
    public class ideaHerramientasController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: ideaHerramientas
        public ActionResult Index()
        {
            var ideaHerramienta = db.ideaHerramienta.Include(i => i.Herramienta).Include(i => i.Idea);
            return View(ideaHerramienta.ToList());
        }

        // GET: ideaHerramientas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaHerramienta ideaHerramienta = db.ideaHerramienta.Find(id);
            if (ideaHerramienta == null)
            {
                return HttpNotFound();
            }
            return View(ideaHerramienta);
        }

        // GET: ideaHerramientas/Create
        public ActionResult Create(int id)
        {
            ViewBag.idIdea = id; // Aquí pasas el ID de la idea
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "nombreHerramienta");
            ViewBag.Herramientas = db.Herramienta.ToList(); // Aquí pasas la lista de herramientas a la vista
            return View();
        }

        // POST: ideaHerramientas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idIdea,idHerramienta")] ideaHerramienta ideaHerramienta)
        {
            if (ModelState.IsValid)
            {
                db.ideaHerramienta.Add(ideaHerramienta);
                db.SaveChanges();
                return RedirectToAction("Create", new { id = ideaHerramienta.idIdea });
            }

            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "nombreHerramienta", ideaHerramienta.idHerramienta);
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaHerramienta.idIdea);
            ViewBag.Herramientas = db.Herramienta.ToList(); // Aquí pasas la lista de herramientas a la vista
            return View(ideaHerramienta);
        }



        // GET: ideaHerramientas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaHerramienta ideaHerramienta = db.ideaHerramienta.Find(id);
            if (ideaHerramienta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "nombreHerramienta", ideaHerramienta.idHerramienta);
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaHerramienta.idIdea);
            return View(ideaHerramienta);
        }

        // POST: ideaHerramientas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idIdea,idHerramienta")] ideaHerramienta ideaHerramienta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaHerramienta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "nombreHerramienta", ideaHerramienta.idHerramienta);
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaHerramienta.idIdea);
            return View(ideaHerramienta);
        }

        // GET: ideaHerramientas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaHerramienta ideaHerramienta = db.ideaHerramienta.Find(id);
            if (ideaHerramienta == null)
            {
                return HttpNotFound();
            }
            return View(ideaHerramienta);
        }

        // POST: ideaHerramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ideaHerramienta ideaHerramienta = db.ideaHerramienta.Find(id);
            db.ideaHerramienta.Remove(ideaHerramienta);
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
