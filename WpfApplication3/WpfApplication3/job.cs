using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WpfApplication3
{
    class Job
    {

        TextBox server_name;

        public Job(TextBox server_name)
        {
            this.server_name = server_name;
        }

        public void req(object att)
        {
            //bool result = false;


            Ping ping = new Ping();
            PingReply reply;
            try
            {
                reply = ping.Send(att.ToString());
                if (reply.Status == IPStatus.Success)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                       {
                           server_name.Background = Brushes.Green;
                       }));
                }

                else
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                                {
                                    server_name.Background = Brushes.Red;
                                }));
                }
            }
            catch (PingException)
            {
                
            }
                        
        }
        }
    }

