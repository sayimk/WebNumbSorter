using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSorter.Models.NumberModels;

namespace NumberSorter.Tests.Models.NumberModelsTest
{
    [TestClass]
    public class NumberSortModelTest
    {
        [TestMethod]
        public void sortNumbers_ValidInput_Ascending(){

            NumberSortModel testModel = new NumberSortModel();
            testModel.numbers = new List<int>() { 4, 3, 2, 1 };
            testModel.sortDirection = NumberSortModel.sortDirectionAscending;


            testModel.SortNumbers();

            Boolean results = false;

            if ((testModel.numbers.Count == 4) && (testModel.numbers[0] == 1))
                results = true;


            Assert.IsTrue(results);
        }

        [TestMethod]
        public void sortNumbers_ValidInput_Descending()
        {

            NumberSortModel testModel = new NumberSortModel();
            testModel.numbers = new List<int>() { 1, 2, 3, 4 };
            testModel.sortDirection = NumberSortModel.sortDirectionDescending;

            testModel.SortNumbers();

            Boolean results = false;
            if ((testModel.numbers.Count == 4) && (testModel.numbers[0] == 4))
                results = true;


            Assert.IsTrue(results);
        }

        [TestMethod]
        public void sortNumbers_NoInputs()
        {

            NumberSortModel testModel = new NumberSortModel();
            testModel.numbers = new List<int>();
            testModel.sortDirection = NumberSortModel.sortDirectionAscending;

            testModel.SortNumbers();

            Assert.IsTrue(!testModel.SortNumbers());
            
        }

        [TestMethod]
        public void sortNumbers_isTimed()
        {

            NumberSortModel testModel = new NumberSortModel();
            testModel.numbers = new List<int>() { 4, 3, 2, 1 };
            testModel.sortDirection = NumberSortModel.sortDirectionAscending;


            testModel.SortNumbers();

            Assert.IsTrue(testModel.sortMillisecTime != 0.0);
            
        }

    }
}
