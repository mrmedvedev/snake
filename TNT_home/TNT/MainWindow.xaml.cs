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

namespace TNT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        private void Form1_Shown(Object sender, EventArgs e)
        {

            var rnd = new Random();
            var n = rnd.Next(1000, 3000);

            waterMarkTextBox.Text = "ru907w" + n;

        }

        private void Ipconfig_Click(object sender, RoutedEventArgs e)
        {

            Pr_output pr = new Pr_output(textBox);

            pr.req(@"cmd.exe", @"/C ipconfig /all");
        }


        private void RebootPC_click(object sender, RoutedEventArgs e)
        {
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"cmd.exe", string.Format(@"/k shutdown /r /t 5 /m \\{0}", waterMarkTextBox.Text));

        }

        private void UnlockUser_click(object sender, RoutedEventArgs e)
        {
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"cmd.exe", string.Format(@"/c NET USER {0} /ACTIVE:YES /DOMAIN", waterMarkTextBox.Text));
        }

        private void LockPC_click(object sender, RoutedEventArgs e)
        {
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"d:\PsExec.exe", string.Format(@"\\{0} -s -i rundll32.exe user32.dll LockWorkStation", waterMarkTextBox.Text));

        }

        private void Ipreset_click(object sender, RoutedEventArgs e)
        {
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"cmd.exe", @"/k netsh int ip reset resetlog.txt");

        }

        private void Dns_click(object sender, RoutedEventArgs e)
        {
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"cmd.exe", @"/k ipconfig /flushdns");

        }

        private void Ping_click(object sender, RoutedEventArgs e)
        {
            
            Pr_output pr = new Pr_output(textBox);
            
            pr.req(@"cmd.exe", string.Format("/k ping {0} ", waterMarkTextBox.Text));

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void andrey_Click(object sender, RoutedEventArgs e)
        {
            //andrey.Background = Brushes.Green;
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"cmd.exe", @"/c NET USER Q583EYJ /ACTIVE:YES /DOMAIN");
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
            System.Windows.MessageBox.Show("Текст сообщения", "Заголовок сообщения");
        }

        private void btn_Random_Click(object sender, RoutedEventArgs e)
        {

            var rnd = new Random();
            var n = rnd.Next(1000, 3000);

            waterMarkTextBox.Text = "ru907w" + n;

        }

        private void btn_Game_Click(object sender, RoutedEventArgs e)
        {
            Pr_output pr = new Pr_output(textBox);

            pr.req(@"D:\Turtle\Game.exe", "");

        }

        private void btn_IdInfo_Click(object sender, RoutedEventArgs e)
        {
            
            Pr_output pr = new Pr_output();
            var result = pr.Andrey();
            
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //Pr_output pr = new Pr_output();

            //if (pr.Andrey()) andrey.Background = Brushes.Green;

            //else andrey.Background = Brushes.Red;

            
        }


    }
}








