using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostsManager
{
    internal class Item
    {
        private string host;
        private int id;
        private string ip;

        public void setHost(string host)
        {
            this.host = host;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setIp(string ip)
        {
            this.ip = ip;
        }
    }
}
