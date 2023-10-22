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
    public class DesarrolloRegionalsController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: DesarrolloRegionals
        public ActionResult Index()
        {
            var desarrolloRegional = db.DesarrolloRegional.Include(d => d.Idea);
            return View(desarrolloRegional.ToList());
        }

        // GET: DesarrolloRegionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesarrolloRegional desarrolloRegional = db.DesarrolloRegional.Find(id);
            if (desarrolloRegional == null)
            {
                return HttpNotFound();
            }
            return View(desarrolloRegional);
        }

        // GET: DesarrolloRegionals/Create
        
        public ActionResult Create(int id)
        {
            ViewBag.idIdea = id; // Aquí pasas el ID de la idea
            return View();
        }


        // POST: DesarrolloRegionals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDesarrolloRegional,idIdea")] DesarrolloRegional desarrolloRegional)
        {
            if (ModelState.IsValid)
            {
                db.DesarrolloRegional.Add(desarrolloRegional);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", desarrolloRegional.idIdea);
            return View(desarrolloRegional);
        }

        // GET: DesarrolloRegionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesarrolloRegional desarrolloRegional = db.DesarrolloRegional.Find(id);
            if (desarrolloRegional == null)
            {
                return HttpNotFound();
            }
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", desarrolloRegional.idIdea);
            return View(desarrolloRegional);
        }

        // POST: DesarrolloRegionals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDesarrolloRegional,idIdea")] DesarrolloRegional desarrolloRegional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desarrolloRegional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idIdea = new SelectList(db.Idea, "idIdea", "nombreIdea", desarrolloRegional.idIdea);
            return View(desarrolloRegional);
        }

        // GET: DesarrolloRegionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesarrolloRegional desarrolloRegional = db.DesarrolloRegional.Find(id);
            if (desarrolloRegional == null)
            {
                return HttpNotFound();
            }
            return View(desarrolloRegional);
        }

        // POST: DesarrolloRegionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesarrolloRegional desarrolloRegional = db.DesarrolloRegional.Find(id);
            db.DesarrolloRegional.Remove(desarrolloRegional);
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
