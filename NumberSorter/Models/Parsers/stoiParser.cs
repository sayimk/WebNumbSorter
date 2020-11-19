using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberSorter.Models.Parsers
{
    public class stoiParser{

        public static List<int> toIntList(string sin){

            List<int> outList = new List<int>();

            if (!sin.Contains(","))
                return outList;

            string[] sList = sin.Split(',');

            try{
                foreach (string item in sList){

                    outList.Add(int.Parse(item));
                }

            }catch (FormatException){
                
                return new List<int> ();
            }

            return outList;
        }

        public static string toString(List<int> intList){

            string result = "";

            if (intList.Count>0){

                result = intList[0].ToString();

                if (intList.Count>1){

                    for (int i = 1; i < intList.Count; i++){
                        result = result + "," +intList[i];
                    }
                }
            }else{
                return "";
            }

            return result;
        }

    }
}