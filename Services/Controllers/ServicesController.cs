using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Services.Models;

namespace Services.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Services
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.servicetype);
            return View(services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = System.Web.HttpContext.Current.User.Identity.Name;

            ViewBag.ServicetypeId = new SelectList(db.Servicetypes, "ServicetypeId", "Servicekind");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Desription,Startdate,Enddate,ServicetypeId")] Service service)
        {
            if (ModelState.IsValid)
            {

                var Currentuser = CurrentUser();
                service.ApplicationUser = Currentuser;

                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("MydashBoard", "Services");
            }

            ViewBag.ServicetypeId = new SelectList(db.Servicetypes, "ServicetypeId", "Servicekind", service.ServicetypeId);
            return RedirectToAction("MydashBoard", "Services");
        }

        public ApplicationUser CurrentUser()
        {

            var CurrnetUserID = User.Identity.GetUserId();
            var CurrentUser = db.Users.SingleOrDefault(c => c.Id == CurrnetUserID);
            return CurrentUser;
        }

        public ActionResult Requested()
        {
            var currentuser = CurrentUser();
         
            var services = serivcebyuserpeference("Request").ToList();
            return View(services);
        }
        public ActionResult Offered()
        {
           
            var services = serivcebyuserpeference("Offer").ToList();
            return View(services);
        }

        public IEnumerable<Service> serivcebyuserpeference(string type)
        {
            var services = db.Services.Where(c => c.servicetype.Servicekind == type);

            return services;
        }

      

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServicetypeId = new SelectList(db.Servicetypes, "ServicetypeId", "Servicekind", service.ServicetypeId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Desription,Startdate,Enddate,ServicetypeId")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MydashBoard", "Services");
            }
            ViewBag.ServicetypeId = new SelectList(db.Servicetypes, "ServicetypeId", "Servicekind", service.ServicetypeId);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("MydashBoard", "Services");
        }
        public ActionResult MydashBoard()
        {
            var currentuser = CurrentUser();
            var services = db.Services.Where(c => c.ApplicationUserID == currentuser.Id ).ToList();
            return View(services);
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
