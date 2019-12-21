using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class tbl_ScheduleController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Schedule
        public ActionResult Index()
        {
            var tbl_Customer = db.tbl_Customer.Where(t => t.status == 1).Include(t => t.tbl_Office).Include(t => t.tbl_ServiceUnit);
            return View(tbl_Customer.ToList());
        }

        // GET: tbl_Schedule/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // GET: tbl_Schedule/Create
        public ActionResult Create()
        {
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name");
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name");
            return View();
        }

        // POST: tbl_Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,dob,gender,phone,userName,userId,avatar,facebook,customerType,serviceUnitId,serviceUnitName,quantity,bookingDate,comingDate,reappointmentDate,doctor,officeId,officeName,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Customer.Add(tbl_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_Customer.officeId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_Customer.serviceUnitId);
            return View(tbl_Customer);
        }

        // GET: tbl_Schedule/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_Customer.officeId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_Customer.serviceUnitId);
            return View(tbl_Customer);
        }

        // POST: tbl_Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,dob,gender,phone,userName,userId,avatar,facebook,customerType,serviceUnitId,serviceUnitName,quantity,bookingDate,comingDate,reappointmentDate,doctor,officeId,officeName,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_Customer.officeId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_Customer.serviceUnitId);
            return View(tbl_Customer);
        }

        // GET: tbl_Schedule/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // POST: tbl_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            db.tbl_Customer.Remove(tbl_Customer);
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
