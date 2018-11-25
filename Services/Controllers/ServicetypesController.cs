using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Services.Models;

namespace Services.Controllers
{
    public class ServicetypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Servicetypes
        public ActionResult Index()
        {
            return View(db.Servicetypes.ToList());
        }

        // GET: Servicetypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicetype servicetype = db.Servicetypes.Find(id);
            if (servicetype == null)
            {
                return HttpNotFound();
            }
            return View(servicetype);
        }

        // GET: Servicetypes/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Servicetypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicetypeId,Servicekind")] Servicetype servicetype)
        {
            if (ModelState.IsValid)
            {
                db.Servicetypes.Add(servicetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicetype);
        }

        // GET: Servicetypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicetype servicetype = db.Servicetypes.Find(id);
            if (servicetype == null)
            {
                return HttpNotFound();
            }
            return View(servicetype);
        }

        // POST: Servicetypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicetypeId,Servicekind")] Servicetype servicetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicetype);
        }

        // GET: Servicetypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicetype servicetype = db.Servicetypes.Find(id);
            if (servicetype == null)
            {
                return HttpNotFound();
            }
            return View(servicetype);
        }

        // POST: Servicetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicetype servicetype = db.Servicetypes.Find(id);
            db.Servicetypes.Remove(servicetype);
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
