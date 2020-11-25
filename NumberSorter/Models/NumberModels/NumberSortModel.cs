using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NumberSorter.Models.NumberModels
{
    public class NumberSortModel
    {
        public static string sortDirectionAscending = "ASCE";
        public static string sortDirectionDescending = "DESC";

        public List<int> sortedNumbers { get; set; }

        public string sortDirection { get; set; }

        public double sortTimeMillisec { get; set; }

        public NumberSortModel()
        {
            sortedNumbers = new List<int>();
            sortDirection = "";
            sortTimeMillisec = 0.0;
        }

        public NumberSortModel(List<int> numbers, string sortDirection)
        {
            this.sortedNumbers = numbers;
            this.sortDirection = sortDirection;
        }

        public bool SortNumbers()
        {
            var stopWatch = new Stopwatch();

            if (sortedNumbers.Count == 0)
                return false;

            try
            {
                if (sortDirection == "DESC")
                {

                    stopWatch.Start();
                    sortedNumbers.Sort((a, b) => b.CompareTo(a));
                    stopWatch.Stop();
                }
                else
                {

                    stopWatch.Start();
                    sortedNumbers.Sort((a, b) => a.CompareTo(b));
                    stopWatch.Stop();
                }
            }
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }

            sortTimeMillisec = stopWatch.Elapsed.TotalMilliseconds;
            return true;
        }
    }
}