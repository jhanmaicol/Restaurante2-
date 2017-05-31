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
    public class PedidosController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedidos = unityOfWork.Pedido.Include(p => p.EstadoPedido).Include(p => p.Persona);
            return View(pedidos.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = unityOfWork.Pedido.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.EstadoPedidoId = new SelectList(unityOfWork.EstadoPedido, "EstadoPedidoId", "EstadoPedidoId");
            ViewBag.PersonaId = new SelectList(unityOfWork.Persona, "PersonaId", "NombrePersona");
            return View();
        }

        // POST: Pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,CantidadPlato,Extra,MontoPagar,PersonaId,EstadoPedidoId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoPedidoId = new SelectList(unityOfWork.EstadoPedido, "EstadoPedidoId", "EstadoPedidoId", pedido.EstadoPedidoId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Persona, "PersonaId", "NombrePersona", pedido.PersonaId);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = unityOfWork.Pedido.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoPedidoId = new SelectList(unityOfWork.EstadoPedido, "EstadoPedidoId", "EstadoPedidoId", pedido.EstadoPedidoId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Persona, "PersonaId", "NombrePersona", pedido.PersonaId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,CantidadPlato,Extra,MontoPagar,PersonaId,EstadoPedidoId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pedido).State = EntityState.Modified;
                unityOfWork.StateModified(pedido);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoPedidoId = new SelectList(unityOfWork.EstadoPedido, "EstadoPedidoId", "EstadoPedidoId", pedido.EstadoPedidoId);
            ViewBag.PersonaId = new SelectList(unityOfWork.Persona, "PersonaId", "NombrePersona", pedido.PersonaId);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = unityOfWork.Pedido.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = unityOfWork.Pedido.Get(id);
            unityOfWork.Pedido.Delete(pedido);
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
