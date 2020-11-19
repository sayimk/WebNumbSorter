using NumberSorter.Models.Parsers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace NumberSorter.Models.SortType
{
    public class NumberSortModel
    {
        public static string sortDirectionAscending = "ASCE";
        public static string sortDirectionDescending = "DESC";

        public List<int> numbers { get; set; }

        public string sortDirection { get; set; }

        public double sortMillisecTime { get; set; }

        public NumberSortModel(){
            numbers = new List<int>();
            sortDirection = "";
            sortMillisecTime = 0.0;
        }

        public NumberSortModel(List<int> numbers, string sortDirection){

            this.numbers = numbers;
            this.sortDirection = sortDirection;
        }

        public Boolean sortNumbers(){

            Stopwatch stopWatch = new Stopwatch();

            if (numbers.Count == 0)
                return false;

            try{
                if (sortDirection=="DESC"){

                    stopWatch.Start();
                    numbers.Sort((a, b) => b.CompareTo(a));
                    stopWatch.Stop();
                }
                else{
                    
                    stopWatch.Start();
                    numbers.Sort((a, b) => a.CompareTo(b));
                    stopWatch.Stop();
                }
            }catch (Exception){

                stopWatch.Stop();
                return false;
            }

            sortMillisecTime = stopWatch.Elapsed.TotalMilliseconds;
            return true;
        }
    }
}