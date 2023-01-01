using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using лр5.Models;

namespace лр5.Controllers
{
    public class seaq2_ResultController : Controller
    {
        private MedicineEntities db = new MedicineEntities();

        // GET: seaq2_Result
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult seaq2Query(string name)
        {
            var query = "exec seaq2 '" + name + "'";
            Console.WriteLine(query);
            var data = db.Database.SqlQuery<seaq2_Result>(query);
            return View(data.ToList());
        }
    }
}