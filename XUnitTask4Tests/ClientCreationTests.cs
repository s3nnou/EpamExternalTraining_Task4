using NetEntitiesLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTask4Tests
{
    /// <summary>
    /// Class for Client Class creation tests
    /// </summary>
    public class ClientCreationTests
    {
        /// <summary>
        /// Test class
        /// </summary>
        /// <param name="ip">client ip</param>
        /// <param name="port">client port</param>
        /// <param name="ex_client">expected client object class</param>
        [Theory]
        [MemberData(nameof(Data))]
        public void Various_Client_Creation(string ip, UInt16 port, Client ex_client)
        {
            var client = new Client(ip, port);
            Assert.True(ex_client.Equals(client));
        }

        /// <summary>
        /// Data to test Client Creation within Various_Client_Creation method
        /// </summary>
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "127.0.0.1", 1000, new Client("127.0.0.1", 1000) },
            new object[] { "127.0.0.2", 1000, new Client("127.0.0.2", 1000) },
            new object[] { "127.0.0.3", 1000, new Client("127.0.0.3", 1000) },
            new object[] { "7.123.32.4", 1000, new Client("7.123.32.4", 1000) },
            new object[] { "1.0.0.1", 1000, new Client("1.0.0.1", 1000) },
            new object[] { "254.244.24.0", 1000, new Client("254.244.24.0", 1000) },
        };

        /// <summary>
        /// Creates an exception to demostrate wrong ip adress insertion
        /// </summary>
        [Fact]
        public void CreatingClient_WithWrongArguments_ThrowsArgumentException()
        {
            Client client;
            Assert.Throws<ArgumentException>(() => client = new Client("12312.3.2.1", 1000));
        }
    }
}
