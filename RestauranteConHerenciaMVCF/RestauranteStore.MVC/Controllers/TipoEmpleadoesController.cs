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
    public class TipoEmpleadoesController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: TipoEmpleadoes
        public ActionResult Index()
        {
            //return View(db.TipoEmpleados.ToList());
            return View(unityOfWork.TipoEmpleado.GetAll());
        }

        // GET: TipoEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoEmpleado tipoEmpleado = db.TipoEmpleados.Find(id);
            TipoEmpleado tipoEmpleado = unityOfWork.TipoEmpleado.Get(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoEmpleadoId,NomTipoEmp")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                //db.TipoEmpleados.Add(tipoEmpleado);
                unityOfWork.TipoEmpleado.Add(tipoEmpleado);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEmpleado);
        }

        // GET: TipoEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoEmpleado tipoEmpleado = db.TipoEmpleados.Find(id);
            TipoEmpleado tipoEmpleado = unityOfWork.TipoEmpleado.Get(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TipoEmpleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoEmpleadoId,NomTipoEmp")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoEmpleado).State = EntityState.Modified;
                unityOfWork.StateModified(tipoEmpleado);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoEmpleado tipoEmpleado = db.TipoEmpleados.Find(id);
            TipoEmpleado tipoEmpleado = unityOfWork.TipoEmpleado.Get(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TipoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoEmpleado tipoEmpleado = db.TipoEmpleados.Find(id);
            TipoEmpleado tipoEmpleado = unityOfWork.TipoEmpleado.Get(id);
            unityOfWork.TipoEmpleado.Delete(tipoEmpleado);
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
