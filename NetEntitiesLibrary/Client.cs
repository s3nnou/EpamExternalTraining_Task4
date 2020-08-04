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

        /// <summary>
        /// Makes an equation between two objects
        /// </summary>
        /// <param name="obj">Object to be proceed</param>
        /// <returns>true - if equal, flase - if not</returns>
        public override bool Equals(object obj)
        {
            if (obj is Client)
            {
                Client client = obj as Client;

                if (client.Adress.ToString() == this.Adress.ToString() && client.Port == this.Port)
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
            return base.GetHashCode() ^ History.GetHashCode();
        }

        /// <summary>
        /// Returns class data in a text format
        /// </summary>
        /// <returns>Class data</returns>
        public override string ToString()
        {
            return string.Format($"Client is on") + base.ToString();
        }
    }
}
