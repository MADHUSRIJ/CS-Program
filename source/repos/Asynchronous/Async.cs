using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Async
    {
        public async Task<string> Method1()
        {
            Console.WriteLine("Method 1 started");
            await Task.Delay(6000);
            Console.WriteLine("Method 1 ended");
            return "";
        }

        public async Task<string> Method2()
        {
            Console.WriteLine("Method 2 started");
            await Task.Delay(4000);
            Console.WriteLine("Method 2 ended");
            return "";
        }
        public async Task<string> Method3()
        {
            Console.WriteLine("Method 3 started");
            await Task.Delay(2000);
            Console.WriteLine("Method 3 ended");
            return "";
        }
    }

    internal class AsyncProgramming
    {
        static async Task Main(string[] args)
        {
            Async obj = new Async();
            Console.WriteLine("Without await");
            obj.Method1();
            obj.Method2();
            obj.Method3();
            Console.ReadLine();

            Console.WriteLine("With await");
            await obj.Method1();
            await obj.Method2();
            await obj.Method3();
            Console.ReadLine();

        }
    
    }
}
