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
    public class T_CategoriaController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View(db.T_Categoria.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categoria t_Categoria = db.T_Categoria.Find(id);
            if (t_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(t_Categoria);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripion")] T_Categoria t_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.T_Categoria.Add(t_Categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categoria t_Categoria = db.T_Categoria.Find(id);
            if (t_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(t_Categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripion")] T_Categoria t_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Categoria);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categoria t_Categoria = db.T_Categoria.Find(id);
            if (t_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(t_Categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Categoria t_Categoria = db.T_Categoria.Find(id);
            db.T_Categoria.Remove(t_Categoria);
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
