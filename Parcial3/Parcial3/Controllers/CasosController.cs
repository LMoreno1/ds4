using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Parcial3.Models;

namespace Parcial3.Controllers
{
    //[Authorize]
    public class CasosController : Controller
    {
        private BasedeDatos db = new BasedeDatos();

        // GET: Casos
        public ActionResult Index()
        {
            var casos = db.LM_Casos
                .Include("Abogado")
                .Include("Cliente")
                .OrderByDescending(c => c.FechaCreacion)
                .ToList();

            ViewBag.TotalCasos = casos.Count;
            ViewBag.CasosActivos = casos.Count(c => c.Estado == "Activo");
            return View(casos);
        }

        public ActionResult Create()
        {
            ViewBag.Abogados = db.LM_Usuarios
                .Where(u => u.Rol == "Abogado")
                .ToList();
            ViewBag.Clientes = db.LM_Clientes.ToList();
            ViewBag.Estados = new[] { "Activo", "En Proceso", "Cerrado", "Archivado" };
            ViewBag.Prioridades = new[] { "Alta", "Media", "Baja" };
            ViewBag.Areas = new[] { "Civil", "Penal", "Laboral", "Familiar", "Otro" };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Casos caso)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(caso.NumeroCaso))
                {
                    caso.NumeroCaso = "C-" + DateTime.Now.Year + "-" +
                        (db.LM_Casos.Count() + 1).ToString("0000");
                }

                caso.FechaCreacion = DateTime.Now;
                db.LM_Casos.Add(caso);
                db.SaveChanges();
                TempData["Mensaje"] = "Caso creado exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.Abogados = db.LM_Usuarios
                .Where(u => u.Rol == "Abogado")
                .ToList();
            ViewBag.Clientes = db.LM_Clientes.ToList();
            ViewBag.Estados = new[] { "Activo", "En Proceso", "Cerrado", "Archivado" };
            ViewBag.Prioridades = new[] { "Alta", "Media", "Baja" };
            ViewBag.Areas = new[] { "Civil", "Penal", "Laboral", "Familiar", "Otro" };
            return View(caso);
        }

        public ActionResult Details(int id)
        {
            var caso = db.LM_Casos
                .Include("Abogado")
                .Include("Cliente")
                .FirstOrDefault(c => c.CasoID == id);

            if (caso == null)
            {
                TempData["Error"] = "Caso no encontrado";
                return RedirectToAction("Index");
            }

            return View(caso);
        }

        public ActionResult Edit(int id)
        {
            var caso = db.LM_Casos.Find(id);
            if (caso == null)
            {
                TempData["Error"] = "Caso no encontrado";
                return RedirectToAction("Index");
            }

            ViewBag.Abogados = db.LM_Usuarios
                .Where(u => u.Rol == "Abogado")
                .ToList();
            ViewBag.Clientes = db.LM_Clientes.ToList();
            ViewBag.Estados = new[] { "Activo", "En Proceso", "Cerrado", "Archivado" };
            ViewBag.Prioridades = new[] { "Alta", "Media", "Baja" };
            ViewBag.Areas = new[] { "Civil", "Penal", "Laboral", "Familiar", "Otro" };
            return View(caso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Casos caso)
        {
            if (ModelState.IsValid)
            {
                caso.FechaModificacion = DateTime.Now;
                db.Entry(caso).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Caso actualizado exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.Abogados = db.LM_Usuarios
                .Where(u => u.Rol == "Abogado")
                .ToList();
            ViewBag.Clientes = db.LM_Clientes.ToList();
            ViewBag.Estados = new[] { "Activo", "En Proceso", "Cerrado", "Archivado" };
            ViewBag.Prioridades = new[] { "Alta", "Media", "Baja" };
            ViewBag.Areas = new[] { "Civil", "Penal", "Laboral", "Familiar", "Otro" };
            return View(caso);
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