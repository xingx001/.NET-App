using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpider.Demo
{
    public class ThreadManager:AbsThreadManager
    {
        protected override AbsChain GetChainHeader()
        {
            return new NodeChain();
        }
    }
}
