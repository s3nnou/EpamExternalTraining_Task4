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

        /// <summary>
        /// Makes an equation between two objects
        /// </summary>
        /// <param name="obj">Object to be proceed</param>
        /// <returns>true - if equal, flase - if not</returns>
        public override bool Equals(object obj)
        {
            if(obj is Server)
            {
                Server server = obj as Server;

                if(server.Adress.ToString() == this.Adress.ToString() && server.Port == this.Port)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates Class HashCode
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ History.GetHashCode() ^ ChatLogs.GetHashCode();
        }

        /// <summary>
        /// Returns class data in a text format
        /// </summary>
        /// <returns>Class data</returns>
        public override string ToString()
        {
            return string.Format($"Server is on ") + base.ToString();
        }
    }
}
