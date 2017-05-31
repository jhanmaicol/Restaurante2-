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
    public class EstadoPedidoesController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: EstadoPedidoes
        public ActionResult Index()
        {
            // return View(db.EstadoPedidos.ToList());
            return View(unityOfWork.EspecialidadDias.GetAll());
        }

        // GET: EstadoPedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EstadoPedido estadoPedido = db.EstadoPedidos.Find(id);
            EstadoPedido estadoPedido = unityOfWork.EstadoPedido.Get(id);
            if (estadoPedido == null)
            {
                return HttpNotFound();
            }
            return View(estadoPedido);
        }

        // GET: EstadoPedidoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoPedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoPedidoId,TipoPago")] EstadoPedido estadoPedido)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.EstadoPedido.Add(estadoPedido);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoPedido);
        }

        // GET: EstadoPedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EstadoPedido estadoPedido = db.EstadoPedidos.Find(id);
            EstadoPedido estadoPedido = unityOfWork.EstadoPedido.Get(id);
            if (estadoPedido == null)
            {
                return HttpNotFound();
            }
            return View(estadoPedido);
        }

        // POST: EstadoPedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoPedidoId,TipoPago")] EstadoPedido estadoPedido)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(estadoPedido).State = EntityState.Modified;
                unityOfWork.StateModified(estadoPedido);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoPedido);
        }

        // GET: EstadoPedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EstadoPedido estadoPedido = db.EstadoPedidos.Find(id);
            EstadoPedido estadoPedido = unityOfWork.EstadoPedido.Get(id);
            if (estadoPedido == null)
            {
                return HttpNotFound();
            }
            return View(estadoPedido);
        }

        // POST: EstadoPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EstadoPedido estadoPedido = db.EstadoPedidos.Find(id);
            EstadoPedido estadoPedido = unityOfWork.EstadoPedido.Get(id);
            unityOfWork.EstadoPedido.Delete(estadoPedido);
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
