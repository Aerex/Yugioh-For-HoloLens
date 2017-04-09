using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace YugiohUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public int Add2(int a, int b)
        {
            return a + b;
        }
        [TestMethod]
        public void TestMethod1()
        {
            int a = 1;
            int b = 2;
            Assert.AreEqual(Add2(1, 2), 3);
        }
    }
}
