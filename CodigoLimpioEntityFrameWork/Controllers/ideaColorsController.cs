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
    public class ideaColorsController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: ideaColors
        public ActionResult Index()
        {
            var ideaColor = db.ideaColor.Include(i => i.Color).Include(i => i.Idea);
            return View(ideaColor.ToList());
        }

        // GET: ideaColors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaColor ideaColor = db.ideaColor.Find(id);
            if (ideaColor == null)
            {
                return HttpNotFound();
            }
            return View(ideaColor);
        }

        // GET: ideaColors/Create
        public ActionResult Create(int id)
        {
            ViewBag.idIdea = id; // Aquí pasas el ID de la idea
            ViewBag.idColor = new SelectList(db.Color, "idColor", "nombreColor");
            return View();
        }


        // POST: ideaColors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idIdea,idColor")] ideaColor ideaColor)
        {
            if (ModelState.IsValid)
            {
                db.ideaColor.Add(ideaColor);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.idColor = new SelectList(db.Color, "idColor", "nombreColor", ideaColor.idColor);
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaColor.idIdea);
            return View(ideaColor);
        }

        // GET: ideaColors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaColor ideaColor = db.ideaColor.Find(id);
            if (ideaColor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idColor = new SelectList(db.Color, "idColor", "nombreColor", ideaColor.idColor);
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaColor.idIdea);
            return View(ideaColor);
        }

        // POST: ideaColors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idIdea,idColor")] ideaColor ideaColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idColor = new SelectList(db.Color, "idColor", "nombreColor", ideaColor.idColor);
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", ideaColor.idIdea);
            return View(ideaColor);
        }

        // GET: ideaColors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ideaColor ideaColor = db.ideaColor.Find(id);
            if (ideaColor == null)
            {
                return HttpNotFound();
            }
            return View(ideaColor);
        }

        // POST: ideaColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ideaColor ideaColor = db.ideaColor.Find(id);
            db.ideaColor.Remove(ideaColor);
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
