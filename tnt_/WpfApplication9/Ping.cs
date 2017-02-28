using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication9
{
    class Ping
    {
        public void ping(string arg)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = arg;
            p.Start();
        }
    }
}
