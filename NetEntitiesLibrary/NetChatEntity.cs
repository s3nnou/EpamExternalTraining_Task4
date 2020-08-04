using System;
using System.Net;

namespace NetEntitiesLibrary
{
    /// <summary>
    /// Class for establishing any internet entity
    /// </summary>
    public class NetChatEntity
    {
        /// <summary>
        /// Entity's IP adress
        /// </summary>
        public IPAddress Adress { get; }

        /// <summary>
        /// Entity's port
        /// </summary>
        public UInt16 Port { get; }

        /// <summary>
        /// Delegate contains a method for handling message on client side
        /// </summary>
        /// <param name="message">Sent message</param>
        public delegate void ReciveMessage(string message);

        /// <summary>
        /// Event activates if there are any message recived by client or server
        /// </summary>
        public event ReciveMessage ReciveMessageEvent;

        /// <summary>
        /// Delegate contains a method for handling message on server side
        /// </summary>
        /// <param name="entity">Who's going to get a message</param>
        /// <param name="message">Message</param>
        public delegate void GetMessage(NetChatEntity entity, string message);

        /// <summary>
        /// Event activates if there are any message recived by server
        /// </summary>
        public event GetMessage GetMessageEvent;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ip">Ip adress</param>
        /// <param name="port">Port</param>
        public NetChatEntity(string ip, UInt16 port)
        {
            IPAddress acceptedIp;
            if (IPAddress.TryParse(ip, out acceptedIp))
            {
                Adress = acceptedIp;
                Port = port;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Method for sending message to only one NetEntity
        /// </summary>
        /// <param name="entity">Who's going to get message</param>
        /// <param name="server">LAN server</param>
        /// <param name="message">Message</param>
        public void SendMessage(NetChatEntity entity,Server server, string message)
        {
            entity.ReciveMessageEvent(message);
            server.GetMessageEvent(entity, message);
        }
    }
}
