using NumberSorter.Models.SortType;
using NumberSorter.Models.DB;
using NumberSorter.Models.Parsers;
using System.Web.Mvc;
using System.Collections.Generic;

namespace NumberSorter.Controllers
{
    public class NumberManipulatorController : Controller{

        // GET: NumberManipulator

        public JsonResult Sort(){


            NumberSortModel numberSort = new NumberSortModel(stoiParser.toIntList(Request["numbersString"]),
                Request["sortDirection"]);


            if (!numberSort.sortNumbers())
                return Json(new List<string>() { "1", "An Sort Error Occurred, Please check input" }, JsonRequestBehavior.AllowGet);


            if (!DBAccessModel.addSortedToDB(stoiParser.toString(numberSort.numbers), 
                numberSort.sortDirection, numberSort.sortMillisecTime))
                return Json(new List<string>() { "2", "A Database Error has occurred, Please try again later" }, JsonRequestBehavior.AllowGet);

            return Json(new List<string>() {"0", "Added Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}