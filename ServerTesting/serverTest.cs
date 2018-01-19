using System;
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
        public void StartServerTest()
        {
            Assert.AreEqual(_server.StartServer(), true);
            Assert.AreEqual(_server.Status(), "Background");
            Console.WriteLine("Server is running...");
        }

        [TearDown]
        public void Exit()
        {
            _server.Dispose();
        }
        
    }
}