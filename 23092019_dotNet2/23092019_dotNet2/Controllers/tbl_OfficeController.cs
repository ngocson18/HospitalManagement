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
    public class tbl_OfficeController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Office
        public ActionResult Index()
        {
            return View(db.tbl_Office.ToList());
        }

        // GET: tbl_Office/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Office tbl_Office = db.tbl_Office.Find(id);
            if (tbl_Office == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Office);
        }

        // GET: tbl_Office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Office/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,address,phone,email,manager,description,status,startedDate,endDate,createdTime,updatedTime,createdBy,updatedBy")] tbl_Office tbl_Office)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Office.Add(tbl_Office);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Office);
        }

        // GET: tbl_Office/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Office tbl_Office = db.tbl_Office.Find(id);
            if (tbl_Office == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Office);
        }

        // POST: tbl_Office/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,address,phone,email,manager,description,status,startedDate,endDate,createdTime,updatedTime,createdBy,updatedBy")] tbl_Office tbl_Office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Office).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Office);
        }

        // GET: tbl_Office/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Office tbl_Office = db.tbl_Office.Find(id);
            if (tbl_Office == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Office);
        }

        // POST: tbl_Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_Office tbl_Office = db.tbl_Office.Find(id);
            db.tbl_Office.Remove(tbl_Office);
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
