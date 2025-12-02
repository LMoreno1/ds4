using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Parcial3.Models;

namespace Parcial3.Controllers
{
    public class ClientesController : Controller
    {
        private BasedeDatos db = new BasedeDatos();

        public ActionResult Index()
        {
            var clientes = db.LM_Clientes
                .OrderBy(c => c.Apellido)
                .ThenBy(c => c.Nombre)
                .ToList();

            ViewBag.TotalClientes = clientes.Count;
            return View(clientes);
        }

        public ActionResult Create()
        {
            ViewBag.TiposCliente = new[] { "Persona Natural", "Empresa", "Gobierno", "ONG", "Otro" };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.FechaRegistro = DateTime.Now;
                db.LM_Clientes.Add(cliente);
                db.SaveChanges();
                TempData["Mensaje"] = "Cliente registrado exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.TiposCliente = new[] { "Persona Natural", "Empresa", "Gobierno", "ONG", "Otro" };
            return View(cliente);
        }

        public ActionResult Details(int id)
        {
            var cliente = db.LM_Clientes.Find(id);
            if (cliente == null)
            {
                TempData["Error"] = "Cliente no encontrado";
                return RedirectToAction("Index");
            }

            var casos = db.LM_Casos
                .Where(c => c.ClienteID == id)
                .Include("Abogado")
                .OrderByDescending(c => c.FechaCreacion)
                .ToList();

            ViewBag.Casos = casos;
            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = db.LM_Clientes.Find(id);
            if (cliente == null)
            {
                TempData["Error"] = "Cliente no encontrado";
                return RedirectToAction("Index");
            }

            ViewBag.TiposCliente = new[] { "Persona Natural", "Empresa", "Gobierno", "ONG", "Otro" };
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Cliente actualizado exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.TiposCliente = new[] { "Persona Natural", "Empresa", "Gobierno", "ONG", "Otro" };
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = db.LM_Clientes.Find(id);
            if (cliente == null)
            {
                TempData["Error"] = "Cliente no encontrado";
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = db.LM_Clientes.Find(id);

            var tieneCasos = db.LM_Casos.Any(c => c.ClienteID == id);
            if (tieneCasos)
            {
                TempData["Error"] = "No se puede eliminar el cliente porque tiene casos asociados";
                return RedirectToAction("Index");
            }

            db.LM_Clientes.Remove(cliente);
            db.SaveChanges();
            TempData["Mensaje"] = "Cliente eliminado exitosamente";
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