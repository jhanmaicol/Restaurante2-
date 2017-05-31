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
    public class CartasController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Cartas
        public ActionResult Index()
        {
            var cartas = unityOfWork.Carta.Include(c => c.EspecialidadDia);
            return View(cartas.ToList());
        }

        // GET: Cartas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Carta carta = db.Cartas.Find(id);
            Carta carta = unityOfWork.Carta.Get(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            return View(carta);
        }

        // GET: Cartas/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadDiaId = new SelectList(unityOfWork.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId");
            return View();
        }

        // POST: Cartas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartaId,Bebidas,Menu,Postres,EspecialidadDiaId")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Carta.Add(carta);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadDiaId = new SelectList(unityOfWork.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId", carta.EspecialidadDiaId);
            return View(carta);
        }

        // GET: Cartas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Carta carta = db.Cartas.Find(id);
            Carta carta = unityOfWork.Carta.Get(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadDiaId = new SelectList(unityOfWork.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId", carta.EspecialidadDiaId);
            return View(carta);
        }

        // POST: Cartas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartaId,Bebidas,Menu,Postres,EspecialidadDiaId")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.StateModified(carta);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadDiaId = new SelectList(unityOfWork.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId", carta.EspecialidadDiaId);
            return View(carta);
        }

        // GET: Cartas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Carta carta = db.Cartas.Find(id);
            Carta carta = unityOfWork.Carta.Get(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            return View(carta);
        }

        // POST: Cartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Carta carta = db.Cartas.Find(id);
            Carta carta = unityOfWork.Carta.Get(id);
            unityOfWork.Carta.Delete(carta);
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
