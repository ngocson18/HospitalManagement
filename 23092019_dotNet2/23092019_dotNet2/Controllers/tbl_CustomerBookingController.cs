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
    public class tbl_CustomerBookingController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_CustomerBooking
        public ActionResult Index()
        {
            var tbl_CustomerBooking = db.tbl_CustomerBooking.Include(t => t.tbl_MedicalBill).Include(t => t.tbl_MedicalBill1).Include(t => t.tbl_Office).Include(t => t.tbl_Office1).Include(t => t.tbl_Product).Include(t => t.tbl_Product1).Include(t => t.tbl_ServiceUnit).Include(t => t.tbl_ServiceUnit1);
            return View(tbl_CustomerBooking.ToList());
        }

        // GET: tbl_CustomerBooking/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CustomerBooking tbl_CustomerBooking = db.tbl_CustomerBooking.Find(id);
            if (tbl_CustomerBooking == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CustomerBooking);
        }

        // GET: tbl_CustomerBooking/Create
        public ActionResult Create()
        {
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode");
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode");
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name");
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name");
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode");
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode");
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name");
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name");
            return View();
        }

        // POST: tbl_CustomerBooking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,medicalBillId,serviceUnitId,bookingDate,comingDate,officeId,productId,quantity,servicePrice,payment,debt,payMethod,createdTime,updatedTime,createdBy,updatedBy")] tbl_CustomerBooking tbl_CustomerBooking)
        {
            if (ModelState.IsValid)
            {
                db.tbl_CustomerBooking.Add(tbl_CustomerBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_CustomerBooking.medicalBillId);
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_CustomerBooking.medicalBillId);
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_CustomerBooking.officeId);
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_CustomerBooking.officeId);
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode", tbl_CustomerBooking.productId);
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode", tbl_CustomerBooking.productId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_CustomerBooking.serviceUnitId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_CustomerBooking.serviceUnitId);
            return View(tbl_CustomerBooking);
        }

        // GET: tbl_CustomerBooking/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CustomerBooking tbl_CustomerBooking = db.tbl_CustomerBooking.Find(id);
            if (tbl_CustomerBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_CustomerBooking.medicalBillId);
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_CustomerBooking.medicalBillId);
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_CustomerBooking.officeId);
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_CustomerBooking.officeId);
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode", tbl_CustomerBooking.productId);
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode", tbl_CustomerBooking.productId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_CustomerBooking.serviceUnitId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_CustomerBooking.serviceUnitId);
            return View(tbl_CustomerBooking);
        }

        // POST: tbl_CustomerBooking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,medicalBillId,serviceUnitId,bookingDate,comingDate,officeId,productId,quantity,servicePrice,payment,debt,payMethod,createdTime,updatedTime,createdBy,updatedBy")] tbl_CustomerBooking tbl_CustomerBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CustomerBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_CustomerBooking.medicalBillId);
            ViewBag.medicalBillId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_CustomerBooking.medicalBillId);
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_CustomerBooking.officeId);
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_CustomerBooking.officeId);
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode", tbl_CustomerBooking.productId);
            ViewBag.productId = new SelectList(db.tbl_Product, "id", "productCode", tbl_CustomerBooking.productId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_CustomerBooking.serviceUnitId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_CustomerBooking.serviceUnitId);
            return View(tbl_CustomerBooking);
        }

        // GET: tbl_CustomerBooking/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CustomerBooking tbl_CustomerBooking = db.tbl_CustomerBooking.Find(id);
            if (tbl_CustomerBooking == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CustomerBooking);
        }

        // POST: tbl_CustomerBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_CustomerBooking tbl_CustomerBooking = db.tbl_CustomerBooking.Find(id);
            db.tbl_CustomerBooking.Remove(tbl_CustomerBooking);
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
