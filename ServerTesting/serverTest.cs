using NUnit.Framework;
using UnityServerBasics.Network;

namespace ServerTesting
{
    [TestFixture]
    public class serverTest
    {
        private Server _server;

        [SetUp]
        public void Init()
        {
            _server = new Server(1919);
        }

        [TestCase]
        public void test1()
        {
            Assert.AreEqual(_server.StartServer(), true);
            Assert.AreEqual(_server.Status(), "Background");
        }

        [TearDown]
        public void Exit()
        {
            _server.Dispose();
        }
        
    }
}