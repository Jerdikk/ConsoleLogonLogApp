using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string path = "note"+DateTime.Now.ToString("yyyyMMdd")+".txt";            
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            

            // добавление в файл
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteAsync("User: "+userName+"  ");
                await writer.WriteLineAsync(args[0]+" "+DateTime.Now.ToLongTimeString());                
            }


            EventLog eventLog = new EventLog();

            eventLog.Source = "Visual Studio";
            //eventLog.Log = "Application";
            eventLog.Log = "";

            try
            {
                // Ваш код здесь

                //  int h = 10;

                //  h -= 10;
                //  int result = 10 / h; // Искусственная ошибка
                string t1 = "User: " + userName + "  " + args[0] + " " + DateTime.Now.ToLongTimeString();
                eventLog.WriteEntry(t1, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry("Ошибка: " + ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                eventLog.Close();
            }


        }
    }
}
