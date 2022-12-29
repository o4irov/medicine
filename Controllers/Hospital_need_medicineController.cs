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
    public class Hospital_need_medicineController : Controller
    {
        private MedicineEntities db = new MedicineEntities();

        // GET: Hospital_need_medicine
        public ActionResult Index()
        {
            var hospital_need_medicine = db.Hospital_need_medicine.Include(h => h.Hospital).Include(h => h.Medicine);
            return View(hospital_need_medicine.ToList());
        }

        // GET: Hospital_need_medicine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital_need_medicine hospital_need_medicine = db.Hospital_need_medicine.Find(id);
            if (hospital_need_medicine == null)
            {
                return HttpNotFound();
            }
            return View(hospital_need_medicine);
        }

        // GET: Hospital_need_medicine/Create
        public ActionResult Create()
        {
            ViewBag.Hospital_idHospital = new SelectList(db.Hospital, "idHospital", "addresHospital");
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine");
            return View();
        }

        // POST: Hospital_need_medicine/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Hospital_need_medicine,Medicine_idMedicine,Hospital_idHospital,quantity_of_packs")] Hospital_need_medicine hospital_need_medicine)
        {
            if (ModelState.IsValid)
            {
                db.Hospital_need_medicine.Add(hospital_need_medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hospital_idHospital = new SelectList(db.Hospital, "idHospital", "addresHospital", hospital_need_medicine.Hospital_idHospital);
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine", hospital_need_medicine.Medicine_idMedicine);
            return View(hospital_need_medicine);
        }

        // GET: Hospital_need_medicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital_need_medicine hospital_need_medicine = db.Hospital_need_medicine.Find(id);
            if (hospital_need_medicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hospital_idHospital = new SelectList(db.Hospital, "idHospital", "addresHospital", hospital_need_medicine.Hospital_idHospital);
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine", hospital_need_medicine.Medicine_idMedicine);
            return View(hospital_need_medicine);
        }

        // POST: Hospital_need_medicine/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Hospital_need_medicine,Medicine_idMedicine,Hospital_idHospital,quantity_of_packs")] Hospital_need_medicine hospital_need_medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital_need_medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hospital_idHospital = new SelectList(db.Hospital, "idHospital", "addresHospital", hospital_need_medicine.Hospital_idHospital);
            ViewBag.Medicine_idMedicine = new SelectList(db.Medicine, "idMedicine", "name_of_medicine", hospital_need_medicine.Medicine_idMedicine);
            return View(hospital_need_medicine);
        }

        // GET: Hospital_need_medicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital_need_medicine hospital_need_medicine = db.Hospital_need_medicine.Find(id);
            if (hospital_need_medicine == null)
            {
                return HttpNotFound();
            }
            return View(hospital_need_medicine);
        }

        // POST: Hospital_need_medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital_need_medicine hospital_need_medicine = db.Hospital_need_medicine.Find(id);
            db.Hospital_need_medicine.Remove(hospital_need_medicine);
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
