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
using RestauranteStore.Entities.IRepositories;

namespace RestauranteStore.MVC.Controllers
{
    public class AlmacensController : Controller
    {
        // private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;
        private readonly IUnityOfWork _UnityOfWork;

        public AlmacensController(IUnityOfWork unityOfWorck)
        {
            _UnityOfWork = unityOfWorck;
        }

        // GET: Almacens
        public ActionResult Index()
        {
            //return View(db.Almacenes.ToList());
            return View(_UnityOfWork.Almacen.GetAll());
        }

        // GET: Almacens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacen.Get(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // GET: Almacens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Almacens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlmacenId,Inventario,EstadoAlm")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                // db.Almacenes.Add(almacen);
                _UnityOfWork.Almacen.Add(almacen);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(almacen);
        }

        // GET: Almacens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacen.Get(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlmacenId,Inventario,EstadoAlm")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(almacen).State = EntityState.Modified;
                _UnityOfWork.StateModified(almacen);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(almacen);
        }

        // GET: Almacens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacen.Get(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacen.Get(id);
            _UnityOfWork.Almacen.Delete(almacen);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
