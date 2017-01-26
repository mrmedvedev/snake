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


namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (IsAdmin())
            {
                RestartPanel.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                ButtonUAC.IsEnabled = false;
                //ButtonUAC2.IsEnabled = false;
                

                System.Drawing.Icon img = System.Drawing.SystemIcons.Shield;

                System.Drawing.Bitmap bitmap = img.ToBitmap();
                IntPtr hBitmap = bitmap.GetHbitmap();

                ImageSource wpfBitmap =
                     System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          hBitmap, IntPtr.Zero, Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());

                RestartButtonIcon.Source = wpfBitmap;
                RestartButtonIcon.Height = 20;
                
            }

            // Analyzing arguments
            string[] args = Environment.GetCommandLineArgs();
            if (args.Count() > 1)
            {
                this.Left = Int32.Parse(args[2]);
                this.Top = Int32.Parse(args[3]);
                this.Width = Int32.Parse(args[4]);
                this.Height = Int32.Parse(args[5]);
            }
        }

        public static bool IsAdmin()
        {
            System.Security.Principal.WindowsIdentity id = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal p = new System.Security.Principal.WindowsPrincipal(id);

            return p.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }


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

        private void waterMarkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

                pr.req(@"cmd.exe", string.Format("/k ping {0} ", waterMarkTextBox.Text));
            }
        }

        
        private void site1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("TNT");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            RestartAsAdmin();
        }

        private void RestartAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            startInfo.Arguments = "restart " + this.Left + " "
                + this.Top + " " + this.Width + " " + this.Height;

            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
                this.Close();
            }
            catch (Exception ex)
            {
                // UAC elevation failed
            }
        }



        

       
    }

        
    }
