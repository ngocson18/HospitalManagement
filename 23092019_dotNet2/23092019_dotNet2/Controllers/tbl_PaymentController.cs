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
    public class tbl_PaymentController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Payment
        public ActionResult Index()
        {
            var tbl_Payment = db.tbl_Payment.Include(t => t.tbl_MedicalBill);
            return View(tbl_Payment.ToList());
        }

        // GET: tbl_Payment/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            if (tbl_Payment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment);
        }

        // GET: tbl_Payment/Create
        public ActionResult Create()
        {
            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode");
            return View();
        }

        // POST: tbl_Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,customerName,phone,serviceUnitName,doctor,totalFee,paidFee,debtFee,billId,payTime,status,paymentType,createdTime,updatedTime,createdBy,updatedBy")] tbl_Payment tbl_Payment)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Payment.Add(tbl_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_Payment.billId);
            return View(tbl_Payment);
        }

        // GET: tbl_Payment/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            if (tbl_Payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_Payment.billId);
            return View(tbl_Payment);
        }

        // POST: tbl_Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,customerName,phone,serviceUnitName,doctor,totalFee,paidFee,debtFee,billId,payTime,status,paymentType,createdTime,updatedTime,createdBy,updatedBy")] tbl_Payment tbl_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_Payment.billId);
            return View(tbl_Payment);
        }

        // GET: tbl_Payment/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            if (tbl_Payment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment);
        }

        // POST: tbl_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            db.tbl_Payment.Remove(tbl_Payment);
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
