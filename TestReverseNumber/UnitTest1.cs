using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseNumber;

namespace TestReverseNumber
{
    [TestClass]
    public class TestReverseNumber
    {
        [TestMethod]
        public void ReverseInt_GoodPositiveInt_ShouldPass()
        {

            int input1 = 123456789;
            int output1 = 987654321;

            Assert.AreEqual(output1, Operation.Reverse(input1));
        }

        [TestMethod]
        public void ReverseInt_GoodNegativeInt_ShouldPass()
        {

            int input1 = -123456789;
            int output1 = -987654321;

            Assert.AreEqual(output1, Operation.Reverse(input1));
        }



        [TestMethod]
        public void ReverseLng_GoodPositiveLong_ShouldPass()
        {

            long input1 = 123456789012345678;
            long output1 = 876543210987654321;

            Assert.AreEqual(output1, Operation.Reverse(input1));
        }

        [TestMethod]
        public void ReverseLong_GoodNegativeLong_ShouldPass()
        {

            long input1 = -123456789123456789;
            long output1 = -987654321987654321;

            Assert.AreEqual(output1, Operation.Reverse(input1));
        }


    }
}
