using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetEntitiesLibrary
{
    public class Server:NetEntity
    {
        public Dictionary<NetEntity, List<string>> ChatLogs = new Dictionary<NetEntity, List<string>>();

        private event CatchMsg Notify;

        public delegate string CatchMsg(string message);

        public Server(string ip, UInt16 port): base (ip, port)
        {
            
        }
    }
}
