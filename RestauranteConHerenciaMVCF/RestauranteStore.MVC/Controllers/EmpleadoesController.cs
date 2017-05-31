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
    public class EmpleadoesController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Empleadoes
        public ActionResult Index()
        {
            var personas = unityOfWork.Persona.Include(e => e.CancelarReserva).Include(e => e.Carta).Include(e => e.Reserva).Include(e => e.TipoEmpleado).Include(e => e.Turno);
            return View(personas.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleado empleado = db.Personas.Find(id);
            Empleado empleado = unityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId");
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId");
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId");
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp");
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId");
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaId,DNI,NombrePersona,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Telefono,Direccion,CartaId,CancelarReservaId,ReservaId,TipoEmpleadoId,TurnoId,NombreEmpleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Persona.Add(empleado);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId", empleado.PersonaId);
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId", empleado.CartaId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId", empleado.PersonaId);
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp", empleado.TipoEmpleadoId);
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId", empleado.TurnoId);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleado empleado = db.Personas.Find(id);
            Empleado empleado = unityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(unityOfWork.CancelarReserva, "CancelarReservaId", "CancelarReservaId", empleado.PersonaId);
            ViewBag.CartaId = new SelectList(unityOfWork.Carta, "CartaId", "CartaId", empleado.CartaId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Reserva, "ReservaId", "ReservaId", empleado.PersonaId);
            ViewBag.TipoEmpleadoId = new SelectList(unityOfWork.TipoEmpleado, "TipoEmpleadoId", "NomTipoEmp", empleado.TipoEmpleadoId);
            ViewBag.TurnoId = new SelectList(unityOfWork.Turno, "TurnoId", "TurnoId", empleado.TurnoId);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaId,DNI,NombrePersona,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Telefono,Direccion,CartaId,CancelarReservaId,ReservaId,TipoEmpleadoId,TurnoId,NombreEmpleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(empleado).State = EntityState.Modified;
                unityOfWork.StateModified(empleado);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(db.CancelarReservas, "CancelarReservaId", "CancelarReservaId", empleado.PersonaId);
            ViewBag.CartaId = new SelectList(db.Cartas, "CartaId", "CartaId", empleado.CartaId);
            ViewBag.PersonaId = new SelectList(db.Reservas, "ReservaId", "ReservaId", empleado.PersonaId);
            ViewBag.TipoEmpleadoId = new SelectList(db.TipoEmpleadoes, "TipoEmpleadoId", "NomTipoEmp", empleado.TipoEmpleadoId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "TurnoId", empleado.TurnoId);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleado empleado = db.Personas.Find(id);
            Empleado empleado = unityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Empleado empleado = db.Personas.Find(id);
            Empleado empleado = unityOfWork.Empleado.Get(id);
            unityOfWork.Persona.Delete(empleado);
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
