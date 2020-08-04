using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetEntitiesLibrary
{
    /// <summary>
    /// Class contains server part of the NetWork Chat and it's constructor and subscription to an event
    /// </summary>
    public class Server:NetChatEntity
    {
        /// <summary>
        /// Contains all message history within LAN
        /// </summary>
        public Dictionary<NetChatEntity, string> ChatLogs = new Dictionary<NetChatEntity, string>();

        /// <summary>
        /// Chat log in two alphabets
        /// </summary>
        public List<string> History = new List<string>();

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ip">IP adress</param>
        /// <param name="port">Port</param>
        public Server(string ip, UInt16 port): base (ip, port)
        {
            GetMessage getMessage = (entity, message) =>
             {
                 ChatLogs.Add(entity, message);
             };

            ReciveMessage recive = (message) => History.Add(message);

            GetMessageEvent += getMessage;
            ReciveMessageEvent += recive;
        }

    }
}
