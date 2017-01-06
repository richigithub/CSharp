using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAplicationDT.Models;

namespace WebAplicationDT.Controllers
{
    public class EmpaqueController : Controller
    {
        private Base_DTEntities db = new Base_DTEntities();

        // GET: Empaque
        public ActionResult Index()
        {
            return View(db.Empaques.ToList());
        }

        // GET: Empaque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empaque empaque = db.Empaques.Find(id);
            if (empaque == null)
            {
                return HttpNotFound();
            }
            return View(empaque);
        }

        // GET: Empaque/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empaque/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpaqueId,Nombre")] Empaque empaque)
        {
            if (ModelState.IsValid)
            {
                db.Empaques.Add(empaque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empaque);
        }

        // GET: Empaque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empaque empaque = db.Empaques.Find(id);
            if (empaque == null)
            {
                return HttpNotFound();
            }
            return View(empaque);
        }

        // POST: Empaque/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpaqueId,Nombre")] Empaque empaque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empaque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empaque);
        }

        // GET: Empaque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empaque empaque = db.Empaques.Find(id);
            if (empaque == null)
            {
                return HttpNotFound();
            }
            return View(empaque);
        }

        // POST: Empaque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empaque empaque = db.Empaques.Find(id);
            db.Empaques.Remove(empaque);
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
