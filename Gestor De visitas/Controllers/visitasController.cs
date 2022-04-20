using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestor_De_visitas.Models;

namespace Gestor_De_visitas.Controllers
{
    public class visitasController : Controller
    {
        private VisitasEntities db = new VisitasEntities();

        // GET: visitas
        public ActionResult Index()
        {

            var Lista = db.visitas.ToList();

            var Visitas = new List<Modelovisitas>();



            foreach (var item in Lista)
            {

                var _visitas = new Modelovisitas();
                _visitas.id = item.id;
                _visitas.Nombre = item.Nombre;
                _visitas.Cedula = item.Cedula;
                _visitas.Departamento = item.Departamento;
                _visitas.FechaEntrada = item.FechaEntrada;
                _visitas.FechaSalida = item.FechaSalida;
                _visitas.Estatus = item.Estatus;

                var FechaEntrada = item.FechaEntrada;
                var FechaSalida = item.FechaSalida;

                if (FechaEntrada != null && FechaSalida != null)
                {

                    var Duracion = ((DateTime)FechaSalida - (DateTime)FechaEntrada).Duration();
                    _visitas.Duracion = Duracion;
                }

                Visitas.Add(_visitas);
            }

            return View(Visitas);
        }

        // GET: visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // GET: visitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Cedula,FechaEntrada,Departamento,Estatus,FechaSalida")] visitas visitas)
        {
            if (ModelState.IsValid)
            {
                db.visitas.Add(visitas);
                visitas.Estatus = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitas);
        }

        // GET: visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            visitas.Estatus = true;
            return View(visitas);
        }

        // POST: visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Cedula,FechaEntrada,Departamento,Estatus,FechaSalida")] visitas visitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitas);
        }

        // GET: visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // POST: visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visitas visitas = db.visitas.Find(id);
            visitas.Estatus = false;
            visitas.FechaSalida = DateTime.Now;
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
