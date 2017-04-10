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

        //public void Count(object obj, TextBox server_name,TextBox server_status, EventArgs e)
        //{
        //    Job server1 = new Job();

        //    if


        //        (server1.req(server_name.Text))
        //    {
        //        Dispatcher.Invoke((Action)(() =>
        //        {
        //            server_status.Background = Brushes.Green;
        //        }));
        //    }


        //    else

        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            server_status.Background = Brushes.Red;
        //        }));
        //    }


        //}

        //public void Count2(object obj, EventArgs e)



        //{
        //    Job server2 = new Job();

        //    if


        //        (server2.req(Server_name2.Text))
        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            Server_status2.Background = Brushes.Green;
        //        }));
        //    }


        //    else

        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            Server_status2.Background = Brushes.Red;
        //        }));
        //    }


        //}

        //public void Count3(object obj, EventArgs e)



        //{
        //    Job server3 = new Job();

        //    if


        //        (server3.req(Server_name3.Text))
        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            Server_status3.Background = Brushes.Green;
        //        }));
        //    }


        //    else

        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            Server_status3.Background = Brushes.Red;
        //        }));
        //    }


        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Count c = new Count(Server_name1);
            Count c2 = new Count(Server_name2);
            //Count c3 = new Count(Server_name3);
            //Count c4 = new Count(Server_name4);
            //Count c5 = new Count(Server_name5);
            //Count c6 = new Count(Server_name6);
            //Count c7 = new Count(Server_name7);
            //Count c8 = new Count(Server_name8);
            //Count c9 = new Count(Server_name9);
            //Count c10 = new Count(Server_name10);

            //System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            //timer.Tick += new EventHandler(Count);
            //timer.Interval = new TimeSpan(0, 0, 3);
            //timer.Start();

            //System.Windows.Threading.DispatcherTimer timer2 = new System.Windows.Threading.DispatcherTimer();

            //timer2.Tick += new EventHandler(Count2);
            //timer2.Interval = new TimeSpan(0, 0, 3);
            //timer2.Start();

            //System.Windows.Threading.DispatcherTimer timer3 = new System.Windows.Threading.DispatcherTimer();

            //timer2.Tick += new EventHandler(Count3);
            //timer2.Interval = new TimeSpan(0, 0, 3);
            //timer2.Start();


        }

        
}
}

