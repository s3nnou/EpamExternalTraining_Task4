using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetEntitiesLibrary;

namespace NetEntitesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod1()
        {
            Server server = new Server("127.0.0.1", 1001);
            Client client1 = new Client("127.0.0.2", 1002, server);
            Client client2 = new Client("127.0.0.3", 1002, server);

            List<NetChatEntity> LAN = new List<NetChatEntity>();

            LAN.Add(server);
            LAN.Add(client1);
            LAN.Add(client2);

            client1.SendMessage(client2, server, "privet");

        }
    }
}
