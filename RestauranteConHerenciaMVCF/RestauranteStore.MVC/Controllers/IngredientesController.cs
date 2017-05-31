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
    public class IngredientesController : Controller
    {
        //private RestauranteStoreDbContext db = new RestauranteStoreDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Ingredientes
        public ActionResult Index()
        {
            var ingredientes = unityOfWork.Ingrediente.Include(i => i.Almacen).Include(i => i.PlatoComida);
            return View(ingredientes.ToList());
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ingrediente ingrediente = db.Ingredientes.Find(id);
            Ingrediente ingrediente = unityOfWork.Ingrediente.Get(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacene, "AlmacenId", "AlmacenId");
            ViewBag.PlatoComidaId = new SelectList(unityOfWork.PlatoComida, "PlatoComidaId", "NomPlato");
            return View();
        }

        // POST: Ingredientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredienteId,Cantidad,NombreIng,TipoIng,PlatoComidaId,AlmacenId")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Ingrediente.Add(ingrediente);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacen, "AlmacenId", "AlmacenId", ingrediente.AlmacenId);
            ViewBag.PlatoComidaId = new SelectList(unityOfWork.PlatoComida, "PlatoComidaId", "NomPlato", ingrediente.PlatoComidaId);
            return View(ingrediente);
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ingrediente ingrediente = db.Ingredientes.Find(id);
            Ingrediente ingrediente = unityOfWork.Ingrediente.Get(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacen, "AlmacenId", "AlmacenId", ingrediente.AlmacenId);
            ViewBag.PlatoComidaId = new SelectList(unityOfWork.PlatoComida, "PlatoComidaId", "NomPlato", ingrediente.PlatoComidaId);
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredienteId,Cantidad,NombreIng,TipoIng,PlatoComidaId,AlmacenId")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ingrediente).State = EntityState.Modified;
                unityOfWork.StateModified(ingrediente);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlmacenId = new SelectList(unityOfWork.Almacene, "AlmacenId", "AlmacenId", ingrediente.AlmacenId);
            ViewBag.PlatoComidaId = new SelectList(unityOfWork.PlatoComida, "PlatoComidaId", "NomPlato", ingrediente.PlatoComidaId);
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ingrediente ingrediente = db.Ingredientes.Find(id);
            Ingrediente ingrediente = unityOfWork.Ingrediente.Get(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Ingrediente ingrediente = db.Ingredientes.Find(id);
            Ingrediente ingrediente = unityOfWork.Ingrediente.Get(id);
            unityOfWork.Ingrediente.Delete(ingrediente);
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
