using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROG2PRY1.Models;

namespace PROG2PRY1.Controllers
{
    public class T_ProductosController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            var t_Productos = db.T_Productos.Include(t => t.T_Categoria).Include(t => t.T_Clientes);
            return View(t_Productos.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Productos t_Productos = db.T_Productos.Find(id);
            if (t_Productos == null)
            {
                return HttpNotFound();
            }
            return View(t_Productos);
        }

        public ActionResult Create()
        {
            ViewBag.ID_Categoria = new SelectList(db.T_Categoria, "ID", "Descripion");
            ViewBag.ID_Cliente = new SelectList(db.T_Clientes, "ID", "Nombre");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Precio,ID_Categoria,ID_Cliente")] T_Productos t_Productos)
        {
            if (ModelState.IsValid)
            {
                db.T_Productos.Add(t_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Categoria = new SelectList(db.T_Categoria, "ID", "Descripion", t_Productos.ID_Categoria);
            ViewBag.ID_Cliente = new SelectList(db.T_Clientes, "ID", "Nombre", t_Productos.ID_Cliente);
            return View(t_Productos);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Productos t_Productos = db.T_Productos.Find(id);
            if (t_Productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Categoria = new SelectList(db.T_Categoria, "ID", "Descripion", t_Productos.ID_Categoria);
            ViewBag.ID_Cliente = new SelectList(db.T_Clientes, "ID", "Nombre", t_Productos.ID_Cliente);
            return View(t_Productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Precio,ID_Categoria,ID_Cliente")] T_Productos t_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Categoria = new SelectList(db.T_Categoria, "ID", "Descripion", t_Productos.ID_Categoria);
            ViewBag.ID_Cliente = new SelectList(db.T_Clientes, "ID", "Nombre", t_Productos.ID_Cliente);
            return View(t_Productos);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Productos t_Productos = db.T_Productos.Find(id);
            if (t_Productos == null)
            {
                return HttpNotFound();
            }
            return View(t_Productos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Productos t_Productos = db.T_Productos.Find(id);
            db.T_Productos.Remove(t_Productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
