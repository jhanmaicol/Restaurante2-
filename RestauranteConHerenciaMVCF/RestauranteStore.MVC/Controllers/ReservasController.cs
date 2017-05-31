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
    public class ReservasController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = unityOfWork.Reserva.Include(r => r.Mesa);
            //return View(reservas.ToList());
            return View(unityOfWork.Almacen.GetAll());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = unityOfWork.Reserva.Get(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.MesaId = new SelectList(unityOfWork.Mesas, "MesaId", "MesaId");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaId,Fecha,Hora,PersonaId,MesaId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Reserva.Add(reserva);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MesaId = new SelectList(unityOfWork.Mesas, "MesaId", "MesaId", reserva.MesaId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = unityOfWork.Reserva.Get(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.MesaId = new SelectList(unityOfWork.Mesas.Find, "MesaId", "MesaId", reserva.MesaId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaId,Fecha,Hora,PersonaId,MesaId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.StateModified(reserva);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MesaId = new SelectList(unityOfWork.Mesa, "MesaId", "MesaId", reserva.MesaId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = unityOfWork.Reserva.Get(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = unityOfWork.Reserva.Get(id);
            unityOfWork.Reserva.Delete(reserva);
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
