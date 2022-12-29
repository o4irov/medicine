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
    public class Pharmacy_has_medicineController : Controller
    {
        private MedicineEntities db = new MedicineEntities();

        // GET: Pharmacy_has_medicine
        public ActionResult Index()
        {
            var pharmacy_has_medicine = db.Pharmacy_has_medicine.Include(p => p.Medicine).Include(p => p.Pharmacy);
            return View(pharmacy_has_medicine.ToList());
        }

        // GET: Pharmacy_has_medicine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy_has_medicine pharmacy_has_medicine = db.Pharmacy_has_medicine.Find(id);
            if (pharmacy_has_medicine == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy_has_medicine);
        }

        // GET: Pharmacy_has_medicine/Create
        public ActionResult Create()
        {
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine");
            ViewBag.Pharmacy_idPharmacy = new SelectList(db.Pharmacy, "idPharmacy", "namePharmacy");
            return View();
        }

        // POST: Pharmacy_has_medicine/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Pharmacy_has_medicine,Medicine_idMedicine,Pharmacy_idPharmacy,quntity_of_packs,cost_of_pack")] Pharmacy_has_medicine pharmacy_has_medicine)
        {
            if (ModelState.IsValid)
            {
                db.Pharmacy_has_medicine.Add(pharmacy_has_medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine", pharmacy_has_medicine.Medicine_idMedicine);
            ViewBag.Pharmacy_idPharmacy = new SelectList(db.Pharmacy, "idPharmacy", "namePharmacy", pharmacy_has_medicine.Pharmacy_idPharmacy);
            return View(pharmacy_has_medicine);
        }

        // GET: Pharmacy_has_medicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy_has_medicine pharmacy_has_medicine = db.Pharmacy_has_medicine.Find(id);
            if (pharmacy_has_medicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine", pharmacy_has_medicine.Medicine_idMedicine);
            ViewBag.Pharmacy_idPharmacy = new SelectList(db.Pharmacy, "idPharmacy", "namePharmacy", pharmacy_has_medicine.Pharmacy_idPharmacy);
            return View(pharmacy_has_medicine);
        }

        // POST: Pharmacy_has_medicine/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Pharmacy_has_medicine,Medicine_idMedicine,Pharmacy_idPharmacy,quntity_of_packs,cost_of_pack")] Pharmacy_has_medicine pharmacy_has_medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharmacy_has_medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine", pharmacy_has_medicine.Medicine_idMedicine);
            ViewBag.Pharmacy_idPharmacy = new SelectList(db.Pharmacy, "idPharmacy", "namePharmacy", pharmacy_has_medicine.Pharmacy_idPharmacy);
            return View(pharmacy_has_medicine);
        }

        // GET: Pharmacy_has_medicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy_has_medicine pharmacy_has_medicine = db.Pharmacy_has_medicine.Find(id);
            if (pharmacy_has_medicine == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy_has_medicine);
        }

        // POST: Pharmacy_has_medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pharmacy_has_medicine pharmacy_has_medicine = db.Pharmacy_has_medicine.Find(id);
            db.Pharmacy_has_medicine.Remove(pharmacy_has_medicine);
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
