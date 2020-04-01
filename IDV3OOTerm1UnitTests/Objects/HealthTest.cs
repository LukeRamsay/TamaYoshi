using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDV300Term1;
using IDV300Term1.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace IDV3OOTerm1.Objects.UnitTests
{
    [TestClass()]
    public class HealthTest
    {
        [TestMethod()]
        public void HealthTestMethod()
        {
            var HealthStates = new HealthStates();
            HealthState healthState = HealthState.good;
            var expectedResult = "good";

            HealthState result = HealthStates.GetHealthState(expectedResult);

            Assert.AreEqual(healthState, result);
        }
        [TestMethod()]
        public void HealthTestMethod2()
        {
            var HealthStates2 = new HealthStates();
            HealthState healthState2 = HealthState.good;
            var expectedResult2 = "good";

            HealthState result2 = HealthStates.GetHealthState(expectedResult2);

            Assert.AreEqual(healthState2, result2);
        }
        [TestMethod()]
        public void HealthTestMethod3()
        {
            var HealthStates3 = new HealthStates();
            HealthState healthState3 = HealthState.good;
            var expectedResult3 = "good";

            HealthState result3 = HealthStates.GetHealthState(expectedResult3);

            Assert.AreEqual(healthState3, result3);
        }
    }
}