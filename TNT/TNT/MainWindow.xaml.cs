using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Security;
using System.Windows.Threading;
using Microsoft.Win32;

namespace TNT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Thread thread;

        private void Ipconfig_Click(object sender, RoutedEventArgs e)
        {
            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.psexec);
            thread = new Thread(p.psexec);
            thread.IsBackground = true;
            thread.Start(string.Format(@"\\{0} d:\proxy.reg", waterMarkTextBox.Text));

            //RegistryKey regKey = Registry.CurrentUser;
            //regKey = regKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");
            //regKey.SetValue("ProxyEnable", 1);
            //regKey.SetValue("ProxyServer", "ruarray.ru.tnt.com:8080");

            //Pr_output p = new Pr_output(output);
            //ParameterizedThreadStart req = new ParameterizedThreadStart(p.cmd);
            //thread = new Thread(p.cmd);
            //thread.IsBackground = true;
            //thread.Start(@"/c ipconfig /all ");
            ////thread.Start(string.Format(@"/c psexec \\{0} cmd ipconfig /all & Pause", waterMarkTextBox.Text));

        }

        private void CdRom_Click(object sender, RoutedEventArgs e)
        {

            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.psexec);
            thread = new Thread(p.psexec);
            thread.IsBackground = true;
            thread.Start(string.Format(@"\\{0} -c -f d:\nircmd.exe cdrom open e:", waterMarkTextBox.Text));
        }


        private void RebootPC_click(object sender, RoutedEventArgs e)
        {

            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.cmd);
            thread = new Thread(p.cmd);
            thread.IsBackground = true;
            thread.Start(string.Format(@"/k shutdown /r /t 5 /m \\{0}", waterMarkTextBox.Text));

        }

        private void UnlockUser_click(object sender, RoutedEventArgs e)
        {

            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.cmd);
            thread = new Thread(p.cmd);
            thread.IsBackground = true;
            thread.Start(string.Format(@"/c NET USER {0} /ACTIVE:YES /DOMAIN", waterMarkTextBox.Text));
            
        }

        private void LockPC_click(object sender, RoutedEventArgs e)
        {

            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.psexec);
            thread = new Thread(p.psexec);
            thread.IsBackground = true;
            thread.Start(string.Format(@"\\{0} -s -i rundll32.exe user32.dll LockWorkStation", waterMarkTextBox.Text));

        }

        private void Ipreset_click(object sender, RoutedEventArgs e)
        {

            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.psexec);
            thread = new Thread(p.psexec);
            thread.IsBackground = true;
            thread.Start(string.Format(@"\\{0} cmd /k ipconfig /release & ipconfig /renew", waterMarkTextBox.Text));

        }

        private void Dns_click(object sender, RoutedEventArgs e)
        {
            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.psexec);
            thread = new Thread(p.psexec);
            thread.IsBackground = true;
            thread.Start(string.Format(@"\\{0} cmd /k ipconfig /flushdns", waterMarkTextBox.Text));

            
        }

        private void Ping_click(object sender, RoutedEventArgs e)
        {

            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.cmd);
            thread = new Thread(p.cmd);
            thread.IsBackground = true;
            thread.Start(string.Format("/k ping {0} -t", waterMarkTextBox.Text));

            
        }


       

        private void andrey_Click(object sender, RoutedEventArgs e)
        {
            Pr_output p = new Pr_output(output);
            ParameterizedThreadStart req = new ParameterizedThreadStart(p.cmd);
            thread = new Thread(p.cmd);
            thread.IsBackground = true;
            thread.Start(@"/c NET USER Q583EYJ /ACTIVE:YES /DOMAIN");
            
        }

        private void chb_shure_Checked(object sender, RoutedEventArgs e)
        {
            btn_RebootPC.IsEnabled = true;
        }
        private void chb_shure_Unchecked_1(object sender, RoutedEventArgs e)
        {
            btn_RebootPC.IsEnabled = false;
        }


        private void btn_About_click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("About", "This space for rent");
        }

        private void btn_Random_Click(object sender, RoutedEventArgs e)
        {

            var rnd = new Random();
            var n = rnd.Next(1000, 3000);

            waterMarkTextBox.Text = "ru907w" + n;

        }

        private void btn_Game_Click(object sender, RoutedEventArgs e)
        {

            ProcessStartInfo game = new ProcessStartInfo(@"D:\Turtle\Game.exe", "");
            game.WindowStyle = ProcessWindowStyle.Hidden;
            game.RedirectStandardOutput = true;
            game.UseShellExecute = false;
            game.CreateNoWindow = true;
            Process procCommand = Process.Start(game);

        }

        

        public void Count(object obj, EventArgs e)
        {
            Pr_output pr = new Pr_output();

            if


                (pr.Andrey())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    andrey.Background = Brushes.Green;
                }));
            }


            else

            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    andrey.Background = Brushes.Red;
                }));
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(Count);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            thread.Abort();
        }

        private void output_TextChanged(object sender, TextChangedEventArgs e)
        {
            output.ScrollToEnd();
        }
    }


}









