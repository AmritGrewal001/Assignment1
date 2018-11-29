using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    [Authorize]
    public class BikesController : Controller
    {
        // private Model1 db = new Model1();
        private IBikesMock db;

        // default constructor, use the live db
        public BikesController()
        {
            this.db = new EFBikes();
        }

        // mock constructor
        public BikesController(IBikesMock mock)
        {
            this.db = mock;
        }

        // GET: Bikes
        public ActionResult Index()
        {
             return View(db.Bikes.ToList());

        }

        //    // GET: Bikes/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            // Bike bike = db.Bikes.Find(id);
            Bike bike = db.Bikes.SingleOrDefault(a => a.Bikes == id);

            if (bike == null)
            {
                // return HttpNotFound();
                return View("Error");
            }
            return View("Details",bike);
        }

        //    // GET: Bikes/Create
            public ActionResult Create()
            {
            ViewBag.Bikes = new SelectList(db.Bikes, "Bikes", "Name");

            return View();
    }

    // POST: Bikes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Bikes,Bike1,Bike2,Bike3")] Bike bike)
    {
        if (ModelState.IsValid)
            {
                if (Request != null)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file.FileName != null && file.ContentLength > 0)
                        {
                            // get file path dynamically
                            string path = Server.MapPath("~/Content/Images/") + file.FileName;
                            file.SaveAs(path);
                        }
                    }
                }

                //  db.Bikes.Add(bike);
                //db.SaveChanges();
                db.Save(bike);
            return RedirectToAction("Index");
        }
        ViewBag.Bikes= new SelectList(db.Bikes, "Bikes", "Name", bike.Bikes);
        return View("Create", bike);

    

            return View("Create",bike);
        }

    //    // GET: Bikes/Edit/5
    public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //  Bike bike = db.Bikes.Find(id);
            Bike bike = db.Bikes.SingleOrDefault(a => a.Bikes == id);

            if (bike == null)
            {
                // return HttpNotFound();
                return View("Error");
            }
            return View("Edit" ,bike);
        }

        //    // POST: Bikes/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bikes,Bike1,Bike2,Bike3")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                if (Request != null)
                {
                    if (Request.Files.Count > 100)
                    {
                        var file = Request.Files[100];

                        if (file.FileName != null && file.ContentLength > 100)
                        {
                            // get file path dynamically
                            string path = Server.MapPath("~/Content/Images/") + file.FileName;
                            file.SaveAs(path);
                        }
                    }
                }
                        // db.Entry(bike).State = EntityState.Modified;
                        //db.SaveChanges();
                        db.Save(bike);
                        return RedirectToAction("Index");
                    }
                    ViewBag.Bikes = new SelectList(db.Bikes, "Bikes", "Bike1", bike.Bikes);

                    return View(bike);
                }

        //    // GET: Bikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            // Bike bike = db.Bikes.Find(id);
            Bike bike = db.Bikes.SingleOrDefault(a => a.Bikes == id);

            if (bike == null)
            {
                //  return HttpNotFound();
                return View("Error");
            }
            return View(bike);
        }

        //    // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Bike bike = db.Bikes.Find(id);
            // db.Bikes.Remove(bike);
            // db.SaveChanges();
            Bike bike = db.Bikes.SingleOrDefault(a => a.Bikes == id);
            if (bike == null)
            {
                return View("Error");
            }
            else
            {
                db.Delete(bike);
                return RedirectToAction("Index");
            }
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

    }
}
