using NetEntitiesLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTask4Tests
{
    /// <summary>
    /// Class for Server Class creation tests
    /// </summary>
    public class ServerCreationTests
    {
        /// <summary>
        /// Test class
        /// </summary>
        /// <param name="ip">server ip</param>
        /// <param name="port">server port</param>
        /// <param name="ex_client">expected server</param>
        [Theory]
        [MemberData(nameof(Data))]
        public void Various_Server_Creation(string ip, UInt16 port, Server ex_client)
        {
            var client = new Server(ip, port);
            Assert.True(ex_client.Equals(client));
        }

        /// <summary>
        /// Data to test Server Creation within Various_Server_Creation method
        /// </summary>
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "127.0.0.1", 1000, new Server("127.0.0.1", 1000) },
            new object[] { "127.0.0.2", 1000, new Server("127.0.0.2", 1000) },
            new object[] { "127.0.0.3", 1000, new Server("127.0.0.3", 1000) },
            new object[] { "7.123.32.4", 1000, new Server("7.123.32.4", 1000) },
            new object[] { "1.0.0.1", 1000, new Server("1.0.0.1", 1000) },
            new object[] { "254.244.24.0", 1000, new Server("254.244.24.0", 1000) },
        };

        /// <summary>
        /// Creates an exception to demostrate wrong ip adress insertion
        /// </summary>
        [Fact]
        public void CreatingServer_WithWrongArguments_ThrowsArgumentException()
        {
            Server server;
            Assert.Throws<ArgumentException>(() =>  server = new Server("12312.3.2.1", 1000));
        }
    }
}
