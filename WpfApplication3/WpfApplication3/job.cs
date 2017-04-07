using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace WpfApplication3
{
    class Job
    {
        public Job()
        {

        }
               

        public bool req(object att)
        {
            bool result = false;

            Ping ping = new Ping();
            PingReply reply;
            
                reply = ping.Send(att.ToString());
                if (reply.Status != IPStatus.Success) result = false;
                else result = true;
                return result;
            
        }
    }
}