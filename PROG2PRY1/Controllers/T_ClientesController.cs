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
    public class T_ClientesController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View(db.T_Clientes.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Clientes t_Clientes = db.T_Clientes.Find(id);
            if (t_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(t_Clientes);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellido,Telefono")] T_Clientes t_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.T_Clientes.Add(t_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Clientes);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Clientes t_Clientes = db.T_Clientes.Find(id);
            if (t_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(t_Clientes);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellido,Telefono")] T_Clientes t_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Clientes);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Clientes t_Clientes = db.T_Clientes.Find(id);
            if (t_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(t_Clientes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Clientes t_Clientes = db.T_Clientes.Find(id);
            db.T_Clientes.Remove(t_Clientes);
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
