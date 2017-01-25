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

namespace WpfApplication9
{
     class Pr_output 
    
            {
        TextBox _textBox;
        public  Pr_output(TextBox textBox)
        {
            _textBox = textBox;
        }
        public void req(string att)
        {
            // создаем процесс cmd.exe с параметрами "ipconfig /all"
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", att);
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
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

                    
                    _textBox.Text += temp;
                }

            
            // закрываем процесс
            procCommand.WaitForExit();
        }
    }
}
