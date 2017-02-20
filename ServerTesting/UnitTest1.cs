using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServerTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("server")]
        public void TestMethod1()
        {
            Console.WriteLine("This test is executed automatically");
            Assert.AreEqual(true, true);
        }

        [TestMethod, TestCategory("client")]
        public void TestMethod2()
        {
            Console.WriteLine("This test is executed automatically");
            Assert.AreEqual(true, true);
        }
    }
}
