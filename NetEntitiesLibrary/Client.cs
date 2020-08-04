using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TextConverter;

namespace NetEntitiesLibrary
{
    /// <summary>
    /// Class contains client part of the NetWork Chat and it's constructor and subscription to an event
    /// </summary>
    public class Client:NetChatEntity
    {
        /// <summary>
        /// Chat log in two alphabets
        /// </summary>
        public Dictionary<string, string> History = new Dictionary<string, string>();

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ip">Ip adress</param>
        /// <param name="port">Port</param>
        public Client(string ip, UInt16 port) : base(ip, port)
        {
            ReciveMessage reciveMessage = delegate (string message)
            {
                TextConverter.ConvertMessage convert = new ConvertMessage();
                History.Add(message, convert.Convert(message));
            };

            ReciveMessageEvent += reciveMessage;
        }

    }
}
