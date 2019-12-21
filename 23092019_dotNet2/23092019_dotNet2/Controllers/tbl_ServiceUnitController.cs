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
    public class tbl_ServiceUnitController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_ServiceUnit
        public ActionResult Index()
        {
            return View(db.tbl_ServiceUnit.ToList());
        }

        // GET: tbl_ServiceUnit/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            if (tbl_ServiceUnit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceUnit);
        }

        // GET: tbl_ServiceUnit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_ServiceUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,priceVND,priceUSD,note,minPrice,maxPrice,picture,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_ServiceUnit tbl_ServiceUnit)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ServiceUnit.Add(tbl_ServiceUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ServiceUnit);
        }

        // GET: tbl_ServiceUnit/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            if (tbl_ServiceUnit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceUnit);
        }

        // POST: tbl_ServiceUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,priceVND,priceUSD,note,minPrice,maxPrice,picture,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_ServiceUnit tbl_ServiceUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ServiceUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ServiceUnit);
        }

        // GET: tbl_ServiceUnit/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            if (tbl_ServiceUnit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceUnit);
        }

        // POST: tbl_ServiceUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            db.tbl_ServiceUnit.Remove(tbl_ServiceUnit);
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
