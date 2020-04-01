using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDV300Term1;
using IDV300Term1.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace IDV3OOTerm1UnitTests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void TestMethod1()
        {

            var FoodStates = new FoodStates();
            FoodState foodState = FoodState.good;
            var expectedResult = "good";


            FoodState result = FoodStates.GetFoodState(expectedResult);


            Assert.AreEqual(foodState, result);
        }
    }
}