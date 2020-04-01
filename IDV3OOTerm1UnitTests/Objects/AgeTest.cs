using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDV300Term1;
using IDV300Term1.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace IDV3OOTerm1.Objects.UnitTests
{
    [TestClass()]
    public class AgeTest
    {
        [TestMethod()]
        public void AgeTestMethod()
        {
            var AgeStates = new AgeStates();
            AgeState ageState = AgeState.teen;
            var expectedResult = "teen";

            AgeState result = AgeStates.GetAgeState(expectedResult);

            Assert.AreEqual(ageState, result);
        }

        [TestMethod()]
        public void AgeTestMethod2()
        {
            var AgeStates2 = new AgeStates();
            AgeState ageState2 = AgeState.egg;
            var expectedResult2 = "egg";

            AgeState result2 = AgeStates.GetAgeState(expectedResult2);

            Assert.AreEqual(ageState2, result2);
        }

        [TestMethod()]
        public void AgeTestMethod3()
        {
            var AgeStates3 = new AgeStates();
            AgeState ageState3 = AgeState.adult;
            var expectedResult3 = "adult";

            AgeState result3 = AgeStates.GetAgeState(expectedResult3);

            Assert.AreEqual(ageState3, result3);
        }
    }
}