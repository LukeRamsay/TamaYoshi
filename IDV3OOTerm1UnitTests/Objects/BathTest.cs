using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDV300Term1;
using IDV300Term1.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace IDV3OOTerm1.Objects.UnitTests
{
    [TestClass()]
    public class BathTest
    {
        [TestMethod()]
        public void BathTestMethod()
        {
            var BathStates = new BathStates();
            BathState bathState = BathState.good;
            var expectedResult = "good";

            BathState result = BathStates.GetBathState(expectedResult);

            Assert.AreEqual(bathState, result);
        }
        [TestMethod()]
        public void BathTestMethod2()
        {
            var BathStates2 = new BathStates();
            BathState bathState2 = BathState.bad;
            var expectedResult2 = "bad";

            BathState result2 = BathStates.GetBathState(expectedResult2);

            Assert.AreEqual(bathState2, result2);
        }
        [TestMethod()]
        public void BathTestMethod3()
        {
            var BathStates3 = new BathStates();
            BathState bathState3 = BathState.normal;
            var expectedResult3 = "normal";

            BathState result3 = BathStates.GetBathState(expectedResult3);

            Assert.AreEqual(bathState3, result3);
        }
    }
}