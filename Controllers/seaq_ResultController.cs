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
    public class seaq_ResultController : Controller
    {
        private MedicineEntities db = new MedicineEntities();

        // GET: seaq_Result
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult seaqQuery(int i, string val)
        {
            var query = "exec seaq '" + i.ToString() + "', '" + val + "'";
            Console.WriteLine(query);
            var data = db.Database.SqlQuery<seaq_Result>(query);
            return View(data.ToList());
        }
    }
}