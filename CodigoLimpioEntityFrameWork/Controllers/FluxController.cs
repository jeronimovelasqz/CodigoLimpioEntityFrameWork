using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodigoLimpioEntityFrameWork.Controllers
{
    public class FluxController : Controller
    {
        // GET: Flux
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Flux/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flux/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flux/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flux/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flux/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flux/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Administrador()
        {
            return View("~/Views/Flujo/Administrador.cshtml");
        }

        public ActionResult Usuario()
        {
            return View("~/Views/Flujo/Usuario.cshtml");
        }
    }
}
