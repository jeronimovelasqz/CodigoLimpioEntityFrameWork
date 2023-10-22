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
    public class IdeasController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();

        // GET: Ideas
        public ActionResult Index()
        {
            return View(db.Idea.ToList());
        }

        // GET: Ideas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Idea idea = db.Idea.Find(id);

            if (idea == null)
            {
                return HttpNotFound();
            }

            // Cargar los datos en la memoria
            var ideaColors = idea.ideaColor.ToList();
            var departamentoColors = db.DepartamentoColor.ToList();

            // Recuperar los departamentos asociados con la idea
            var departamentos = departamentoColors
                .Where(dc => ideaColors.Any(ic => ic.idColor == dc.idColor))
                .Select(dc => dc.Departamento)
                .Distinct()  // Agregar Distinct() aquí para eliminar duplicados
                .ToList();

            // Pasar los departamentos a la vista
            ViewBag.Departamentos = departamentos;

            return View(idea);
        }




        // GET: Ideas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ideas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Ideas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIdea,nombreIdea,inversionRequerida,ingresosObjetivos,inversionInfraestructura")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Idea.Add(idea);
                    db.SaveChanges();

                    // Redirige al usuario a la vista 'Create' del controlador 'ideaMiembro',
                    // pasando el ID de la idea como parámetro
                    return RedirectToAction("Create", "ideaMiembroes", new { id = idea.idIdea });
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }

            return View(idea);
        }



        // GET: Ideas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Idea.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIdea,nombreIdea,inversionRequerida,ingresosObjetivos,inversionInfraestructura")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idea);
        }

        // GET: Ideas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Idea.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idea idea = db.Idea.Find(id);

            // Eliminar los registros relacionados en ideaColor
            foreach (var ideaColor in idea.ideaColor.ToList())
            {
                db.ideaColor.Remove(ideaColor);
            }

            // Eliminar los registros relacionados en ideaMiembro
            foreach (var ideaMiembro in idea.ideaMiembro.ToList())
            {
                db.ideaMiembro.Remove(ideaMiembro);
            }

            // Eliminar los registros relacionados en ideaHerramienta
            foreach (var ideaHerramienta in idea.ideaHerramienta.ToList())
            {
                db.ideaHerramienta.Remove(ideaHerramienta);
            }

            // Eliminar los registros relacionados en DesarrolloRegional
            foreach (var desarrolloRegional in idea.DesarrolloRegional.ToList())
            {
                db.DesarrolloRegional.Remove(desarrolloRegional);
            }

            // Ahora puedes eliminar la Idea
            db.Idea.Remove(idea);

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
