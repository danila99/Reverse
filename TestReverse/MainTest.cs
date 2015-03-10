using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reverse;
using System.Collections.Generic;

namespace TestReverse
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void TestReverseManualOdd()
        {
            string[] actual = new string[] { "1", "2", "3", "4", "5" };
            string[] expected = new string[] { "5", "4", "3", "2", "1" };

            var result = Program.ReverseManual(actual);
            
            for(int i=0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], result[i]);
        }

        [TestMethod]
        public void TestReverseManualEven()
        {
            string[] actual = new string[] { "1", "2", "3", "4" };
            string[] expected = new string[] { "4", "3", "2", "1" };

            var result = Program.ReverseManual(actual);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], result[i]);
        }

        [TestMethod]
        public void TestReverseManualEmpty()
        {
            string[] actual = new string[] {  };
            string[] expected = new string[] {  };

            var result = Program.ReverseManual(actual);
            Assert.IsTrue(result.Length == 0);
        }
    }
}
