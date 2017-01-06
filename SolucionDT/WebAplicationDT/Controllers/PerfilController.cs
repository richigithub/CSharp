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
    public class PerfilController : Controller
    {
        private Base_DTEntities db = new Base_DTEntities();

        // GET: Perfil
        public ActionResult Index()
        {
            var perfils = db.Perfils.Include(p => p.Permiso);
            return View(perfils.ToList());
        }

        // GET: Perfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfils.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            ViewBag.PermisosId = new SelectList(db.Permisos, "PermisosId", "Modulo");
            return View();
        }

        // POST: Perfil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerfilId,Nombre,PermisosId")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Perfils.Add(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermisosId = new SelectList(db.Permisos, "PermisosId", "Modulo", perfil.PermisosId);
            return View(perfil);
        }

        // GET: Perfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfils.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermisosId = new SelectList(db.Permisos, "PermisosId", "Modulo", perfil.PermisosId);
            return View(perfil);
        }

        // POST: Perfil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerfilId,Nombre,PermisosId")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermisosId = new SelectList(db.Permisos, "PermisosId", "Modulo", perfil.PermisosId);
            return View(perfil);
        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfils.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil perfil = db.Perfils.Find(id);
            db.Perfils.Remove(perfil);
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
