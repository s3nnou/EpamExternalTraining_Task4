using NetEntitiesLibrary;
using System;
using System.Collections.Generic;
using TextConverter;
using Xunit;

namespace XUnitTask4Tests
{
    /// <summary>
    /// Class for Text Delivery tests
    /// </summary>
    public class TextDeliveryTests
    {
        /// <summary>
        /// Delivers text from one entity to another
        /// </summary>
        /// <param name="serverIp">server ip</param>
        /// <param name="serverPort">server port</param>
        /// <param name="clientIp">client ip</param>
        /// <param name="clientPort">client port</param>
        /// <param name="messege">client message</param>
        /// <param name="expectedMessage">expected message</param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void Client_To_Server_Delivery_Tests(string serverIp, UInt16 serverPort, string clientIp, UInt16 clientPort, string messege, string expectedMessage)
        {
            Server server = new Server(serverIp, serverPort);
            Client client = new Client(clientIp, clientPort);

            List<NetChatEntity> LAN = new List<NetChatEntity>();

            LAN.Add(server);
            LAN.Add(client);

            client.SendMessage(server, server, LAN, messege);

            Assert.Equal(expectedMessage, server.History[0]);
        }

        /// <summary>
        /// Data to test text  delivery within  Client_To_Server_Delivery_Tests method
        /// </summary>
        public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        {
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000,  "privet",  "privet"},
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000, "мойдодыр", "мойдодыр"},
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000, "эльф", "эльф"},
            new object[]{ "127.0.0.1", 1000, "127.0.0.2", 1000, "hello", "hello"},
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000, "mama", "mama"},
        };

        /// <summary>
        /// Delivers text from one entity to another
        /// </summary>
        /// <param name="serverIp">server ip</param>
        /// <param name="serverPort">server port</param>
        /// <param name="clientIp">client ip</param>
        /// <param name="clientPort">client port</param>
        /// <param name="messege">client message</param>
        /// <param name="expectedMessage">expected message</param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void Server_To_Client_Delivery_Tests(string serverIp, UInt16 serverPort, string clientIp, UInt16 clientPort, string messege, string expectedMessage)
        {
            Server server = new Server(serverIp, serverPort);
            Client client = new Client(clientIp, clientPort);

            List<NetChatEntity> LAN = new List<NetChatEntity>();

            LAN.Add(server);
            LAN.Add(client);

            server.SendMessage(client, server, LAN, messege);

            Assert.Equal(expectedMessage, server.ChatLogs[client]);
        }

        /// <summary>
        /// Data to test text  delivery within Server_To_Client_Delivery_Tests method
        /// </summary>
        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000,  "privet",  "privet"},
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000, "мойдодыр", "мойдодыр"},
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000, "эльф", "эльф"},
            new object[]{ "127.0.0.1", 1000, "127.0.0.2", 1000, "hello", "hello"},
            new object[] { "127.0.0.1", 1000, "127.0.0.2", 1000, "mama", "mama"},
        };

        /// <summary>
        /// Delivers text from one entity to another
        /// </summary>
        /// <param name="serverIp">server ip</param>
        /// <param name="serverPort">server port</param>
        /// <param name="clientIp1">client 1 ip</param>
        /// <param name="clientPort1">client 1 port</param>
        /// <param name="clientIp2">client 2 ip</param>
        /// <param name="clientPort2">client 2 port</param>
        /// <param name="messege">client message</param>
        /// <param name="expectedMessage">expected message</param>
        [Theory]
        [MemberData(nameof(Data3))]
        public void Client_To_Client_Deliveries_Tests(string serverIp, UInt16 serverPort, string clientIp1,
                UInt16 clientPort1, string clientIp2, UInt16 clientPort2, string messege, string expectedMessage)
        {
                Server server = new Server(serverIp, serverPort);
                Client client1 = new Client(clientIp1, clientPort1);
                Client client2 = new Client(clientIp2, clientPort2);

                List<NetChatEntity> LAN = new List<NetChatEntity>();

                LAN.Add(server);
                LAN.Add(client1);
                LAN.Add(client2);

            client1.SendMessage(client2, server, LAN, messege);
            Assert.Equal(expectedMessage, client2.History[messege]);
        }

        /// <summary>
        /// Data to test text  delivery within Client_To_Client_Deliveries_Tests method
        /// </summary>
        public static IEnumerable<object[]> Data3 =>
            new List<object[]>
            {
                new object[] { "127.0.0.0", 1000, "127.0.0.1", 1000, "127.0.0.2", 1000,  "privet", "привет"},
                new object[] { "127.0.0.0", 1000, "127.0.0.1", 1000, "127.0.0.2", 1000, "мойдодыр", "moydodyir"},
                new object[] { "127.0.0.0", 1000, "127.0.0.1", 1000, "127.0.0.2", 1000, "эльф", "el'f"},
                new object[]{ "127.0.0.0", 1000, "127.0.0.1", 1000, "127.0.0.2", 1000, "hello", "хелло"},
                new object[] { "127.0.0.0", 1000, "127.0.0.1", 1000, "127.0.0.2", 1000, "mama", "мама"},
            };

        /// <summary>
        /// Creates an exception to demostrate wrong message alphabet insertion
         /// </summary>
        [Fact]
        public void CreatingServer_WithWrongArguments_ThrowsException()
        {
            Server server = new Server("127.0.0.1", 1000);
            Client client = new Client("127.0.0.2", 1000);

            List<NetChatEntity> LAN = new List<NetChatEntity>();

            LAN.Add(server);
            Assert.Throws<Exception>(() => client.SendMessage(client, server, LAN, "Just curious"));
        }
    }
}


