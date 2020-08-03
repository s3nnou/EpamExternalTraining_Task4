using System;
using System.Net;

namespace NetEntitiesLibrary
{
    public class NetEntity
    {
        public IPAddress Adress { get; }
        public UInt16 Port { get; }

        public NetEntity(string ip, UInt16 port)
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


    }
}
