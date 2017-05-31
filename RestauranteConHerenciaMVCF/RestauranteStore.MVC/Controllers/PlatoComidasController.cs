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
    public class PlatoComidasController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: PlatoComidas
        public ActionResult Index()
        {
            var platoComidas = unityOfWork.PlatoComida.Include(p => p.Pedido);
            //return View(platoComidas.ToList());
            return View(unityOfWork.Almacen.GetAll());
        }

        // GET: PlatoComidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlatoComida platoComida = db.PlatoComidas.Find(id);
            PlatoComida platoComida = unityOfWork.PlatoComida.Get(id);
            if (platoComida == null)
            {
                return HttpNotFound();
            }
            return View(platoComida);
        }

        // GET: PlatoComidas/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(unityOfWork.Pedido, "PedidoId", "Extra");
            return View();
        }

        // POST: PlatoComidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlatoComidaId,NomPlato,Precio,PedidoId")] PlatoComida platoComida)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.PlatoComida.Add(platoComida);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(unityOfWork.Pedido, "PedidoId", "Extra", platoComida.PedidoId);
            return View(platoComida);
        }

        // GET: PlatoComidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlatoComida platoComida = db.PlatoComidas.Find(id);
            PlatoComida platoComida = unityOfWork.PlatoComida.Get(id);
            if (platoComida == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(unityOfWork.Pedido, "PedidoId", "Extra", platoComida.PedidoId);
            return View(platoComida);
        }

        // POST: PlatoComidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlatoComidaId,NomPlato,Precio,PedidoId")] PlatoComida platoComida)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(platoComida).State = EntityState.Modified;
                unityOfWork.StateModified(platoComida);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(unityOfWork.Pedido, "PedidoId", "Extra", platoComida.PedidoId);
            return View(platoComida);
        }

        // GET: PlatoComidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlatoComida platoComida = db.PlatoComidas.Find(id);
            PlatoComida platoComida = unityOfWork.PlatoComida.Get(id);
            if (platoComida == null)
            {
                return HttpNotFound();
            }
            return View(platoComida);
        }

        // POST: PlatoComidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PlatoComida platoComida = db.PlatoComidas.Find(id);
            PlatoComida platoComida = unityOfWork.PlatoComida.Get(id);
            unityOfWork.PlatoComida.Delete(platoComida);
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
