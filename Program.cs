using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        }
    }
}
