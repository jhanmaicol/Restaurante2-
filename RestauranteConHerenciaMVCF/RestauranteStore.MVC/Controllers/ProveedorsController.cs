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
    public class ProveedorsController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Proveedors
        public ActionResult Index()
        {
            var proveedores = unityOfWork.Proveedor.Include(p => p.Almacen);
            return View(unityOfWork.Almacen.GetAll());
           // return View(proveedores.ToList());
        }

        // GET: Proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Proveedor proveedor = db.Proveedores.Find(id);
            Proveedor proveedor = unityOfWork.Proveedor.Get(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedors/Create
        public ActionResult Create()
        {
            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacen, "AlmacenId", "AlmacenId");
            return View();
        }

        // POST: Proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProveedorId,NombreEmpresa,Ruc,AlmacenId")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Proveedor.Add(proveedor);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacen, "AlmacenId", "AlmacenId", proveedor.AlmacenId);
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Proveedor proveedor = db.Proveedores.Find(id);
            Proveedor proveedor = unityOfWork.Proveedor.Get(id);

            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacen, "AlmacenId", "AlmacenId", proveedor.AlmacenId);
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProveedorId,NombreEmpresa,Ruc,AlmacenId")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(proveedor).State = EntityState.Modified;
                unityOfWork.StateModified(proveedor);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacen, "AlmacenId", "AlmacenId", proveedor.AlmacenId);
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Proveedor proveedor = db.Proveedores.Find(id);
            Proveedor proveedor = unityOfWork.Proveedor.Get(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Proveedor proveedor = db.Proveedores.Find(id);
            Proveedor proveedor = unityOfWork.Proveedor.Get(id);
            unityOfWork.Proveedor.Delete(proveedor);
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
