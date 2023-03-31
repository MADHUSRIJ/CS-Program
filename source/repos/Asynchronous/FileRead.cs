using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class FileRead
    {
        FileStream fs1 = null;
        StreamWriter writer = null;
        StreamReader reader = null;
        async Task<String> fileOpenerMethod()
        {
            fs1 = new FileStream("C:\\Users\\HP\\source\\repos\\day-5-hands-on\\files-created\\textwriter.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return "";
        }
        async Task<string> fileWriterMethod()
        {
            await fileOpenerMethod();
            await Task.Delay(2000);
            writer = new StreamWriter(fs1);
            writer.WriteLine("StreamWriter Demo");
            Console.WriteLine("Written");
            return "";
        }
        async Task<string> fileReaderMethod()
        {
            await fileWriterMethod();
            await Task.Delay(5000);

            reader = new StreamReader(fs1);
            string c = reader.ReadToEnd();
            Console.WriteLine(c);
            writer.Close();
            reader.Close();
            return "";
        }

        static async Task Main(string[] args)
        {

            FileRead p = new FileRead();
            await p.fileReaderMethod();
            p.fs1.Close();
        }
    }
}
