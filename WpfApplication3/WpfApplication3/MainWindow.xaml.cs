using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Ping ping = new Ping();
            PingReply reply;
            try
            {
                reply = ping.Send(Server_name1.Text);
                if (reply.Status != IPStatus.Success) Server_status1.Background = Brushes.Red;
                else Server_status1.Background = Brushes.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            //    Job server1 = new Job();
            //    if 
            //        (server1.CheckConnection("yandex.ru"))
            //    {
            //        this.Dispatcher.Invoke((Action)(() =>
            //        {
            //            Server_status1.Background = Brushes.Green;
            //        }));
            //    }
            //}
        }

        
    }
}

