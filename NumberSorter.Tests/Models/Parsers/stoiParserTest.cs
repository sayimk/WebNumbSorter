using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSorter.Models.Parsers;

namespace NumberSorter.Tests.Models.Parsers
{
    [TestClass]
    public class stoiParserTest
    {
        [TestMethod]
        public void toIntList_ValidInput(){

            string validIn = "1,2,3,4";
            List<int> expected = new List<int>() {1,2,3,4};


            List<int> result = stoiParser.toIntList(validIn);


            Assert.AreEqual(expected.Count, result.Count);
        }
       
        [TestMethod]
        public void toIntList_InvalidInput(){

            string validIn = "a,b,c,d";

            List<int> result = stoiParser.toIntList(validIn);

            Assert.AreEqual(0, result.Count);
        }


        [TestMethod]
        public void toString_ValidInput()
        {

            List<int> test = new List<int>() { 1, 2, 3, 4 };


            string result = stoiParser.toString(test);

            System.Diagnostics.Trace.WriteLine("1,2,3,4");
            System.Diagnostics.Trace.WriteLine(result);


            Assert.AreEqual("1,2,3,4", result);
        }

    }

}
