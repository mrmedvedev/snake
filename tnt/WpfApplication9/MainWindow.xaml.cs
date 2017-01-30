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
using System.Windows.Forms;

namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        private void Ipconfig_Click(object sender, RoutedEventArgs e)
        {

            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", @"/C ipconfig /all");
        }


        private void RebootPC_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", string.Format(@"/k shutdown /r /t 5 /m \\{0}", waterMarkTextBox.Text));

        }

        private void UnlockUser_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", string.Format(@"/c NET USER {0} /ACTIVE:YES /DOMAIN", waterMarkTextBox.Text)); 
        }

        private void LockPC_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"d:\PsExec.exe", string.Format(@"\\{0} -s -i rundll32.exe user32.dll LockWorkStation", waterMarkTextBox.Text));
                                    
        }

         private void Ipreset_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", @"/k netsh int ip reset resetlog.txt");
            
        } 

        private void Dns_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", @"/k ipconfig /flushdns");
            
        }

        private void Ping_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", string.Format("/k ping {0} ", waterMarkTextBox.Text));
            
        }
                       
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void andrey_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"cmd.exe", @"/c ID  /ACTIVE:YES /DOMAIN");
        }

        private void chb_shure_Checked(object sender, RoutedEventArgs e)
        {
            
                btn_RebootPC.IsEnabled = true;
    }

        private void btn_About_click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Текст сообщения", "Заголовок сообщения");
        }

        private void btn_Random_Click(object sender, RoutedEventArgs e)
        {

            var rnd = new Random();
            var n = rnd.Next(0000, 9999);

            waterMarkTextBox.Text = "ru907w" + n;

        }

        private void btn_Game_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"D:\Turtle\Game.exe","");

        }
    }

   
        
    }

        
    
