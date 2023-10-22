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
    public class EstadisticasController : Controller
    {
        private ColoriaEntitiesEn db = new ColoriaEntitiesEn();


        public ActionResult Operaciones()
        {
            return View();
        }


        // Método para obtener las 3 ideas de negocio que generen más rentabilidad
        public ActionResult IdeasMayorRentabilidad()
        {
            var ideas = db.Idea.OrderByDescending(i => i.ingresosObjetivos - i.inversionRequerida).Take(3).ToList();
            ViewBag.Resultados = ideas;
            return View("operaciones");
        }


        // Método para obtener los emprendimientos o ideas de negocio que impacten más de 3 departamentos
        public ActionResult IdeasImpactoDepartamentos()
        {
            System.Diagnostics.Debug.WriteLine("Entrando al método IdeasImpactoDepartamentos");

            var ideas = db.Idea.Where(i =>
                i.ideaColor.SelectMany(ic => ic.Color.DepartamentoColor).Select(dc => dc.idDepartamento).Distinct().Count() > 3
            ).ToList();

            System.Diagnostics.Debug.WriteLine($"Se encontraron {ideas.Count} ideas que impactan a más de 3 departamentos");

            ViewBag.Resultados = ideas;
            return View("operaciones");
        }



        // Método para obtener la suma total de ingresos de todas las ideas de negocio
        public ActionResult SumaIngresos()
        {
            var sumaIngresos = db.Idea.Sum(i => i.ingresosObjetivos);
            ViewBag.Resultados = sumaIngresos;
            return View("operaciones");
        }

        // Método para obtener la suma total de la inversión que se debe hacer en todas las ideas de negocio
        public ActionResult SumaInversiones()
        {
            var sumaInversiones = db.Idea.Sum(i => i.inversionRequerida);
            ViewBag.Resultados = sumaInversiones;
            return View("operaciones");
        }

        // Método para obtener el nombre de la idea de negocio con los integrantes del equipo que tenga la mayor cantidad de herramientas 4RI en su emprendimiento
        public ActionResult IdeaMayorHerramientas()
        {
            var idea = db.Idea.OrderByDescending(i => i.ideaHerramienta.Count).FirstOrDefault();
            ViewBag.Resultados = idea;
            return View("operaciones");
        }

        // Método para obtener la cantidad de ideas de negocio que tienen Inteligencia Artificial
        public ActionResult IdeasConIA()
        {
            var cantidad = db.ideaHerramienta.Count(ih => ih.Herramienta.nombreHerramienta == "Inteligencia Artificial");
            ViewBag.Resultados = cantidad;  
            return View("operaciones");
        }

        // Método para obtener la idea de negocio con mayor inversión en infraestructura
        public ActionResult IdeaMayorInversionInfraestructura()
        {
            var idea = db.Idea.OrderByDescending(i => i.inversionInfraestructura).FirstOrDefault();
            ViewBag.Resultados = idea;  
            return View("operaciones");
        }

        // Método para obtener las ideas de negocio cuyos ingresos son mayores al promedio de ingresos de todas las ideas
        public ActionResult IdeasIngresosMayorPromedio()
        {
            var promedioIngresos = db.Idea.Average(i => i.ingresosObjetivos);
            var ideas = db.Idea.Where(i => i.ingresosObjetivos > promedioIngresos).ToList();
            ViewBag.Resultados = ideas;
            return View("operaciones");
        }

        // Método para obtener todas las ideas que tengan como herramienta "Desarrollo Sostenible"
        public ActionResult IdeasConDesarrolloSostenible()
        {
            var ideas = db.ideaHerramienta.Where(ih => ih.Herramienta.nombreHerramienta == "Desarrollo Sostenible").Select(ih => ih.Idea).ToList();
            ViewBag.Resultados = ideas;
            return View("operaciones");
        }








    }
}
