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
using System.Security;
using System.Threading;

namespace TNT
{
    class Pr_output
    {
        public Pr_output()
        {

        }

        TextBox _textBox;
        public Pr_output(TextBox textBox)
        {
            _textBox = textBox;

        }
        public void req(string app, string att)
        {
            var user = "su";
            var password = "Chewb@cc@2016";
            var domain = "ru907";
            var securePass = new SecureString();
            foreach (char c in password)
            {
                securePass.AppendChar(c);
            }

            // создаем процесс cmd.exe с параметрами "ipconfig /all"
            ProcessStartInfo psiOpt = new ProcessStartInfo(app, att);
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            //psiOpt.UserName = user;
            //psiOpt.Password = securePass;
            //psiOpt.Domain = domain;
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


                    _textBox.Text += temp + "\n";

                }


            // закрываем процесс
            procCommand.WaitForExit();
        }

        



        public bool Andrey()
        {
            string resultText = "";
            

            bool result = false;

            var user = "su";
            var password = "Chewb@cc@2016";
            var domain = "ru907";
            var securePass = new SecureString();
            foreach (char c in password)
            {
                securePass.AppendChar(c);
            }

            //создаем процесс cmd.exe с параметрами "ipconfig /all"
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", @"/c NET USER Q583EYJ /DOMAIN ");
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.UserName = user;
            psiOpt.Password = securePass;
            psiOpt.Domain = domain;
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
                    var temp = srIncoming.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if (temp == null) break;

                    resultText += temp;
                }

            var Index = resultText.IndexOf("Учетная запись активна");
            var Ind = resultText.Substring(Index + 39, 3).Trim();
            if (Ind == "Yes") result = true;
            else result = false;

            return result;
            
        }
    }
}
