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
    public class EspecialidadDiasController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: EspecialidadDias
        public ActionResult Index()
        {
            //return View(db.EspecialidadDias.ToList());
            return View(unityOfWork.Almacen.GetAll());
        }

        // GET: EspecialidadDias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EspecialidadDia especialidadDia = db.EspecialidadDias.Find(id);
            EspecialidadDia especialidadDia = unityOfWork.EspecialidadDias.Get(id);
            if (especialidadDia == null)
            {
                return HttpNotFound();
            }
            return View(especialidadDia);
        }

        // GET: EspecialidadDias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadDias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EspecialidadDiaId,Dia")] EspecialidadDia especialidadDia)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.EspecialidadDias.Add(especialidadDia);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidadDia);
        }

        // GET: EspecialidadDias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EspecialidadDia especialidadDia = db.EspecialidadDias.Find(id);
            EspecialidadDia especialidadDia = unityOfWork.EspecialidadDias.Get(id);
            if (especialidadDia == null)
            {
                return HttpNotFound();
            }
            return View(especialidadDia);
        }

        // POST: EspecialidadDias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EspecialidadDiaId,Dia")] EspecialidadDia especialidadDia)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(especialidadDia).State = EntityState.Modified;
                unityOfWork.StateModified(especialidadDia);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidadDia);
        }

        // GET: EspecialidadDias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EspecialidadDia especialidadDia = db.EspecialidadDias.Find(id);
            EspecialidadDia especialidadDia = unityOfWork.EspecialidadDias.Get(id);
            if (especialidadDia == null)
            {
                return HttpNotFound();
            }
            return View(especialidadDia);
        }

        // POST: EspecialidadDias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EspecialidadDia especialidadDia = db.EspecialidadDias.Find(id);
            EspecialidadDia especialidadDia = unityOfWork.EspecialidadDias.Get(id);
            unityOfWork.EspecialidadDias.Delete(especialidadDia);
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
