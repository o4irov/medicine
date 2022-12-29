using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using лр5.Models;

namespace лр5.Controllers
{
    public class PharmaciesController : Controller
    {
        private MedicineEntities db = new MedicineEntities();

        // GET: Pharmacies
        public ActionResult Index()
        {
            return View(db.Pharmacy.ToList());
        }

        // GET: Pharmacies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = db.Pharmacy.Find(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPharmacy,namePharmacy,addresPharmacy")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                db.Pharmacy.Add(pharmacy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pharmacy);
        }

        // GET: Pharmacies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = db.Pharmacy.Find(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPharmacy,namePharmacy,addresPharmacy")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharmacy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = db.Pharmacy.Find(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pharmacy pharmacy = db.Pharmacy.Find(id);
            db.Pharmacy.Remove(pharmacy);
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
