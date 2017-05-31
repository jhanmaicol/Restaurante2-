using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestauranteStore.Entities.Entities;
using RestauranteStore.Persistence;
using RestauranteStore.Persistence.Repositories;

namespace RestauranteStore.MVC.Controllers
{
    public class PersonasController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Personas
        public ActionResult Index()
        {
            var personas = unityOfWork.Persona.Include(p => p.CancelarReserva).Include(p => p.Carta).Include(p => p.Reserva).Include(p => p.TipoEmpleado).Include(p => p.Turno);
            //return View(personas.ToList());
            return View(unityOfWork.Almacen.GetAll());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Persona persona = db.Personas.Find(id);
            Persona persona = unityOfWork.Persona.Get(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId");
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId");
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId");
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp");
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaId,DNI,NombrePersona,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Telefono,Direccion,CartaId,CancelarReservaId,ReservaId,TipoEmpleadoId,TurnoId")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Persona.Add(persona);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId", persona.PersonaId);
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId", persona.CartaId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId", persona.PersonaId);
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp", persona.TipoEmpleadoId);
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId", persona.TurnoId);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Persona persona = db.Personas.Find(id);
            Persona persona = unityOfWork.Persona.Get(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId", persona.PersonaId);
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId", persona.CartaId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId", persona.PersonaId);
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp", persona.TipoEmpleadoId);
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId", persona.TurnoId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaId,DNI,NombrePersona,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Telefono,Direccion,CartaId,CancelarReservaId,ReservaId,TipoEmpleadoId,TurnoId")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(persona).State = EntityState.Modified;
                unityOfWork.StateModified(persona);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId", persona.PersonaId);
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId", persona.CartaId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId", persona.PersonaId);
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp", persona.TipoEmpleadoId);
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId", persona.TurnoId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Persona persona = db.Personas.Find(id);
            Persona persona = unityOfWork.Persona.Get(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Persona persona = db.Personas.Find(id);
            Persona persona = unityOfWork.Persona.Get(id);
            unityOfWork.Persona.Delete(persona);
            unityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
