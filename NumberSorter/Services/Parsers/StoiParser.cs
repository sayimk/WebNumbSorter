using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberSorter.Services.Parsers
{
    public class StoiParser
    {
        public static List<int> ToIntList(string input)
        {
            var output = new List<int>();

            if (!input.Contains(","))
                return output;

            var splitList = input.Split(',');

            try
            {
                foreach (string item in splitList)
                {
                    output.Add(int.Parse(item));
                }

            }
            catch (FormatException)
            {
                return new List<int>();
            }

            return output;
        }

        public static string ToString(List<int> input)
        {
            string result = "";

            if (input.Count > 0)
            {
                result = input[0].ToString();

                if (input.Count > 1)
                {
                    for (int i = 1; i < input.Count; i++)
                    {
                        result = result + "," + input[i];
                    }
                }
            }
            else
            {
                return "";
            }

            return result;
        }

    }
}