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
    public class CancelarReservasController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: CancelarReservas
        public ActionResult Index()
        {
            return View(unityOfWork.CancelarReserva.GetAll());
        }

        // GET: CancelarReservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CancelarReserva cancelarReserva = db.CancelarReservas.Find(id);
            CancelarReserva cancelarReserva = unityOfWork.CancelarReserva.Get(id);
            if (cancelarReserva == null)
            {
                return HttpNotFound();
            }
            return View(cancelarReserva);
        }

        // GET: CancelarReservas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CancelarReservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CancelarReservaId,Fecha,Hora,NumMesa,PersonaID")] CancelarReserva cancelarReserva)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.CancelarReserva.Add(cancelarReserva);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cancelarReserva);
        }

        // GET: CancelarReservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CancelarReserva cancelarReserva = db.CancelarReservas.Find(id);
            CancelarReserva cancelarReserva = unityOfWork.CancelarReserva.Get(id);
            if (cancelarReserva == null)
            {
                return HttpNotFound();
            }
            return View(cancelarReserva);
        }

        // POST: CancelarReservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CancelarReservaId,Fecha,Hora,NumMesa,PersonaID")] CancelarReserva cancelarReserva)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cancelarReserva).State = EntityState.Modified;
                unityOfWork.StateModified(cancelarReserva);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cancelarReserva);
        }

        // GET: CancelarReservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CancelarReserva cancelarReserva = db.CancelarReservas.Find(id);
            CancelarReserva cancelarReserva = unityOfWork.CancelarReserva.Get(id);
            if (cancelarReserva == null)
            {
                return HttpNotFound();
            }
            return View(cancelarReserva);
        }

        // POST: CancelarReservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CancelarReserva cancelarReserva = db.CancelarReservas.Find(id);
            CancelarReserva cancelarReserva = unityOfWork.CancelarReserva.Get(id);
            unityOfWork.CancelarReserva.Delete(cancelarReserva);
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
