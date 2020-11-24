using System.Web.Mvc;
using System.Collections.Generic;
using NumberSorter.Services.Parsers;
using NumberSorter.Models.NumberModels;
using NumberSorter.Services.DB;

namespace NumberSorter.Controllers
{
    public class NumberManipulatorController : Controller
    {
        // GET: NumberManipulator

        public JsonResult Sort()
        {
            var dbAccessModel = new DBAccessModel();
            var numberSort = new NumberSortModel(StoiParser.ToIntList(Request["numbersString"]),
                Request["sortDirection"]);


            if (!numberSort.SortNumbers())
                return Json(new List<string>() { "1", "An Sort Error Occurred, Please check input" }, JsonRequestBehavior.AllowGet);


            if (!dbAccessModel.AddSortedToDB(StoiParser.ToString(numberSort.numbers), 
                numberSort.sortDirection, numberSort.sortMillisecTime))
                return Json(new List<string>() { "2", "A Database Error has occurred, Please try again later" }, JsonRequestBehavior.AllowGet);

            return Json(new List<string>() {"0", "Added Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}