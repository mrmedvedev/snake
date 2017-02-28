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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private void button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdateTextWrong);
            thread.Start();
        }

        private  UpdateTextWrong(string temp)
        {
            // Эмулирует некоторую работу посредством пятисекундной задержки
            //Thread.Sleep(TimeSpan.FromSeconds(5));

            // создаем процесс cmd.exe с параметрами 
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", @"/c ping mail.ru ");
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.StandardOutputEncoding = Encoding.GetEncoding(866);
            // запускаем процесс
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

                     
                    //txb.Text += temp + "\n";

                }

            // Получить диспетчер от текущего окна и использовать его для вызова кода обновления
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    txb.Text += temp + "\n";
                }
            );
        }
    }
}

        
    

