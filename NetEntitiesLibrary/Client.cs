using System;
using System.Collections.Generic;
using System.Text;

namespace NetEntitiesLibrary
{
    public class Client:NetEntity
    {
        private event Send Notify;

        public delegate string Send(string message);

        public List<string> History = new List<string>();

        public static void SendMessage(string message, Send send)
        {
            send(message);
        }

        public Client(string ip, UInt16 port) : base(ip, port)
        {

        }

        public void SendMessage(string message)
        {
            History.Add(message);

        }

        public void Subscribe(Send function) => Notify += function;
        public void Unsubscribe(Send function) => Notify -= function;

        public void Subscribe(Send function) => Notify += function;
        public void Unsubscribe(Send function) => Notify -= function;

    }
}
