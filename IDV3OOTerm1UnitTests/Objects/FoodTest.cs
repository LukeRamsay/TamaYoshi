using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDV300Term1;
using IDV300Term1.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace IDV3OOTerm1.Objects.UnitTests
{
    [TestClass()]
    public class FoodTest
    {
        [TestMethod()]
        public void FoodTestMethod()
        {
            var FoodStates = new FoodStates();
            FoodState foodState = FoodState.good;
            var expectedResult = "good";

            FoodState result = FoodStates.GetFoodState(expectedResult);

            Assert.AreEqual(foodState, result);

            //Trying to use get string rather than get state (Doesnt Work)
            //var FoodStates = new FoodStates();
            //FoodState foodState = FoodState.good;
            //var expectedResult = "good";

            //FoodState result = FoodStates.GetFoodString(foodState expectedResult);

            //Assert.AreEqual(expectedResult, result);
        }
    }
}