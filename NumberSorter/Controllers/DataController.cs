using NumberSorter.Services.DB;
using System.Web.Mvc;

namespace NumberSorter.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult AllSortedData()
        {

            var dbAccessModel = new DBAccessModel();

            return Json(dbAccessModel.GetAllAsJson(), JsonRequestBehavior.AllowGet);
        }
    }
}