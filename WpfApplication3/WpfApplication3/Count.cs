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
    class Count
    {
        TextBox server_name;
        TextBox server_status;

        public Count(TextBox name, TextBox status)
        {
            server_name = name;
            server_status = status;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(count);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

        public void count(object obj, EventArgs e)
        {
            Job server1 = new Job();

            if (server1.req(server_name.Text))
            {
                    server_status.Background = Brushes.Green;
            }

            else

            {
                    server_status.Background = Brushes.Red;
            }

            
        }
    }
}
