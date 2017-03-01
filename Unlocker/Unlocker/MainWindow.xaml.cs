using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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


namespace Unlocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool thread_stop;

        public MainWindow()
        {
            InitializeComponent();

        }
        public class Output
        {
            public Output()
            {

            }

            public void req()
            {

                ProcessStartInfo p = new ProcessStartInfo(@"cmd.exe", @"/c NET USER admin");
                //p.WindowStyle = ProcessWindowStyle.Hidden;
                //p.RedirectStandardOutput = true;
                //p.UseShellExecute = false;
                //p.CreateNoWindow = true;
                Process procCommand = Process.Start(p);

            }

        }



        private void Main_Activated(object sender, EventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
        }

        public static void timerTick(object obj, EventArgs e)
        {
            Output a = new Output();
            ThreadStart req = new ThreadStart(a.req);
            Thread thread = new Thread(a.req);
            thread.Start();


        }

        private void Ping_Click(object sender, RoutedEventArgs e)
        {

            
                Output2 a = new Output2(output);
            //while (!thread_stop)
            //{
                ParameterizedThreadStart req = new ParameterizedThreadStart(a.req2);
                Thread thread = new Thread(a.req2);
                thread.Start(string.Format(@"/c ping {0} -t", waterMarkTextBox.Text));

            //}
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            thread_stop = true;
        }


        class Output2
        {

            public Output2()
            {

            }

            TextBox _output;
            public Output2(TextBox output)
            {
                _output = output;
            }




            public void req2(object att)
            {
                
                    ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", att.ToString());
                    //скрываем окно запущенного процесса

                    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                    psiOpt.RedirectStandardOutput = true;
                    psiOpt.UseShellExecute = false;
                    psiOpt.CreateNoWindow = true;
                    psiOpt.StandardOutputEncoding = Encoding.GetEncoding(866);

                    Process procCommand = Process.Start(psiOpt);

                    // получаем ответ запущенного процесса

                    using (StreamReader srIncoming = procCommand.StandardOutput)
                        // выводим результат

                        while (true)
                        {
                            // Читаем строку из файла во временную переменную.
                            string temp = srIncoming.ReadLine();

                            // Если достигнут конец файла, прерываем считывание.
                            if (temp == null) break;



                            {

                                Application.Current.Dispatcher.Invoke(new Action(() =>
                                {
                                    _output.Text += temp + "\n";
                                }));
                            }

                            
                            //procCommand.WaitForExit();

                        }

                }

            }


        }




    } 
    
    
    

