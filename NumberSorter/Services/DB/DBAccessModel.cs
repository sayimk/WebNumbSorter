using NumberSorter.Models.NumberModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NumberSorter.Services.DB
{
    public class DBAccessModel
    {
        public bool AddSortedToDB(string sortedNumberString, string sortDirection, double sortTimeMillisec)
        {
            bool successful = false;

            try
            {
                using (var ctx = new Sorts())
                {

                    var newSort = new Sort()
                    {
                        sortedNumbers = sortedNumberString,
                        sortDirection = sortDirection,
                        sortTimeMillisec = (decimal?)sortTimeMillisec
                    };

                    int preAdd = ctx.SortedNumbers.ToList().Count;

                    ctx.SortedNumbers.Add(newSort);
                    ctx.SaveChanges();

                    if (ctx.SortedNumbers.ToList().Count>preAdd)
                    {
                        successful = true;
                    }
                }
            }
            catch (Exception)
            {
                return successful;
            }

            return successful;
        }


        public List<Object> GetAllAsJson()
        {
            var resultJson = new List<Object>();

            try
            {
                using (var ctx = new Sorts())
                {
                    List<Sort> results = ctx.SortedNumbers.ToList();

                    foreach (var item in results)
                    {
                       
                        var temp = new List<object>();
                        temp.Add(item.sortedNumbers);
                        temp.Add(item.sortTimeMillisec);
                        temp.Add(item.sortDirection);

                        resultJson.Add(temp);
                    }
                }
            }
            catch (Exception)
            {
                resultJson.Add("Error in fetching Data");
            }

            return resultJson;
        }
    }

}