using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Generic
    {
        public void call()
        {
            Program<string> cp = new Program<string>("working");
            Program<int> cp1 = new Program<int>(25);
            Program<float> cp2 = new Program<float>(25.5f);
        }
        public class Program<T>
        {
            public Program(T message)
            {
                Console.WriteLine(message);
            }
        }


    }
}
