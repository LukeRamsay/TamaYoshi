using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDV300Term1;
using IDV300Term1.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace IDV3OOTerm1.Objects.UnitTests
{
    [TestClass()]
    public class BedTest
    {
        [TestMethod()]
        public void BedTestMethod()
        {
            var BedStates = new BedStates();
            BedState bedState = BedState.good;
            var expectedResult = "good";

            BedState result = BedStates.GetBedState(expectedResult);

            Assert.AreEqual(bedState, result);
        }
        [TestMethod()]
        public void BedTestMethod2()
        {
            var BedStates2 = new BedStates();
            BedState bedState2 = BedState.normal;
            var expectedResult2 = "normal";

            BedState result2 = BedStates.GetBedState(expectedResult2);

            Assert.AreEqual(bedState2, result2);
        }
        [TestMethod()]
        public void BedTestMethod3()
        {
            var BedStates3 = new BedStates();
            BedState bedState3 = BedState.bad;
            var expectedResult3 = "bad";

            BedState result3 = BedStates.GetBedState(expectedResult3);

            Assert.AreEqual(bedState3, result3);
        }
    }
}