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
                ButtonUAC2.IsEnabled = false;
                

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


        private void button_Click(object sender, RoutedEventArgs e)
        {

            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"/C ipconfig /all");
        }


        private void button1_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Ping ya = new WpfApplication9.Ping();

            ya.ping("/K ping yandex.ru -t");

        }

        private void button2_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = @"/c C:\windows\system32\PsExec.exe -s -i \\ru907w1212 rundll32.exe user32.dll LockWorkStation";
            p.Start();
        }

        private void button3_click(object sender, RoutedEventArgs e)
        {
            WpfApplication9.Pr_output pr = new WpfApplication9.Pr_output(textBox);

            pr.req(@"/C psexec -s -i \\ru907w0778 rundll32.exe user32.dll LockWorkStation");

            /*System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/k tracert yandex.ru";
            p.Start();*/
        }

         private void Button4_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/k netsh int ip reset resetlog.txt";
            p.Start();
        } 

        private void Button5_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/k ipconfig /flushdns";
            p.Start();

        }

        private void ButtonP_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = string.Format("/k ping {0} -t", waterMarkTextBox.Text);
            p.Start();
        }

        private void waterMarkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.Arguments = string.Format("/k ping {0} -t", waterMarkTextBox.Text);
                p.Start();
            }
        }

        private void Button6_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "msinfo32";
            p.Start();
        }

        private void Button7_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "msconfig.exe";
            proc.StartInfo.WorkingDirectory = @"C:/windows/system32";
            proc.Start();
            proc.WaitForExit();
        }



        private void Button8_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/c printui /s /t2";
            p.Start();
        }

        private void Button9_click(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = @"C:\Windows\System32\spool";
            p.Start();

        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "devmgmt.msc";
            p.Start();
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
