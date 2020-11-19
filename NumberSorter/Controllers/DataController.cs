using NumberSorter.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberSorter.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult AllSortedData(){
            return Json(DBAccessModel.getAllAsJson(), JsonRequestBehavior.AllowGet);
        }
    }
}