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
    public class TurnoesController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Turnoes

        public ActionResult Index()
        {
            //return View(db.Turnos.ToList());
            return View(unityOfWork.Turno.GetAll());
        }

        // GET: Turnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = unityOfWork.Turno.Get(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // GET: Turnoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turnoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TurnoId")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Turno.Add(turno);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turno);
        }

        // GET: Turnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Turno turno = db.Turno.Find(id);
            Turno turno = unityOfWork.Turno.Get(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // POST: Turnoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TurnoId")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(turno).State = EntityState.Modified;
                unityOfWork.StateModified(turno);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turno);
        }

        // GET: Turnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Turno turno = db.Turnos.Find(id);
            Turno turno = unityOfWork.Turno.Get(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // POST: Turnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Turno turno = db.Turnos.Find(id);
            Turno turno = unityOfWork.Turno.Get(id);
            unityOfWork.Turno.Delete(turno);
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
